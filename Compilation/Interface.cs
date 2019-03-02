using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    public static class Interface
    {
        static Dictionary<string, iCompiler> compilationClasses = new Dictionary<string, iCompiler>()
        {
            {".cs",CSCompiler.GetInstance()},
            {".js",NodeCompiler.GetInstance()},
            {".html",HTMLCompiler.GetInstance()}
        };
        public static bool HasExtension(string extension)
        {
            return compilationClasses.ContainsKey(extension.ToLower());
        }
        public static void Compile(string[] files,string extension,params object[] args)
        {
            if (compilationClasses.ContainsKey(extension.ToLower()))
            {
                compilationClasses[extension].Compile(files, args);
            }
        }
    }
}