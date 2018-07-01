//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ProjectWorkspace : IWorkspace
    {
        public ProjectWorkspace(IDevProject Project, params WorkspaceArea[] areas)
        {
            this.Project = Project;
            this.Areas = areas;
        }

        public IDevProject Project { get; }

        public WorkspaceAreas Areas { get; }

        public override string ToString()
            => $"{Project}(Workspace)";

    }
}