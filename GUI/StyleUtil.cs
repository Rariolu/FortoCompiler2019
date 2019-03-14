using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FastColoredTextBoxNS;

namespace GUI
{
    public static class StyleUtil
    {
        static Dictionary<string, Brush> brushCollection = new Dictionary<string, Brush>();
        static Dictionary<string, TextStyle> textStyleCollection = new Dictionary<string, TextStyle>();
        static Dictionary<string, FontStyle> fontStyleCollection = new Dictionary<string, FontStyle>();
        static Dictionary<KeyValuePair<Type, string>, object> enumCollection = new Dictionary<KeyValuePair<Type, string>, object>();
        static Dictionary<string, SyntaxHighlightConfig> langStyles = new Dictionary<string, SyntaxHighlightConfig>();
        public static string ProcessedString(this object t)
        {
            return t.ToString().ToLower().Trim();
        }
        public static Brush GetBrush(string name)
        {
            name = name.ProcessedString();
            if (brushCollection.ContainsKey(name))
            {
                return brushCollection[name];
            }
            if (name == "null")
            {
                brushCollection.Add(name, null);
                return null;
            }
            Color colour = Color.FromName(name);
            Brush brush = new SolidBrush(colour);
            brushCollection.Add(name, brush);
            return brush;
        }
        public static T GetEnumValue<T>(this string text) where T : struct
        {
            text = text.ProcessedString();
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                return default(T);
            }
            KeyValuePair<Type,string> kvp = new KeyValuePair<Type, string>(type, text);
            if (enumCollection.ContainsKey(kvp))
            {
                return (T)enumCollection[kvp];
            }
            foreach(T val in Enum.GetValues(type))
            {
                if (val.ProcessedString() == text)
                {
                    enumCollection.Add(kvp, val);
                    return val;
                }
                //else
                //{
                //    enumCollection.Add(new KeyValuePair<Type, string>(type, val.ProcessedString()), val);
                //}
            }
            enumCollection.Add(kvp, default(T));
            return default(T);
        }
        public static FontStyle GetFontStyle(string name)
        {
            name = name.ProcessedString();
            if (fontStyleCollection.ContainsKey(name))
            {
                return fontStyleCollection[name];
            }
            FontStyle fs = GetEnumValue<FontStyle>(name);
            fontStyleCollection.Add(name, fs);
            return fs;
        }
        public static TextStyle GetTextStyle(string name, string foreBrush="null", string backBrush="null", string fontStyle="")
        {
            name = name.ProcessedString();
            if (textStyleCollection.ContainsKey(name))
            {
                return textStyleCollection[name];
            }
            TextStyle textStyle = new TextStyle(GetBrush(foreBrush), GetBrush(backBrush), GetFontStyle(fontStyle));
            textStyleCollection.Add(name, textStyle);
            return textStyle;
        }
        public static bool LoadTextStyles(string filename)
        {
            filename = Path.GetFullPath(filename);
            filename = filename.EndsWith(".xml") ? filename : filename + ".xml";
            if (!File.Exists(filename))
            {
                return false;
            }
            XmlReader reader = XmlReader.Create(filename);
            while(reader.Read())
            {
                if (reader.IsStartElement("TextStyle"))
                {
                    string name = reader["Name"];
                    string foreBrush = reader["ForeBrush"];
                    string backBrush = reader["BackBrush"];
                    string fontStyle = reader["FontStyle"];
                    GetTextStyle(name,foreBrush, backBrush, fontStyle);
                }
            }
            return true;
        }
        public static bool GetStyleConfig(string langName, out SyntaxHighlightConfig config)
        {
            if (!langStyles.ContainsKey(langName))
            {
                return LoadStyleConfig(ConfigurationManager.AppSettings["StyleXML"], langName, out config);
            }
            config = langStyles[langName];
            return true;
        }
        public static bool LoadStyleConfig(string filename,string langName,out SyntaxHighlightConfig syntaxConfig)
        {
            filename = filename.EndsWith(".xml") ? filename : filename + ".xml";
            syntaxConfig = new SyntaxHighlightConfig();
            if (!File.Exists(filename))
            {
                return false;
            }
            XmlReader reader = XmlReader.Create(filename);
            while(reader.Read())
            {
                if (reader.IsStartElement("Language"))
                {
                    if (reader["name"] == langName)
                    {
                        XmlReader subtree = reader.ReadSubtree();
                        while(subtree.Read())
                        {
                            if (subtree.IsStartElement("Highlight"))
                            {
                                string regex = subtree["regex"];
                                string regexoptions = subtree["regexoptions"] ?? "None";
                                string style = subtree["style"];
                                syntaxConfig.AddStyle(regex, style,regexoptions);
                            }
                            if (subtree.IsStartElement("FoldingMarker"))
                            {
                                string openMarker = subtree["open"];
                                string closeMarker = subtree["close"];
                                syntaxConfig.AddFoldingMarker(openMarker, closeMarker);
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}