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
    using System.Text;


    using static metacore;

    using static ClrStructureSpec;

    public class CSharpProject : DevProject<CSharpProject>, ICSharpProject
    {

        public static readonly FileExtension FileExtension = new FileExtension("csproj");

        public CSharpProject(DevProjectName Name,
            IEnumerable<CodeFileSpec> Content,
            IEnumerable<DistributedArtifact> Dependencies,
            ProjectWorkspace Workspace = null
            ) : base(Name)
        {
            this.CodeFiles = rolist<ProjectContentFile>();
            this.CodeFileSpecs = Content.ToList();
            this.Workspace = Workspace ??
                new ProjectWorkspace(this,
                    new CSharpImplementationArea(Content),
                    new LibraryArea(Dependencies)
                    );
        }


        public IReadOnlyList<CodeFileSpec> CodeFileSpecs { get; }

        public IReadOnlyList<ProjectContentFile> CodeFiles { get; }

        public ProjectWorkspace Workspace { get; }

    }
}
