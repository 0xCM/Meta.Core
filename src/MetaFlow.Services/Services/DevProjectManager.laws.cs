//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Core;
    using Meta.Core.Project;
    using Meta.Core.Build;
    using SqlT.Core;
    using MetaFlow.Core;

    public interface IDevProjectManager : INodeService
    {
        Seq<FilePath> SolutionFiles { get; }

        FilePath SystemSolutionFile(SystemIdentifier sysId);

        IEnumerable<SolutionName> SystemSolutionNames(SystemIdentifier id);

        Option<SolutionDescription> SystemSolution(SystemIdentifier sysId);

        IEnumerable<FilePath> SystemProjectFiles(SystemIdentifier sysId);

        IEnumerable<PlatformProject> DiscoverPlatformProjects();

        IEnumerable<Core.PlatformSolution> DiscoverPlatformSolutions();

        Seq<DevProjectName> SystemProjectNames(string type);

        Seq<SolutionName> SystemSolutionNames();


    }


}