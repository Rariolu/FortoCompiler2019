using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;

namespace FortoCompiler2019
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadStyle();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.GetInstance());
            Compilation.NodeCompiler.CloseNode();
        }
        static void LoadStyle()
        {
            string styleXML = ConfigurationManager.AppSettings["StyleXML"];
            bool b = StyleUtil.LoadTextStyles(styleXML);
        }
    }
}
