using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlT.CSharp.Templates
{
    public class AssemblyDesignation : ScriptTemplate<AssemblyDesignation>
    {
        public AssemblyDesignation()
            : base()
        {

        }

        public string RootNamespace { get; set; }

        public string Designator { get; set; }

        public string AssemblyTitle { get; set; }

        public string AssemblyVersion { get; set; }
    }
}
