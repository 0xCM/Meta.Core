//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;
    using System.Collections.Immutable;

    using Meta.Core;
    using Meta.Core.Build;
    using MetaFlow.Core;

    using SqlT.Models;
    using SqlT.Workflow;

    using static metacore;

    using N = SystemNode;

    public interface ISystemReflector
    {
        IImmutableSet<ClrAssembly> ComponentAssemblies { get; }

        IImmutableSet<ClrAssembly> DacAssemblies { get; }

        IImmutableSet<ISystemOperationsProvider> OperationProviders { get; }

        IEnumerable<ComponentDescriptor> ComponentDescriptions { get; }

        IImmutableSet<ClrAssembly> ProxyAssemblies { get; }

        IEnumerable<SystemProxyAssembly> ProxyAssemblyDescriptions { get; }

        IEnumerable<ICommandSpec> RuntimeCommandSpecs { get; }

        Seq<FilePath> SolutionFiles { get; }

        Option<SolutionDescription> SystemSolution(SystemIdentifier sysId);

        IEnumerable<FilePath> SystemProjectFiles(SystemIdentifier sysId);

        IEnumerable<NodeFilePath> DacProfileFiles { get; }

        IEnumerable<SqlDataFlowDescriptor> DataFlows { get; }

        Seq<SystemIdentifier> Systems { get; }

        IEnumerable<AgentDescriptor> ServiceAgents { get; }

        IEnumerable<PlatformAgent> PlatformAgents { get; }

        FilePath SystemSolutionFile(SystemIdentifier sysId);

        IEnumerable<PlatformDac> PlatformDacs { get; }

        IEnumerable<ISystemTaskHandler> SystemTaskHandlers { get; }

        IEnumerable<ISystemEventReactor> SystemEventReactors { get; }


        IEnumerable<SystemCommandRegistration> SystemCommands { get; }

        IEnumerable<SystemEventRegistration> SystemEvents { get; }

        Seq<Core.PlatformSolution> PlatformSolutions { get; }

        IEnumerable<DistributionDescription> Distributions { get; }

        IEnumerable<PlatformProject> PlatformProjects { get; }

        Option<ClrAssembly> FindAssembly(ComponentIdentifier Identifier);

        IEnumerable<ClrType> SystemEventTypes { get; }

        IEnumerable<ClrType> SystemCommandTypes { get; }
    }

}