using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace GUI
{
    public class NewFastColouredTextBox : FastColoredTextBox
    {
        SyntaxHighlightConfig syntaxConfig = new SyntaxHighlightConfig();
        public NewFastColouredTextBox()
        {
            TextChanged += NewFastColouredTextBox_TextChanged;
        }
        public void UpdateStyleConfig(string lang)
        {
            SyntaxHighlightConfig outCon;
            if (StyleUtil.GetStyleConfig(lang, out outCon))
            {
                syntaxConfig = outCon;
                Text += "\n";
                Text = Text.TrimEnd('\n');
            }
        }
        void NewFastColouredTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            syntaxConfig.Highlight(e);
        }
    }
}