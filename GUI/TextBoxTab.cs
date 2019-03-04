using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class TextBoxTab : TabPageExtension
    {
        string filePath = "";
        string storedText = "";
        NewRichTextBox rtb = new NewRichTextBox();
        public TextBoxTab(string file) : base()
        {
            if (File.Exists(file))
            {
                filePath = file;
                Text = file;
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
            rtb.TextChanged += new EventHandler(rtb_TextChanged);
            this.Controls.Add(rtb);
            //this.Name = "textBoxtab" + namee;
            //this.Padding = new Padding(3);
            //this.SizeChanged += new EventHandler(textboxtab_SizeChanged);
            this.UseVisualStyleBackColor = true;
        }
        public void ResetStoredText()
        {
            storedText = rtb.Text;
            Text = filePath;
        }
        void rtb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}