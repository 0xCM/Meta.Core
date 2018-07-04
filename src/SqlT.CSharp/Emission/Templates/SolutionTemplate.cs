using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlT.CSharp.Templates
{
    public class SolutionTemplate : ScriptTemplate<SolutionTemplate>
    {
        public SolutionTemplate()
        {
            ProjectTypeId = Guid.Empty;
            ProjectName = String.Empty;
            ProjectId = Guid.NewGuid();
        }

        public Guid ProjectTypeId { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}
