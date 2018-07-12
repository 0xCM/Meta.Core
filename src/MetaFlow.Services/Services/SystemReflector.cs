//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Reflection;

    using SqlT.Core;
    using SqlT.Services;
    using SqlT.CSharp;
    using SqlT.Workflow;

    using Meta.Core;
    using Meta.Core.Project;
    using Meta.Core.Build;
    using MetaFlow.Core;

    using static metacore;
        
    using DistId = DistributionIdentifier;

    using N = SystemNode;
  
    class SystemReflector : ApplicationService<SystemReflector, ISystemReflector>, ISystemReflector
    {
        ISqlPackageManager PacMan
            => C.SqlPackageManager();

        IDevProjectManager ProjectManager
            => C.ProjectManager();

        SqlDacNav DacNavigator
            => C.NFS().SqlDacNav(N.Local);

        ISqlProxyProfileManager ProxyProfileManager
            => C.SqlProxyProfileManager();

        static FolderPath LibraryLocation
            => FilePath.Parse(Assembly.GetExecutingAssembly().Location).Folder;

        static FolderPath ProxyLocation
            => FilePath.Parse(MetaFlowCoreStorage.Assembly.Location).Folder;

        static Option<T> TryCreate<T>(Type t)
            => Try(() => cast<T>(Activator.CreateInstance(t)));

        Lazy<Set<ClrAssembly>> _ComponentAssemblies { get; }

        Lazy<Set<ClrAssembly>> _ProxyAssmeblies { get; }

        Lazy<Set<ClrAssembly>> _DacAssemblies { get; }

        Lazy<Set<ISystemOperationsProvider>> _OperationProviders { get; }

        Lazy<Lst<Core.PlatformSolution>> _PlatformSolutions { get; }

        Lazy<Lst<PlatformProject>> _PlatformProjects { get; }

        NodeFolderPath DacPacLocation
            => DacNavigator.DacPacLocation;

        Lazy<IReadOnlyDictionary<SystemCommandUri, ISystemTaskHandler>> _TaskHandlerIndex { get; }

        Lazy<IReadOnlyDictionary<SystemEventUri, ISystemEventReactor>> _EventReactorIndex { get; }

        IEnumerable<ISystemOperationsProvider> GetOperationProviders()
            => from c in ComponentAssemblies
               let d = c.Designator.MapValueOrDefault(x => x as ISystemOperationsProvider)
               where isNotNull(d)
               select d;

        public IEnumerable<ISystemTaskHandler> SystemTaskHandlers
            => _TaskHandlerIndex.Value.Values.Distinct();

        public IEnumerable<ISystemEventReactor> SystemEventReactors
            => _EventReactorIndex.Value.Values.Distinct();

        static Set<ClrAssembly> LoadSystemAssemblies()
            =>set(from path in LibraryLocation.GetFiles("*.dll")
                                    let assembly = Assembly.LoadFile(path).ClrAssembly()
                                    where assembly.Classification != ComponentClassification.None
                                    select assembly);

        static Set<ClrAssembly> LoadProxyAssemblies()
            => set(from path in ProxyLocation.GetFiles("*.dll")
                   let assembly = Assembly.LoadFile(path).ClrAssembly()
                   where assembly.ReflectedElement.IsProxyAssembly()
                   select assembly);

        Set<ClrAssembly> LoadDacAssemblies()
            => set(from path in DacPacLocation.Files(FileExtension.Parse("dll"))
                   let assembly = Assembly.LoadFile(path.AbsolutePath).ClrAssembly()                   
                   select assembly);

        IReadOnlyDictionary<SystemCommandUri, ISystemTaskHandler> DiscoverTaskHandlers()
        {
            var services = list(from descriptor in C.ProvidedServices
                                where descriptor.SupportsContract<ISystemTaskHandler>() 
                                && not(descriptor.IsDefaultImplementation)
                                select C.Service<ISystemTaskHandler>(descriptor.ImplementationName)
                                );

            var handlers = list(from service in services.Stream()
                           from command in service.SupportedCommands
                           select (command, service));

            var index = new Dictionary<SystemCommandUri, ISystemTaskHandler>();
            foreach(var h in handlers.Stream())
            {
                if (index.ContainsKey(h.command))
                    NotifyError($"Duplicate task handler {h.command} implemented by {h.service}");
                else
                    index.Add(h.command, h.service);
            }
            return index;
        }

        IReadOnlyDictionary<SystemEventUri, ISystemEventReactor> DiscoverEventReactors()
        {
            var services = rolist(from descriptor in C.ProvidedServices
                                where descriptor.SupportsContract<ISystemEventReactor>()
                                && not(descriptor.IsDefaultImplementation)
                                select C.Service<ISystemEventReactor>(descriptor.ImplementationName)
                                );

            return dict(from service in services
                                from @event in service.SupportedEvents
                                select (@event, service));           
        }

        public SystemReflector(IApplicationContext C)
            : base(C)
        {

            _ComponentAssemblies = defer(() => LoadSystemAssemblies());            
            _ProxyAssmeblies = defer(() => LoadProxyAssemblies());
            _DacAssemblies = defer(() => LoadDacAssemblies());
            _OperationProviders = defer(() => set(GetOperationProviders()));
            _TaskHandlerIndex = defer(() => DiscoverTaskHandlers());
            _EventReactorIndex = defer(() => DiscoverEventReactors());
            _PlatformSolutions = defer(() => list(ProjectManager.DiscoverPlatformSolutions()));
            _PlatformProjects = defer(() => list(ProjectManager.DiscoverPlatformProjects()));
        }
       
        public IImmutableSet<ClrAssembly> ComponentAssemblies
            => _ComponentAssemblies.Value.AsImmutableSet();

        public IImmutableSet<ISystemOperationsProvider> OperationProviders
            => _OperationProviders.Value.AsImmutableSet();

        IReadOnlyDictionary<SystemCommandUri, ISystemTaskHandler> TaskHandlerIndex
            => _TaskHandlerIndex.Value;

        IReadOnlyDictionary<SystemEventUri, ISystemEventReactor> EventReactorIndex
            => _EventReactorIndex.Value;

        public IImmutableSet<ClrAssembly> ProxyAssemblies
            => _ProxyAssmeblies.Value.AsImmutableSet();

        public IImmutableSet<ClrAssembly> DacAssemblies
            => _DacAssemblies.Value.AsImmutableSet();

        public IEnumerable<ComponentDescriptor> ComponentDescriptions
            => unionize(ComponentAssemblies, ProxyAssemblies, DacAssemblies).Select(a => a.ReflectedElement.ComponentDescriptor());

        public Option<ClrAssembly> FindAssembly(ComponentIdentifier Identifier)
            => ComponentAssemblies.TryGetFirst(c => c.Identifier == Identifier);

        IEnumerable<CodeGenerationProfile> ParseProxyProfiles(IEnumerable<TextResource> Resources)
            => from r in Resources
               let profile = ProxyProfileManager.ParseProfile(r.Text)
               where profile.OnNone(Notify).IsSome()
               select profile.ValueOrDefault();

        public IEnumerable<SystemProxyAssembly> ProxyAssemblyDescriptions
            => from pa in ProxyAssemblies
               let profiles =  rolist(ParseProxyProfiles(pa.TextResources(".sqlt")))
               where profiles.Count != 0
               select new SystemProxyAssembly(pa, profiles);               

        public IEnumerable<ICommandSpec> RuntimeCommandSpecs
            => from c in ComponentAssemblies
               from t in c.Types
               where t.HasAttribute<CommandSpecAttribute>()
                && not(t.Realizes<IProcessCommand>())
               let i = TryCreate<ICommandSpec>(t).OnNone(Notify)
               where i.IsSome()
               select i.Require();

        public FolderPath AreaDir
            => PlatformVariables.DevAreaDir;

        public Seq<FolderPath> AreaFolders
             => from s in Systems
                let folderName = FolderName.Parse(s.Identifier)
                select AreaDir + folderName;

        public Seq<FilePath> SolutionFiles
            => ProjectManager.SolutionFiles;

        public Seq<Core.PlatformSolution> PlatformSolutions
            => _PlatformSolutions.Value;

        public IEnumerable<DistributionDescription> Distributions
            => from subfolder in CommonFolders.DistRootDir.Subfolders()
               select new DistributionDescription(DistributionId: subfolder.FolderName, Description: null);

        public Option<FolderPath> DistributionFolder(DistId id, string type)
            => (from d in Distributions.Where(d => d.DistributionId == id)
                let folderName = FolderName.Parse(d.DistributionId)
                let path = (CommonFolders.DistRootDir + folderName) + FolderName.Parse(type)
                select path).FirstOrDefault();

        public FilePath SystemSolutionFile(SystemIdentifier sysId)
            => ProjectManager.SystemSolutionFile(sysId);
            
        public IEnumerable<PlatformProject> PlatformProjects
            => _PlatformProjects.Value.Stream();

        public Option<SolutionDescription> SystemSolution(SystemIdentifier sysId)
            => ProjectManager.SystemSolution(sysId);

        public IEnumerable<FilePath> SystemProjectFiles(SystemIdentifier sysId)
            => ProjectManager.SystemProjectFiles(sysId);

        public IEnumerable<SolutionName> SystemSolutionNames(SystemIdentifier id)
            => ProjectManager.SystemSolutionNames(id);

        public Seq<DevProjectName> SystemProjectNames(string type)
            => ProjectManager.SystemProjectNames(type);

        public Seq<SolutionName> SystemSolutionNames()
            => ProjectManager.SystemSolutionNames();

        public IEnumerable<PlatformAgent> PlatformAgents
            => from a in ServiceAgents
               let system = a.HostType.Assembly.DefiningSystem()
               where not(system.IsEmpty)
               select new PlatformAgent(system.ToString(), a.AgentId);

        public Seq<SystemIdentifier> Systems
            => from literal in ClrEnum.Get<PlatformSystemKind>().Literals
               where literal.LiteralName != PlatformSystemKind.None.ToString()
               select SystemIdentifier.Parse(literal.LiteralName);

        public IEnumerable<SqlDataFlowDescriptor> DataFlows
            => from a in ComponentAssemblies.AsParallel()
               from df in SqlDataFlow.Search(a)
               select df;

        public IEnumerable<AgentDescriptor> ServiceAgents
            => ServiceAgent.DiscoverAgents(ComponentAssemblies);

        public IEnumerable<ClrType> SystemCommandTypes
            => from a in ProxyAssemblies
               from t in a.NamedPublicTypes.Stream()
               where t.Realizes<WF.ISystemCommand>() && not(t.IsAbstract)
               select t;

        public IEnumerable<ClrType> SystemEventTypes
            => from a in ProxyAssemblies
               from t in a.NamedPublicTypes.Stream()
               where t.Realizes<WF.ISystemEvent>() && not(t.IsAbstract)
               select t;

        public IEnumerable<SystemCommandRegistration> SystemCommands
            => 
                from t in SystemCommandTypes
               select new SystemCommandRegistration(
                   SystemId: t.ReflectedElement.DefiningSystem(),
                   MessageName: t.Name,
                   Purpose: t.Description                   
                   );

        public IEnumerable<SystemEventRegistration> SystemEvents
            => from t in SystemEventTypes
               select new SystemEventRegistration(
                   SystemId: t.ReflectedElement.DefiningSystem(),
                   MessageName: t.Name,
                   Purpose: t.Description
                   );

        public IEnumerable<NodeFilePath> DacProfileFiles
            => DacNavigator.DacProfileFiles;

        public IEnumerable<PlatformDac> PlatformDacs
            => from file in DacNavigator.DacPacFiles
               let description = PacMan.DescribePackage(file)
               where description.IsSome()
               select description.MapRequired(d => d.ToPlatformDac());

        public FolderPath BuildLogDir
            => PlatformVariables.BuildLogDir;

        /// <summary>
        /// Enumerates the build log files
        /// </summary>
        public IEnumerable<FilePath> BuildLogFiles
            => BuildLogDir.GetFiles("*.binlog");

        public override string ToString()
            => join(eol(), ComponentAssemblies);
    }
}