using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    public class CSCompiler : iCompiler
    {
        private CSCompiler()
        {

        }
        static CSCompiler instance;
        public static CSCompiler GetInstance()
        {
            if (instance == null)
            {
                return instance = new CSCompiler();
            }
            return instance;
        }
        public void Compile(string[] files, params object[] args)
        {
            string exeFile = files[0].Replace(".cs", ".exe");
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.IncludeDebugInformation = false;
            for (int i = 0; i < args.Length; i++)
            {
                cp.ReferencedAssemblies.Add(args[i].ToString());
            }
            cp.GenerateExecutable = true;
            cp.OutputAssembly = exeFile;
            cp.GenerateInMemory = false;
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, @files);
            if (cr.Errors.Count > 0)
            {
                Console.WriteLine("ERROR!");
                //MessageBox.Show("Errors building {0} into {1}" + "\n" + sourceFile + "\n" + cr.PathToAssembly);
                //foreach (CompilerError ce in cr.Errors)
                //{
                //    MessageBox.Show("  {0}" + ce.ToString());
                //}
            }
            else
            {
                //MessageBox.Show("Source {0} built into {1} successfully." + "\n" + sourceFile + "\n" + cr.PathToAssembly);
                Process.Start(exeFile);
            }
        }
    }
}