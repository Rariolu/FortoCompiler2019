using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortoCompiler2019
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string file = "F:\\fff\\Imported VS Projects\\Projects\\FortoCompiler2019\\test.cs";
            Compiler.Run(file,"System.dll","System.Windows.Forms.dll");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string file = "C:\\Users\\Rariolu\\Documents\\NodeJSTut\\helloWorld.js";
            Compiler.Run(file, "http://localhost:8080");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Compilation.NodeCompiler.CloseNode();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file = "C:\\Users\\Rariolu\\Documents\\NodeJSTut\\summer.html";
            Compiler.Run(file);
        }
    }
}