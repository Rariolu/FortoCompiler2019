using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    public class HTMLCompiler : iCompiler
    {
        string chrome
        {
            get
            {
                return ConfigurationManager.AppSettings["Chrome"];
            }
        }
        private HTMLCompiler()
        {

        }
        static HTMLCompiler instance;
        public static HTMLCompiler GetInstance()
        {
            if (instance == null)
            {
                return instance = new HTMLCompiler();
            }
            return instance;
        }
        public void Compile(string[] files, params object[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo(chrome, files[0]);
            Process.Start(psi);
        }
    }
}