using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlT.CSharp.Templates
{

    public class GenerationProfileTemplate : ScriptTemplate<GenerationProfileTemplate>
    {
        public GenerationProfileTemplate()
        {

        }

        public string Name { get; set; }

        public string RootNamespace { get; set; }

        public string OutputDirectory { get; set; }

        public string ConnectionString { get; set; }

        public string ProjectName { get; set; }

        public string SchemaName { get; set; }
        

        public string AssemblyDesignatorName { get; set; }

    }

}