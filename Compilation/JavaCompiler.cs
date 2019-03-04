using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    public class JavaCompiler : iCompiler
    {
        string JavaC
        {
            get
            {
                return ConfigurationManager.AppSettings["JavacPath"];
            }
        }
        string Java
        {
            get
            {
                return ConfigurationManager.AppSettings["JavaPath"];
            }
        }
        private JavaCompiler()
        {

        }
        static JavaCompiler instance;
        public static JavaCompiler GetInstance()
        {
            if (instance == null)
            {
                return instance = new JavaCompiler();
            }
            return instance;
        }
        public void Compile(string[] files, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string file in files)
            {
                sb.Append(file + " ");
            }
            ProcessStartInfo javacProc = new ProcessStartInfo(JavaC, sb.ToString());
            
        }
    }
}
