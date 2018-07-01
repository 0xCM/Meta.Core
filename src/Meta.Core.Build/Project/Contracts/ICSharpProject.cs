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
    using Meta.Core.Project;

    using static metacore;

    using static ClrStructureSpec;

    public interface ICSharpProject : IDevProject
    {
        IReadOnlyList<CodeFileSpec> CodeFileSpecs { get; }

        IReadOnlyList<ProjectContentFile> CodeFiles { get; }

        ProjectWorkspace Workspace { get; }

    }
}