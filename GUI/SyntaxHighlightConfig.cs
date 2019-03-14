using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace GUI
{
    struct HighlightStyle
    {
        public string RegexPattern;
        public TextStyle Style;
        public RegexOptions RegexOption;
        public HighlightStyle(string pattern, TextStyle style, RegexOptions option)
        {
            RegexPattern = pattern;
            Style = style;
            RegexOption = option;
        }
    }
    public class SyntaxHighlightConfig
    {
        List<HighlightStyle> highlightStyles = new List<HighlightStyle>();
        //Dictionary<string, TextStyle> styles = new Dictionary<string, TextStyle>();
        List<KeyValuePair<string, string>> foldingMarkers = new List<KeyValuePair<string, string>>();
        public void Highlight(TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(highlightStyles.Select(hs => hs.Style).ToArray());//styles.Values.ToArray());
            foreach(HighlightStyle style in highlightStyles)
            {
                e.ChangedRange.SetStyle(style.Style, style.RegexPattern, style.RegexOption);
            }
            //foreach(string style in styles.Keys)
            //{
            //    e.ChangedRange.SetStyle(styles[style], style);
            //}
            e.ChangedRange.ClearFoldingMarkers();
            foreach(KeyValuePair<string,string> kvp in foldingMarkers)
            {
                e.ChangedRange.SetFoldingMarkers(kvp.Key, kvp.Value);
            }
        }
        public void AddStyle(string regex, string textStyle, string regexoptions="None")
        {
            highlightStyles.Add(new HighlightStyle(regex, StyleUtil.GetTextStyle(textStyle), StyleUtil.GetEnumValue<RegexOptions>(regexoptions)));
            //if (!styles.ContainsKey(regex))
            //{
            //    styles.Add(regex,StyleUtil.GetTextStyle(textStyle));
            //}
        }
        public void AddFoldingMarker(string startFoldingPattern, string finishFoldingPattern)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(startFoldingPattern, finishFoldingPattern);
            if (!foldingMarkers.Contains(kvp))
            {
                foldingMarkers.Add(kvp);
            }
        }
    }
}