using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    public class NodeCompiler : iCompiler
    {
        const string nodeJS = "C:\\Program Files\\nodejs\\node.exe";
        const string chrome = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
        private NodeCompiler()
        {

        }
        static NodeCompiler instance;
        public static NodeCompiler GetInstance()
        {
            if (instance == null)
            {
                return instance = new NodeCompiler();
            }
            return instance;
        }
        public void Compile(string[] filepaths, params object[] args)
        {
            Run(filepaths[0],args[0].ToString());
        }
        void Run(string file,string url)
        {
            ProcessStartInfo psi = new ProcessStartInfo(nodeJS, file);
            nodeProcs.Add(Process.Start(psi));
            ProcessStartInfo chromePSI = new ProcessStartInfo(chrome, url);
            Process.Start(chromePSI);
        }
        static List<Process> nodeProcs = new List<Process>();
        public static void CloseNode()
        {
            for (int i = 0; i < nodeProcs.Count; i++)
            {
                if (!nodeProcs[i].HasExited)
                {
                    nodeProcs[i].CloseMainWindow();
                    nodeProcs[i].Close();
                }
            }
        }
    }
}