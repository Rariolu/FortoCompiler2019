using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilation;
namespace FortoCompiler2019
{
    public static class Compiler
    {
        public static string GetExtension(this string file)
        {
            int dot = file.LastIndexOf('.');
            return file.Substring(dot, file.Length - dot);
        }
        public static void Run(string file, params object[] args)
        {
            if (!Interface.HasExtension(file.GetExtension()))
            {
                Console.WriteLine("File type unknown.");
            }
            Interface.Compile(new string[] { file }, file.GetExtension(), args);
        }
    }
}