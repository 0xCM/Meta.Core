//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static metacore;

    using static BuildSyntax;

    public class ProjectDescription
    {
        public ProjectDescription()
        {
            this.xmlns = "http://schemas.microsoft.com/developer/msbuild/2003";
            this.DefaultTargets = "Build";
            this.ToolsVersion = "15.0";
        }

        public ProjectDescription(string Name, FilePath AbsolutePath, RelativePath Location, string ProjectGuid)
            : this()
        {
            this.Name = Name;
            this.AbsolutePath = AbsolutePath;
            this.Location = Location;
            this.ProjectGuid = ProjectGuid;
            this.Properties = rolist<PropertyEvaluation>();
        }

        public string Name { get; set; }

        public FilePath AbsolutePath { get; set; }

        public RelativePath Location { get; set; }

        public IReadOnlyList<string> Dependencies { get; set; }

        public IReadOnlyList<FilePath> Files { get; set; }

        public string ProjectGuid { get; set; }

        public string DefaultTargets { get; set; }

        public string ToolsVersion { get; set; }

        public string xmlns { get; set; }

        public IReadOnlyList<PropertyEvaluation> Properties { get; set; }

        public IEnumerable<PropertyEvaluation> Evaluations
            => unionize(new StandardSqlEvaluations(Properties), 
                new StandardEvaluations(Properties));

        protected Option<string> Evaluation([CallerMemberName] string PropertyName = null)
            => from prop in Properties.TryGetFirst(p => p.PropertyName == PropertyName)
               select prop.EpandedValue;

        public Option<string> AssemblyName
            => Evaluation();
       
        public override string ToString()
            => Name;
    }

}
