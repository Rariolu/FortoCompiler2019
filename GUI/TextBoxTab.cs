using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class TextBoxTab : TabPageExtension
    {
        //string filePath = "";
        string storedText = "";
        NewRichTextBox rtb = new NewRichTextBox();
        public TextBoxTab() : base()
        {
            //filePath = "newPage"+TabID;
        }
        public TextBoxTab(string file) :base(file)
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
            rtb.BackColor = Color.FromArgb(255, 255, 128);
            //(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            rtb.Font = new Font("Consolas", 25);
            rtb.Location = new Point(6, 6);
            rtb.TabIndex = 0;
            rtb.TextChanged += new EventHandler(rtb_TextChanged);
            this.Controls.Add(rtb);
            this.Padding = new Padding(3);
            this.SizeChanged += new EventHandler(textboxtab_SizeChanged);
            this.UseVisualStyleBackColor = true;
        }
        void ResetStoredText()
        {
            storedText = rtb.Text;
            Text = FilePath;
        }
        void rtb_TextChanged(object sender, EventArgs e)
        {
            if (rtb.Text != storedText)
            {
                Text = "*" + FilePath;
            }
            ChangeHappened();
        }
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