using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;

namespace FortoCompiler2019
{
    public partial class MainForm : Form
    {
        static MainForm instance;
        public static MainForm GetInstance()
        {
            if (instance == null)
            {
                return instance = new MainForm();
            }
            return instance;
        }
        private MainForm()
        {
            InitializeComponent();
            AddTextPage();
        }
        void AddTextPage(string file="")
        {
            ColouredTextBoxTab tab = String.IsNullOrEmpty(file) ? new ColouredTextBoxTab() : new ColouredTextBoxTab(file);
            //TextBoxTab tab = String.IsNullOrEmpty(file) ? new TextBoxTab() : new TextBoxTab(file);
            AddPage(tab);
        }
        void AddPage(TabPageExtension page)
        {
            tbcMain.TabPages.Add(page);
            tbcMain.SelectLastTab();
        }
        bool AtLeastOneTab()
        {
            return tbcMain.TabCount > 0;
        }
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (AtLeastOneTab())
            {
                SaveAs();
            }
        }
        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (AtLeastOneTab())
            {
                Save();
            }
        }
        void Save()
        {
            if (tbcMain.SelectedTab.PrevSaved)
            {
                tbcMain.SelectedTab.Save();
            }
            else
            {
                SaveAs();
            }
        }
        void SaveAs()
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = tbcMain.SelectedTab.DialogFilter();
            saveFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                tbcMain.SelectedTab.SaveAs(saveFD.FileName);
            }
        }
        private void mnuRun_Click(object sender, EventArgs e)
        {
            if (AtLeastOneTab())
            {
                if (MessageBox.Show("You need to save to compile, comply?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                    TabPageExtension tbe = tbcMain.SelectedTab;
                    Compiler.Run(tbe.FilePath, tbe.AdditionalParams());
                }
            }
        }
        private void mnuNew_Click(object sender, EventArgs e)
        {
            AddTextPage();
        }
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            Open();
        }
        void Open()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Multiselect = true;
            openFD.Filter = TextBoxTab.TextBoxTabDialogFilter();
            openFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFD.FileNames)
                {
                    AddTextPage(file);
                }
            }
        }
        private void mnuCloseTab_Click(object sender, EventArgs e)
        {
            if (AtLeastOneTab())
            {
                CloseCurrentTab();
            }
        }
        void CloseCurrentTab()
        {
            if (!tbcMain.SelectedTab.UnChanged())
            {
                if (MessageBox.Show(String.Format("Would you like to save {0} before closing?",tbcMain.SelectedTab.FilePath), "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
            }
            tbcMain.TabPages.RemoveAt(tbcMain.SelectedIndex);
        }
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Quit();
            Close();
        }
        void Quit()
        {
            CloseRedundantTabs();
            while (tbcMain.TabCount > 0)
            {
                CloseCurrentTab();
            }
        }
        void CloseRedundantTabs()
        {
            for (int i = 0; i < tbcMain.TabCount; i++)
            {
                TabPageExtension tbe = tbcMain.TabPages[i] as TabPageExtension;
                if (!tbe.EverChanged || tbe.UnChanged())
                {
                    tbcMain.TabPages.RemoveAt(i);
                }
            }
        }
        private void mnuAddParam_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Quit();
        }
        private void SyntaxLanguage_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnuButton = sender as ToolStripMenuItem;
            (tbcMain.SelectedTab as ColouredTextBoxTab).UpdateStyleConfig(mnuButton.Tag.ToString());
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string file = "F:\\fff\\Imported VS Projects\\Projects\\FortoCompiler2019\\test.cs";
        //    Compiler.Run(file,"System.dll","System.Windows.Forms.dll");
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string file = "C:\\Users\\Rariolu\\Documents\\NodeJSTut\\helloWorld.js";
        //    Compiler.Run(file, "http://localhost:8080");
        //}
    }
}