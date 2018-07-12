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
    using System.ComponentModel;
    using System.Reflection;
    using Meta.Core;

    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Workflow;
    using SqlT.CSharp;

    using MetaFlow.Core;
    using MetaFlow.WF;

    using Z0 = SqlT.Proxies.Z0;
    using WS = MetaFlow.Proxies.WS;
    using N = SystemNode;
    using Sql = SqlT.Store;

    using static metacore;
    using static StatusMessages;
    
    public abstract class PlatformSession : LinkedSqlSession<PlatformSession>, ILinkedShellSession
    {
        Variance DefaultVariance { get; set; }

        protected Lazy<NodeFileSystem> _NFS { get; }

        protected ISqlConnector Connectors { get; }

        protected ISystemReflector Reflector { get; }

        protected ISystemContext SystemContext { get; }

        protected N Host { get; }

        protected IPlatformDistributor Distributor
            => C.SourceContext.Distributor();

        protected ISqlTypeTableManager TypeTableManager
            => C.SqlTypeTableManager();

        protected IIconStore IconStore
            => C.IconStore();

        protected IProxyServices ProxyServices
            => C.PlatformProxyServices();

        protected IPlatformDacServices DacServices
            => C.NodeContext(C.SourceNode).PlatformDacServices();

        protected IPlatformBuildService BuildService
            => C.PlatformBuildService();

        protected IDistributionLibrary DistLib
            =>new  DistributionLibrary(C, PlatformVariables.DistRootDir, PlatformVariables.DistArchiveDir);

        protected ISqlProxyGenerator ProxyGenerator
            => C.CSharpProxyGenerator();

        protected IPlatformCatalog Catalog
            => C.PlatformCatalog();

        protected Variance variance(char c)
        {
            switch (c)
            {
                case 's': return Variance.Covariant;
                case 't': return Variance.Contravariant;
                default:
                    return Variance.None;
            }
        }

        protected IPlatformServiceProvider Services
            => C.HostContext().PlatformServices();

        ISqlHostServices SourceHostServices
            => C.SourceContext.SqlHostServices();

        ISqlHostServices TargetHostServices
            => C.TargetContext.SqlHostServices();

        protected Option<IJobScheduler> JobScheduler
            => C.Scheduler().StartIfNotRunning();

        protected ISystemCommandWorkflow CommandWorkflow { get; }

        protected ISystemWorkflowServices WorkflowServices
            => CommandWorkflow.WorkflowServices;

        protected IMetaBuild MetaBuild
            => C.MetaBuild();

        protected SystemIdentifier system(string SysId)
            => new PlatformSystems().Single(sys => sys.Identifier == SysId);

        private void SubscribeConnectionEvents()
        {
            SourceNodeConnected += OnSourceNodeConnected;
            SourceDbConnected += OnSourceDbConnected;

            TargetNodeConnected += OnTargetNodeConnected;
            TargetDbConnected += OnTargetDbConnected;
        }

        PlatformSession(ILinkedContext C, SqlDatabaseName Db)
            : base(C, link(Db,Db))
        {
            Host = N.Local;
            SubscribeConnectionEvents();
            _NFS = defer(() => C.NFS());
            Connectors = C.SqlConnector();
            Reflector = C.SystemReflector();
            DefaultVariance = Variance.Contravariant;
            SystemContext = C.NodeContext(Host).SystemContext(ExecutingSystem);            
            CommandWorkflow = SystemContext.CommandWorkflow();
        
        }

        protected PlatformSession(ILinkedContext C, PlatformDatabaseKind DatabaseType)
            : this(C, C.SqlConnector().PlatformDatabase(C.SourceNode, DatabaseType).Name)
        {
        }


        protected PlatformSession(IApplicationContext C, PlatformDatabaseKind DatabaseType)
            : this(new LinkedContext(C, N.Local.LinkToSelf()), DatabaseType)
        {

        }

        void OnSourceDbConnected(SqlDatabaseName Source)
        { }

        void OnSourceNodeConnected(N Source)
        {

        }

        void OnTargetDbConnected(SqlDatabaseName Target)
        { }

        void OnTargetNodeConnected(N Source)
        {

        }

        protected ISystemMessaging Messaging
            => C.HostContext().Service<ISystemMessaging>();


        protected NodeFolderPath AreaFolder(FolderName AreaName)
            => CommonFolders.DevAreaRoot + AreaName;

        protected Option<SystemTaskDefinition> DefineTask<K>(K Command, CorrelationToken? CT = null)
           where K : class, ISystemCommand, ISqlTableTypeProxy, new()
            => CommandWorkflow.DefineTask(Command, CT ?? CorrelationToken.Create())
                        .OnNone(Notify)
                        .OnSome(task => Notify(DefinedTask(task)));

        protected override SqlUserCredentials SqlCredentials(SystemNodeIdentifier SqlNodeId)
            => C.SqlConnector().UserCredentials(SqlNodeId);

        protected INodeConfiguration Configuration(N Host)
            => C.NodeContext(Host).PlatformConfiguration();

        protected SqlFileOps FileOps
            => new SqlFileOps(SqlContext);

        protected NodeFileSystem NFS
            => _NFS.Value;

        protected override IReadOnlyList<N> AvailableNodes
            => rolist(from s in SqlNodes
                    let n = s.ToSystemNode()
                    where n.IsSome()
                    select n.Require());

        protected IEnumerable<SqlDatabaseServer> SqlNodes
            => Connectors.SqlNodes;

        protected SystemIdentifier ExecutingSystem
            => GetType().Assembly.DefiningSystem();

        protected N Who(Variance Actor)
            => Actor == Variance.Contravariant ? TargetNode : SourceNode;


        void Print(Variance Actor, IEnumerable<Sql.DirResult> items)
            => iter(items,
                item => Print(concat(
                    Who(Actor).NodeIdentifier,
                    tab(),
                    item.FilePath,
                    tab(),
                    toString(item.Size))
                    )
                );

        public void SourceFiles(string SourcePath)
            => PrintSequence(FileOps.SourceFiles(SourcePath));

        public void CopyLocalFolder(string SrcPath, string DstPath)
            => FileOps.CopySourceFile(SrcPath, DstPath);


        protected Option<Y> Evaluate<X, Y>(Option<X> src, Func<X, Y> evaluator)
            => src.Map(x => evaluator(x));

        protected Option<Y> Evaluate<X, Y>(SqlOutcome<X> src, Func<X, Y> evaluator)
            => Evaluate(src.ToOption(), evaluator);


        protected ISqlProxyBroker Z0Source
            => Z0Broker(SqlContext.SourceContext.Host, SqlContext.SourceContext.DatabaseName);

        protected ISqlProxyBroker Z0Target
            => Z0Broker(SqlContext.TargetContext.Host, SqlContext.TargetContext.DatabaseName);

        protected Option<IReadOnlyList<Z0.TableStatsRecord>> SourceTableStats()
            => Z0Source.Get(new Z0.GetTableStats());

        protected Option<IReadOnlyList<Z0.TableStatsRecord>> SourceTableStats(SqlDatabaseName DbName)
            => z0(SourceNode, DbName).Get(new Z0.GetTableStats());


        protected Option<IReadOnlyList<Z0.TableStatsRecord>> TargetTableStats()
            => Z0Target.Get(new Z0.GetTableStats());

        protected Option<IReadOnlyList<Z0.TableStatsRecord>> TargetTableStats(SqlDatabaseName DbName)
            => z0(TargetNode, DbName).Get(new Z0.GetTableStats());

        ISqlProxyBroker z0(N Host, SqlDatabaseName DbName)
            => SqlTZ0.Broker(Connectors.Connection(Host, DbName).Require());

        IReadOnlyList<P> z0<P>(N Host, SqlDatabaseName db)
            where P : class, ISqlTabularProxy, new()
                => z0(Host, db).Get<P>().OnNone(Notify).Items();

        protected ISqlProxyBroker WsBroker(N Host)
            => MetaFlowWorkspaceProxies.Broker(C.SqlConnector(Host ?? N.Local,
                    Core.PlatformDatabaseKind.WS).Require());

        protected WS.IWorkspaceOps WsOps(N Host)
          => ~WsBroker(Host ?? N.Local).Operations<WS.IWorkspaceOps>();

        protected ISqlProxyBroker SqlBroker<A>(N Host, SqlDatabaseName Db)
            where A : class, ISqlProxyAssembly, new()
                => new A().CreateBroker(Connectors.Connection(Host, Db).Require());

        protected ISqlProxyBroker SourceBroker<A>()
            where A : class, ISqlProxyAssembly, new()
                => new A().CreateBroker(SourceConnector);

        protected ISqlProxyBroker TargetBroker<A>()
            where A : class, ISqlProxyAssembly, new()
                => new A().CreateBroker(TargetConnector);

        protected ISqlProxyBroker Z0Broker(N Host, SqlDatabaseName Db)
            => SqlBroker<SqlTZ0>(Host, Db);

        protected ISqlProxyBroker PlatformBroker(SqlDatabaseServer Server)
            => MetaFlowCoreStorage.Broker(
                C.SqlConnector(Server, PlatformDatabaseKind.MetaFlow).OnNone(
                    () => Notify(error($"Platform connection to {Server} not found"))).ValueOrDefault());

        protected ISqlProxyBroker PlatformBroker(N Host)
            => MetaFlowCoreStorage.Broker(
                C.SqlConnector(Host, PlatformDatabaseKind.MetaFlow).OnNone(
                    () => Notify(error($"Platform connection to {Host} not found"))).ValueOrDefault());

        protected string ScriptName
            => GetType().Name;

        protected virtual void Exec()
        {
        }

        protected Option<SqlScript> LoadResourceScript(string name, object parameters = null)
            => SqlScript.FromResources(Assembly.GetExecutingAssembly(), name, parameters);

        protected Option<SqlScript> ExecuteScript(SqlScript Script, string TargetDbName)
        {
            var sqlctx = C.SourceContext.SqlContext(TargetConnector.ChangeDatabase(TargetDbName));
            return from s in sqlctx.ExecuteBatchScript(Script)
                   select Script;
        }

        protected Option<SqlScript> ExecuteResourceScript(string ScriptName, string TargetDbName)
            => from script in LoadResourceScript(ScriptName)
               from result in ExecuteScript(script, TargetDbName)
               select result;

        public void installZ0(string targetDb)
            => ExecuteResourceScript("Z0.sql", targetDb)
                .OnNone(Notify).OnSome(_ => Notify(inform("Installed Z0.sql")));

        protected SqlConnectionString SourceConnector
            => SqlContext.SourceContext.SqlConnector;

        protected SqlConnectionString TargetConnector
            => SqlContext.TargetContext.SqlConnector;

        protected Option<int> CopyFile(FilePath SrcPath, FilePath DstPath)
            => FileOps.CopyFile(SrcPath, DstPath);

        protected IEnumerable<FilePath> SourceFiles(FolderPath SrcFolder)
            => FileOps.SourceFiles(SrcFolder);

        protected IEnumerable<FilePath> HostFiles(N Host, FolderPath SrcFolder)
            => FileOps.HostFiles(Host, SrcFolder);

        protected IEnumerable<FolderPath> Drives(N Host)
            => FileOps.Drives(Host);


        protected void PrintHostFiles(N n, string SrcFolder)
            => PrintSequence(HostFiles(node(n), SrcFolder));

        protected void LocalDir(string Host, string SrcPath)
            => ProcessItems(FileOps.Dir(node(Host), SrcPath),
                d => NotifyStatus(d.FilePath
                    + (d.IsDirectory == true ? " (Folder)" : " (File)")));

        protected void CopyLocalFolder(string Host, string SrcPath, string DstPath)
            => Process(FileOps.CopyFolder(SrcPath, DstPath),
                result => { }, () => AppMessage.Inform(($"Copying {SrcPath} to {DstPath}")));

        protected override SqlUserCredentials SqlNodeCredentials(N Host)
            => C.SqlConnect().UserCredentials(Host);


        public IEnumerable<SqlXEventFileLog> Collected(N SrcNode, N DstNode)
            => from f in NFS.LogCollectionFolder(SrcNode, DstNode).GetFiles()
               select new SqlXEventFileLog(f);

        public IEnumerable<Option<SqlXEventFileLog>> PullXEventLogs(N SrcNode, N DstNode)
            => from f in NFS.XEventLogs(SrcNode).XEventLogs
               let dstFolder = NFS.LogCollectionFolder(SrcNode, DstNode)
               let logFile = f.AbsolutePath.CopyTo(dstFolder)
               select logFile.Succeeded
                ? some(new SqlXEventFileLog(logFile.DstPath)).WithMessage(value => inform($"Collected {value} "))
                : none<SqlXEventFileLog>(logFile.Message);

        public void CollectHostLogs(string Host)
        {
            iter(PullXEventLogs(node(Host), ExecutingNode),
                f => f.OnNone(Notify).OnSome(l => Notify(inform($"Collected {l.Path} from {Host}"))));
        }

        protected void DsInDir(N Host)
        {
            var folder = NFS.DSNav(Host).IncomingFolder;
            Print(folder);
            iter(folder.Files(), Print);
        }

        protected void DsOutDir(N Host)
        {
            var folder = NFS.DSNav(Host).OutgoingFolder;
            Print(folder);
            iter(folder.Files(), Print);
        }

        Option<Link<NodeFilePath>> CopyDataset(NodeFilePath SrcPath, N DstNode)
            => SrcPath.CopyTo(NFS.DSNav(DstNode).IncomingFolder + SrcPath.FileName);

        protected IReadOnlyList<R> FromZ0Source<F, R>(F f)
            where F : SqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Z0Source.Get(f).OnNone(Notify).Items();

        protected IReadOnlyList<R> FromZ0Target<F, R>(F f)
            where F : SqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => Z0Source.Get(f).OnNone(Notify).Items();

        protected void Drives(Variance Role)
            => PrintSequence(Role.IsTarget() ? Drives(TargetNode) : Drives(SourceNode));

        protected ISqlDatabaseRuntime DbRuntime(Variance Role)
            => Role == Variance.Contravariant
            ? TargetDbRuntime
            : SourceDbRuntime;

        protected ISqlServerRuntime Server(Variance Role)
            => Role == Variance.Contravariant
            ? TargetServer
            : SourceServer;

        protected void StartBackup(Variance Role, SqlDatabaseName DbName, FilePath DstPath)
            => Server(Role).BackupAsync(DbName, DstPath, notification
                   => Notify(notification.ToApplicationMessage()))
                            .ContinueWith(outcome => outcome.Result.OnNone(Notify)
                                    .OnSome(_ => Notify(inform("Completed backup"))));

        protected Option<SqlDatabaseServer> SqlNode(SystemNodeIdentifier SqlNodeId)
            => SqlNodes.TryGetSingle(n => n.NodeIdentifier == SqlNodeId);

        protected void Print(N node)
            => Print($"{node.NodeIdentifier}::{node.NodeName} {node.NodeServer} {node.ExternalIP}"
                        + node.Port.MapValueOrDefault(port => "," + port.ToString(), string.Empty));

        FolderName ShellLibFolder
            => FolderName.Parse("lib\\metaflow");

        FolderName ShellProxyFolder
            => FolderName.Parse("lib\\metaflow-proxies");

        protected void SendAssembly(Assembly a, NodeFolderPath DstFolder)
        {
            var srcPath = FilePath.Parse(a.Location);
            var dstPath = DstFolder + srcPath.FileName;
            srcPath.CopyTo(dstPath).OnSome(path => Notify(inform($"Copied proxy assembly to {path}"))).OnNone(Notify);
        }

        protected void SendProxyAssembly(Assembly a, N DstNode)
            => SendAssembly(a, NFS.OpsNav(DstNode).ShellFolder + ShellProxyFolder);

        protected void SendLibraryAssembly(Assembly a, N DstNode)
            => SendAssembly(a, NFS.OpsNav(DstNode).ShellFolder + ShellLibFolder);

        protected void SendShellAssembly(Assembly a, N DstNode)
        {
            var assemblyPath = FilePath.Parse(a.Location);
            var srcExeFolder = assemblyPath.Folder;
            var dstExeFolder = NFS.OpsNav(DstNode).ShellFolder;
            var dstExePath = dstExeFolder + assemblyPath.FileName;
            assemblyPath.CopyTo(dstExePath).OnSome(path => Notify(inform($"Copied shell assembly to {path}"))).OnNone(Notify);

        }

        protected void SendProxiesThere(ISystemOperationsProvider OperationsProvider, N DstNode)
            => iter(OperationsProvider.LoadedComponents.Where(c => c.IsProxyAssembly()), c => SendProxyAssembly(c, DstNode));

        protected void SendLibrariesThere(ISystemOperationsProvider OperationsProvider, N DstNode)
            => iter(OperationsProvider.LoadedComponents.Where(c => not(c.IsProxyAssembly())), c => SendLibraryAssembly(c, DstNode));

        protected void SendMeThere(ISystemOperationsProvider OperationsProvider, N DstNode)
        {
            SendShellAssembly(Assembly.GetEntryAssembly(), DstNode);
            SendLibrariesThere(OperationsProvider, DstNode);
            SendProxiesThere(OperationsProvider, DstNode);
        }

        protected void ListDatabases(Variance v)
        {
            if (v == Variance.Contravariant)
                iter(TargetDbRuntime.Server.DatabaseCatalog, db => Print($"{TargetNode.NodeIdentifier}/{db}"));
            else
                iter(SourceDbRuntime.Server.DatabaseCatalog, db => Print($"{SourceNode.NodeIdentifier}/{db}"));

        }

        PlatformDatabaseKind RequireDbType(string DbTypeName)
            => parseEnum<PlatformDatabaseKind>(DbTypeName);

        protected Option<PlatformDatabaseKind> ParseDbType(string DbTypeName)
        {
            try
            {
                return RequireDbType(DbTypeName);
            }
            catch (Exception e)
            {
                return none<PlatformDatabaseKind>(e);
            }
        }


        protected ISystemOperationsProvider OperationsProvider
            => Reflector.OperationProviders.Where(
                p => p.DefiningSystem == ExecutingSystem
                ).Single();

        protected IEnumerable<ComponentDescriptor> Components()
            => from c in Reflector.ComponentDescriptions
               orderby c.SystemId.IdentifierText
               orderby c.Classification
               select c;

        protected IEnumerable<ComponentDescriptor> Components(ComponentClassification @class)
            => from c in Components()
               where c.Classification == @class
               select c;

        protected IEnumerable<ComponentDescriptor> Metamodels
            => Components(ComponentClassification.Metamodel);

        protected IEnumerable<ComponentDescriptor> Proxies
            => Components(ComponentClassification.DataProxy);

        protected ISqlDatabaseRuntime SourceDb(PlatformDatabaseKind DbType)
            => SourceServer.Database(Connectors.PlatformDatabase(SourceNode, DbType).Name);

        protected ISqlDatabaseRuntime TargetDb(PlatformDatabaseKind DbType)
            => TargetServer.Database(Connectors.PlatformDatabase(TargetNode, DbType).Name);

        Option<Link<NodeFilePath>> SendShell(N DstNode)
        {
            var self = new NodeFilePath(Host, Assembly.GetEntryAssembly().Location);
            var srcExeFolder = self.Folder;
            var dstExeFolder = NFS.OpsNav(node(DstNode)).ShellFolder;
            var dstExePath = dstExeFolder + self.FileName;
            return self.CopyTo(dstExePath).OnSome(path => Notify(inform($"Copied shell to {path}"))).OnNone(Notify);

        }

        protected SystemIdentifier DefiningSystem
            => DefiningAssembly.DesignatedModule.DefiningSystem();


        protected INodeContext HostContext
            => C.NodeContext(ExecutingNode);


        protected static Json ToJson<P>(P proxy)
            where P : class, ISqlTabularProxy, new()
                => proxy.ToJson();

        protected void PrintJson<P>(P proxy)
            where P : class, ISqlTabularProxy, new()
                => Print(proxy.ToJson());


        [ShellCommand, Description("Emits the identifier of the executing system")]
        public void system()
        {
            Print(DefiningSystem);
        }

        [ShellCommand, Description("Copies the executing shell to a specified node")]
        public void sendShell(string DstNode)
            => SendShell(node(DstNode));

        [ShellCommand, Description("Copies the system libraries to a specified node")]
        public void sendLibraries(string DstNode)
        {
            if (OperationsProvider != null)
                SendLibrariesThere(OperationsProvider, node(DstNode));
            else
                NotifyError("No operations provider has been specified");
        }

        [ShellCommand, Description("Copies the system proxies to a specified node")]
        public void sendProxies(string DstNode)
        {
            if (OperationsProvider != null)
                SendProxiesThere(OperationsProvider, node(DstNode));
            else
                NotifyError("No operations provider has been specified");
        }

        [ShellCommand, Description("Copies system components to specified node")]
        public void sendMeThere(string DstNode)
        {
            if (OperationsProvider != null)
                SendMeThere(OperationsProvider, node(DstNode));
            else
                NotifyError("No operations provider has been specified");
        }

        [ShellCommand, Description("Enumerates session objects defined within the current scope")]
        public void scoped()
            => iter(SqlNodes, Print);      
        
        
        
        [ShellCommand, Description("Initiates source db backup to supplied path")]
        public void backupToPath(string DstPath)
            => StartBackup(Variance.Covariant, SourceDbName, DstPath);

        [ShellCommand, Description("Enumerates services available to the context")]
        public void services()
        {
            var descriptions = C.ProvidedServices.Select(x => 
                (
                    Name: x.Contracts.First().DisplayName(), 
                    Imp: x.ImplementationName)
                ).OrderBy(x => x.Name);

            iteri(descriptions, (i, description) => Print($"{i.ToString().PadLeft(3,'0')} {description.Name}({description.Imp})"));
        }

        [ShellCommand, Description("Sets the value of a system environment variable")]
        public void setVar(string name, string value)
            => TargetHostServices.SetNodeVariable(name, value).OnSome(_ => vars()).OnNone(Notify);
        
        [ShellCommand, Description("Enumerates the environment variables defined by the target")]
        public void vars()
            => iter(TargetHostServices.NodeVariables, Print);
        
        [ShellCommand, Description("Retrieves an identified SQL Node")]
        public void sqlnode(string id)
            => SqlNode(id).OnSome(Print).OnNone(() => Print($"The node {id} was not found"));
       
        [ShellCommand, Description("Enumerates Sql nodes available from the current scope")]
        public void sqlnodes()
            => iter(SqlNodes, Print);
        
        [ShellCommand, Description("Enumerates the contents of a specified directory")]
        public void sqldir(string SrcPath)
        {
            Print(Variance.Covariant, FileOps.LocalSourceDir(SrcPath));
            if (SourceNode != TargetNode)
                Print(Variance.Contravariant, FileOps.LocalTargetDir(SrcPath));
        }

        [ShellCommand, Description("Brings a specified source database into scope")]
        public void useSourceType(string SrcDbType)
            => Connectors.Connection(SourceNode,
                    RequireDbType(SrcDbType))
                        .OnSome(cs => UseSource(cs.DatabaseName))
                        .OnNone(() => Notify(error($"{SrcDbType} not found")));
        
        [ShellCommand, Description("Brings a specified target database into scope")]
        public void useTargetType(string DstDbType)
            => Connectors.Connection(TargetNode,
                    RequireDbType(DstDbType))
                        .OnSome(cs => UseTarget(cs.DatabaseName))
                        .OnNone(() => Notify(error($"{DstDbType} not found")));

        [ShellCommand, Description("Brings source/target databases into scope")]
        public void usetypes(string SrcDbType, string DstDbType)
        {
            useSourceType(SrcDbType);
            useTargetType(DstDbType);
        }

        [ShellCommand, Description("Emits the default session variance")]
        public void variance()
            => Print(DefaultVariance);

        [ShellCommand, Description("Sets the default session variance")]
        public void setVariance(char v)
        {
            var desiredVariance = variance(v);
            if (DefaultVariance == desiredVariance)
                Print($"The session variance default is already {desiredVariance}");
            else
            {                
                Print($"Default session variance changed to {desiredVariance}");
            }
        }


        [ShellCommand, Description("Emits the system for which the session has been instantiated")]
        public void executingSystem()
            => Print(ExecutingSystem);

        [ShellCommand, Description("Lists the databases provied by the source")]
        public void databases()
        {
            ListDatabases(Variance.Covariant);
            
        }

        [ShellCommand, Description("Enumerates the platform databases on a specified node")]
        public void platformDb(string SqlNodeId)
            => iter(Connectors.PlatformDatabases(SqlNodeId), Print);

        [ShellCommand, Description("Enumerates the solutions that define the system")]
        public void solutions()
            => iter(Reflector.PlatformSolutions, Print);

        [ShellCommand, Description("Enumerates the projects that define the system")]
        public void projects()
            => iter(Reflector.PlatformProjects, project => Print(project.Format()));

        [ShellCommand, Description("Emits the list of outgoing and incoming datasets on respective source and taret nodes")]
        public void datasets()
        {
            DsOutDir(SourceNode);
            if (SourceNode != TargetNode)
                DsInDir(TargetNode);
        }

        [ShellCommand, Description("Lists the drives mounted on the source and target nodes")]
        public void drives()
        {
            iter(Drives(SourceNode), drive => Print($"{SourceNode.NodeIdentifier}\t{drive}"));
            if (SourceNode != TargetNode)
                iter(Drives(TargetNode), drive => Print($"{TargetNode.NodeIdentifier}\t{drive}"));
        }

        [ShellCommand, Description("Lists the contents of the outgoing dataset share on the source")]
        public void dsOutDir()
            => DsOutDir(SourceNode);

        [ShellCommand, Description("Emits the contents of the incoming dataset share on the target")]
        public void dsInDir()
            => DsInDir(TargetNode);

        [ShellCommand, Description("Emits the names of the dataflows available in the current context")]
        public void dataflows()
            => PrintSequence(Reflector.DataFlows);

        [ShellCommand, Description("Emits the extended properties defined by the source and target databases")]
        public void dbprops()
        {
            var srcProps = list(SourceDbRuntime.ExtendedProperties);
            if (srcProps.Count != 0)
            {
                Print(SourceDbName);
                iter(srcProps, prop =>  Print($"{SourceDbName}, {prop}"));
            }
            else
                Print($"The source database {SourceDbName} defines no extended properties");

            var dstProps = list(TargetDbRuntime.ExtendedProperties);
            if (dstProps.Count != 0)
            {
                Print(TargetDbName);
                iter(dstProps, Print);
            }
            else
                Print($"The target database {TargetDbName} defines no extended properties");

        }


        [ShellCommand, Description("Enumerates known metamodels")]
        public void metamodels()
            => iter(Metamodels, Print);

        [ShellCommand, Description("Enumerates all known components")]
        public void components()
            => iter(Components(), Print);

        [ShellCommand, Description("Enumerates known proxy components")]
        public void proxies()
            => iter(Proxies, Print);

        [ShellCommand, Description("Enumerates the defined platform systems")]
        public void systems()
            => iter(Reflector.Systems, Print);
        
        [ShellCommand, Description("Enumerates operation providers that are in-scope")]
        public void opProviders()
            => iter(Reflector.OperationProviders, Print);

        [ShellCommand, Description("Enumerates knon distributions")]
        public void distributions()
        {
            iter(Reflector.Distributions, Print);
        }

        [ShellCommand,Description("Copies a dataset from the source to the target")]
        public void dspub(string SrcFileName)
            => NFS.DSNav(SourceNode).OutgoingFile(SrcFileName)
                        .Map(SrcPath => CopyDataset(SrcPath, TargetNode))
                        .OnNone(Notify)
                        .OnSome(result => Notify(inform($"Copied {result}")));
        
        [ShellCommand, Description("Executes an identified workflow")]
        public void flow(string uri)
        {
            var sysUri = SystemUri.Parse(uri);
            var arg = sysUri.Query.Criteria.FirstOrDefault();
            var args = arg == null ? SqlDataFlowArgs.Empty : new SqlDataFlowArgs(parse<int>(arg.Value));
            Notify(inform($"Executing {sysUri} with batch size {args.BatchSize}"));
          
           
            C.PlatformDataFlows().CreateDataFlow(SourceNode.LinkTo(TargetNode), sysUri)
                        .OnNone(Notify)
                        .OnSome(wf => wf.Execute(args));           
        }        

        [ShellCommand, Description("Enumerates the schemas defined by the database in scope")]
        public void schemas()
            => iter(DbRuntime(DefaultVariance).Schemas, s => Print(s.ElementName));

        [ShellCommand, Description("Enumerates system SQL packages")]
        public void sqldacs()
            => iter(Reflector.PlatformDacs, Print);
                 
        public void extract()
        {
            var commands = map(NFS.PlatformNav(SourceNode).BackupArchives,
                srcpath => new C0.ExtractArchive
                (
                      Host.NodeIdentifier,
                      srcpath.AbsolutePath,
                      NFS.PlatformNav(TargetNode).BackupFolder.AbsolutePath
                ));
            iter(commands, command => Messaging.SubmitCommand(command));
        }

        public void describeBackups()
        {
            var commands = map(NFS.PlatformNav(SourceNode).PublishedBackups,
                    srcpath => new C0.DescribeBackup
                    (
                        Host.NodeIdentifier,
                        Host.NodeIdentifier,
                        srcpath.AbsolutePath
                    ));
            var ct = CorrelationToken.Create();
            iter(commands, command => Messaging.SubmitCommand(command,ct));
        }

        [ShellCommand, Description("Enumerates available task handlers")]
        public void handlers()
            => iter(Reflector.SystemTaskHandlers, 
                h => iter(h.SupportedCommands, c => Print($"{c}->{h}")));

        [ShellCommand, Description("Enumerates system event reactors")]
        public void reactors()
        {
            iter(Reflector.SystemEventReactors,
                r => iter(r.SupportedEvents, e => Print($"{e}->{r}")));
        }

        public void dacAssemblies()
        {
            iter(Reflector.DacAssemblies, a => Print($"{a.Name}, {a.ReflectedElement.GetName().Version}"));
        }

        public void messages()
        {
            
            var connection = PlatformNotificationHubConnection.Create(notification => SystemConsole.Get().WriteLine(notification.Format()));

        }
    }

    public class PlatformSession<A> : PlatformSession
        where A : class, ISqlProxyAssembly, new()
    {

        public PlatformSession(ILinkedContext L, PlatformDatabaseKind DbType)
            : base(L, DbType)
        {

        }

        protected ISqlProxyChannel Channel
            => new SqlProxyChannel(C, SourceBroker, TargetBroker);

        protected IEnumerable<T> Pull<T>()
            where T : class, ISqlTabularProxy, new()
                => SourceBroker.Stream<T>();

        protected IEnumerable<R> Pull<F, R>(ISqlTableFunctionProxy<F,R> f)
            where F : class, ISqlTableFunctionProxy<F,R>, new()
            where R : class, ISqlTabularProxy, new()
                => SourceBroker.Stream<F, R>((F)f);

        protected void Push<T>(IEnumerable<T> items, int? timeout = null, int? batchSize = null)
            where T : class, ISqlTabularProxy, new()
                => TargetBroker.Save<T>(items, 
                    new SqlSaveOptions(timeout, batchSize), 
                        savedCount => Notify(inform($"Saved {savedCount} {PXM.TabularName<T>()} records")));

        protected ISqlProxyBroker SourceBroker
            => new A().CreateBroker(SourceConnector, OnSqlNotification);

        protected ISqlProxyBroker TargetBroker
            => new A().CreateBroker(TargetConnector, OnSqlNotification);

        protected O SourceOps<O>()
            => SourceBroker.Operations<O>().Require();

        protected O TargetOps<O>()
            => TargetBroker.Operations<O>().Require();

        protected Option<int> SourceExec<P>(P proc = null)
            where P : class, ISqlProcedureProxy, new()
            => SourceBroker.Call(proc ?? new P(), Notify);

        protected Option<int> TargetExec<P>(P proc = null)
              where P : class, ISqlProcedureProxy, new()
            => TargetBroker.Call(proc ?? new P(), Notify);

        protected Option<IReadOnlyList<R>> FromTarget<F, R>(ISqlTableFunctionProxy<F, R> f)
            where F : SqlTableFunctionProxy<F, R>, new()
            where R : class, ISqlTabularProxy, new()
                => TargetBroker.Get((F)f);
    }
}