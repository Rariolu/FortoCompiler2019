namespace FortoCompiler2019
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddParam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCS = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcMain = new GUI.NewTabControl();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuLanguage,
            this.mnuRun});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(504, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem1,
            this.mnuCloseTab,
            this.mnuQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(186, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(186, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(186, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveAs.Size = new System.Drawing.Size(186, 22);
            this.mnuSaveAs.Text = "Save As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuCloseTab
            // 
            this.mnuCloseTab.Name = "mnuCloseTab";
            this.mnuCloseTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuCloseTab.Size = new System.Drawing.Size(186, 22);
            this.mnuCloseTab.Text = "Close Tab";
            this.mnuCloseTab.Click += new System.EventHandler(this.mnuCloseTab_Click);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.mnuQuit.Size = new System.Drawing.Size(186, 22);
            this.mnuQuit.Text = "Quit";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddParam});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuAddParam
            // 
            this.mnuAddParam.Name = "mnuAddParam";
            this.mnuAddParam.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuAddParam.Size = new System.Drawing.Size(206, 22);
            this.mnuAddParam.Text = "Add Param";
            this.mnuAddParam.Click += new System.EventHandler(this.mnuAddParam_Click);
            // 
            // mnuRun
            // 
            this.mnuRun.Name = "mnuRun";
            this.mnuRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuRun.Size = new System.Drawing.Size(40, 20);
            this.mnuRun.Text = "Run";
            this.mnuRun.Click += new System.EventHandler(this.mnuRun_Click);
            // 
            // mnuLanguage
            // 
            this.mnuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuC});
            this.mnuLanguage.Name = "mnuLanguage";
            this.mnuLanguage.Size = new System.Drawing.Size(71, 20);
            this.mnuLanguage.Text = "Language";
            // 
            // mnuC
            // 
            this.mnuC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCS});
            this.mnuC.Name = "mnuC";
            this.mnuC.Size = new System.Drawing.Size(152, 22);
            this.mnuC.Text = "C";
            // 
            // mnuCS
            // 
            this.mnuCS.Name = "mnuCS";
            this.mnuCS.Size = new System.Drawing.Size(152, 22);
            this.mnuCS.Tag = "CS";
            this.mnuCS.Text = "C#";
            this.mnuCS.Click += new System.EventHandler(this.SyntaxLanguage_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 24);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(504, 345);
            this.tbcMain.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 369);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "FortoCompiler2019";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.NewTabControl tbcMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuRun;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseTab;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAddParam;
        private System.Windows.Forms.ToolStripMenuItem mnuLanguage;
        private System.Windows.Forms.ToolStripMenuItem mnuC;
        private System.Windows.Forms.ToolStripMenuItem mnuCS;
    }
}

