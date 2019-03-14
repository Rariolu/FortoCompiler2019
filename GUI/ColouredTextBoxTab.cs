using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace GUI
{
    public class ColouredTextBoxTab : TabPageExtension
    {
        //string filePath = "";
        string storedText = "";
        NewFastColouredTextBox rtb = new NewFastColouredTextBox();
        public ColouredTextBoxTab() : base()
        {
            //filePath = "newPage"+TabID;
        }
        public ColouredTextBoxTab(string file) :base(file)
        {
            if (File.Exists(file))
            {
                //filePath = file;
                //Text = file;
                storedText = File.ReadAllText(file);
                rtb.Text = File.ReadAllText(file);
            }
        }
        protected override void InitialiseComponent()
        {
            rtb.AcceptsTab = true;
            rtb.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            rtb.Font = new Font("Consolas", 25);
            rtb.Location = new Point(6, 6);
            rtb.TabIndex = 0;
            rtb.TextChanged += new EventHandler<TextChangedEventArgs>(rtb_TextChanged);
            rtb.LeftBracket = '(';
            rtb.RightBracket = ')';
            rtb.LeftBracket2 = '\x0';
            rtb.RightBracket2 = '\x0';
            this.Controls.Add(rtb);
            this.Padding = new Padding(3);
            this.SizeChanged += new EventHandler(textboxtab_SizeChanged);
            this.UseVisualStyleBackColor = true;
        }
        public void UpdateStyleConfig(string lang)
        {
            rtb.UpdateStyleConfig(lang);
        }
        void ResetStoredText()
        {
            storedText = rtb.Text;
            Text = FilePath;
        }
        void rtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rtb.Text != storedText)
            {
                Text = "*" + FilePath;
            }
            ChangeHappened();
        }
        //private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        //{
        //    //rtb.LeftBracket = '(';
        //    //rtb.RightBracket = ')';
        //    //rtb.LeftBracket2 = '\x0';
        //    //rtb.RightBracket2 = '\x0';
        //    //clear style of changed range
        //    e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

        //    //string highlighting
        //    e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
        //    //comment highlighting
        //    e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
        //    e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
        //    e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
        //    //number highlighting
        //    e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
        //    //attribute highlighting
        //    e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
        //    //class name highlighting
        //    e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
        //    //keyword highlighting
        //    e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

        //    //clear folding markers
        //    e.ChangedRange.ClearFoldingMarkers();

        //    //set folding markers
        //    e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
        //    e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
        //    e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        //}
        void textboxtab_SizeChanged(object sender, EventArgs e)
        {
            ResetRTBSize();
        }
        void ResetRTBSize()
        {
            rtb.Size = new Size(Size.Width - 10, Size.Height - 6);
        }
        public override void Save()
        {
            File.WriteAllText(FilePath, rtb.Text);
            ResetStoredText();
        }
        public override void SaveAs(string file)
        {
            FilePath = file;
            Save();
        }
        public static string TextBoxTabDialogFilter()
        {
            return "Text files|*.txt|C# files|*.cs|HTML files|*.html|Javascript files|*.js";
        }
        public override string DialogFilter()
        {
            return TextBoxTabDialogFilter();
        }
        public override bool UnChanged()
        {
            return rtb.Text == storedText && PrevSaved;
        }
    }
}