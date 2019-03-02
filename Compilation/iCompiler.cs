using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilation
{
    interface iCompiler
    {
        void Compile(string[] filepaths, params object[] args);
    }
}