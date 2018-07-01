//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDescription
    {
        public SolutionDescription(FilePath SrcPath, IEnumerable<ProjectDescription> Projects)
        {
            this.SrcPath = SrcPath;
            this.Projects = Projects.ToReadOnlyList();
        }

        public FilePath SrcPath { get; }

        public IReadOnlyList<ProjectDescription> Projects { get; }

        public string Name
            => SrcPath.FileName;

        public override string ToString()
            => Name;
    }
}