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

    using static metacore;

    /// <summary>
    /// Defines a container for a collection of artifacts that, when processed,
    /// yields a system component
    /// </summary>
    public class DevProject : IDevProject
    {
        public DevProject(DevProjectName Name, IEnumerable<ProjectContentFile> Content,
            IEnumerable<DistributedArtifact> Dependencies, ProjectWorkspace Workspace = null)
        {
            this.ProjectName = Name;
            this.CodeFiles = Content.ToList();
            this.Workspace = Workspace ??
                new ProjectWorkspace(this,
                    new ImplementationArea(Content),
                    new LibraryArea(Dependencies)
                    );
        }

        /// <summary>
        /// Identifies the project within some context 
        /// </summary>
        public DevProjectName ProjectName { get; }

        /// <summary>
        /// The source files included in the project
        /// </summary>
        public IReadOnlyList<ProjectContentFile> CodeFiles { get; }

        /// <summary>
        /// The project workspace
        /// </summary>
        public ProjectWorkspace Workspace { get; }

    }


}