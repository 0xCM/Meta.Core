//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.MF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.CSharp;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Types;
    using SqlT.Workflow;
    
    using MetaFlow.Core;
    using MetaFlow.Core.Storage;
    

    using sx = SqlT.Syntax.SqlSyntax;
    using DistId = DistributionIdentifier;

    using static metacore;

    public class PlatformDistributions
    {
        public static readonly DistId MetaFlowExe = "metaflow-exe";
        public static readonly DistId MetaFlowLib = "metaflow-lib";
        public static readonly DistId MetaFlowProxy = "metaflow-proxies";
        public static readonly DistId MetaFlowSql = "metaflow-sql";

    }

    [ShellCommandHost]
    public class PlatformManager : PlatformSession<MetaFlowCoreStorage>
    {

        public static FolderPath SolutionFolder(SystemIdentifier SysId)
            => PlatformVariables.DevAreaDir + FolderName.Parse(SysId);

        public PlatformManager(ILinkedContext C)
            : base(C, PlatformDatabaseKind.MetaFlow)
        {
            
        }
       
        Option<Link<DistributionIdentifier, FilePath>> Archive(DistributionIdentifier DistId)
            => from icopath in some(link(IconIdentifier.dist_archive,DistLib.DistArchive + IconFileName))
               from extract in IconStore.ExtractIcon(icopath)
               from assign in DistLib.DistArchive.AssignIcon(icopath.Target)
               from archive in DistLib.Archive(DistId)
               select archive;

        Option<int> UnpackDistribution()
        {
            var archive = NFS.OpsNav(Host).DistributionArchives.OrderBy(x => x.CreatedTS).LastOrDefault();
            if (isNull(archive))
                return none<int>(error("No archives exist"));

            var dstFolder = NFS.OpsNav(Host).AssetNav.DistFolder(PlatformDistributions.MetaFlowExe);
            return C.FileArchiveManager().ExpandArchive(archive, dstFolder)
                    .OnNone(Notify)
                    .OnSome(files => Notify(inform($"Extracted {files.Target.Count} files")))
                    .Map(x => x.Target.Count);                                
        }

        Option<int> SyncHostCatalogs()
        {           
            var idx = GetHostDatabases(TargetNode).Require().ToDictionary(c => c.DatabaseName);
            var dbNames = TargetServer.DatabaseCatalog.Select(n => n.Name) ;

            var updates = MutableList.Create<PlatformDatabase>();
            foreach(var dbName in dbNames)
            {
                var current = idx.TryFind(dbName);

                var update = new PlatformDatabase
                    (
                        ServerId: TargetNode.NodeIdentifier,
                        DatabaseName: dbName,
                        DatabaseType: current.MapValueOrDefault(c => c.DatabaseType, "None"),
                        IsEnabled: current.MapValueOrDefault(c => c.IsEnabled, true),
                        IsModel: current.MapValueOrDefault(c => c.IsModel, false),
                        IsPrimary: current.MapValueOrDefault(c => c.IsPrimary, true),
                        IsRestore: current.MapValueOrDefault(c => c.IsRestore, false)
                       );
                updates.Add(update);
            }

            return TargetBroker.Call(new SyncHostDatabases(updates)).ToOption()
                        .OnSome(_ => Notify(inform($"Synchronized {updates.Count} databases in the {TargetNode} catalog")))
                        .OnNone(Notify);
        }

        public void collectCatalogs()
        {
            var updates = MutableList.Create<PlatformDatabase>();

            foreach (var node in SqlNodes)
                updates.AddRange(GetHostDatabases(node).OnNone(Notify).Items());

            PlatformBroker(TargetNode).Call(new SyncPlatformDatabases(updates)).Require();
        }

        Option<IReadOnlyList<PlatformDatabase>> GetHostDatabases(SqlDatabaseServer Server)
            => PlatformBroker(Server).Get(new PlatformDatabases(Server.NodeIdentifier));

        Option<IReadOnlyList<PlatformDatabase>> GetHostDatabases(SystemNode Host)
            => PlatformBroker(Host).Get(new PlatformDatabases(Host.NodeIdentifier));

        Option<int> SyncPlatformDatabases(bool PLL)
        {
            ConcurrentSet<PlatformDatabase> databases = new ConcurrentSet<PlatformDatabase>();
            iter(SqlNodes,
                host => GetHostDatabases(host).
                OnSome(payload => Notify(inform($"Pulled {payload.Count} platform database entries from {host}"))).
                OnSome(payload => databases.AddRange(payload)).OnNone(Notify));
            return TargetBroker.Call(new SyncPlatformDatabases(databases));
        }
               
        Option<int> SyncDbServers()
            => from nodes in SourceBroker.Get(new PlatformServers())
               from servers in SourceBroker.Get(new DatabaseServers())
               from result1 in TargetBroker.Exec(new SyncPlatformServerRegistry(nodes))
               from result2 in TargetBroker.Exec(new SyncDatabaseServers(servers))
               select result1 + result2;

        Version PlatformVersion
            => Assembly.GetEntryAssembly().GetName().Version;

        static FileName IconFileName
            => "folder.ico";

        Option<NodeFilePath> Build()
            => from result in BuildService.BuildPlatform().ToOption()
               from distribution in Distributor.CreateDistribution(PlatformDistributions.MetaFlowExe)
               from localRelease in distribution.CopyTo(NFS.PlatformNav(Host).ReleaseFolder)
               select localRelease.Target;
               
        public void schedule()
        {
            Option<TimeSpan> TickTocker()
            {
                Notify(inform("Tick/Tock"));

                return TimeSpan.FromSeconds(10);
            }

            JobScheduler.OnSome(scheduler =>
                scheduler.ScheduleJob(new ScheduledJob(nameof(TickTocker), TickTocker)));
        }

        [ShellCommand, Description("Publishes most recent distribution to an identified node")]
        public void releaseTo(string DstNode)
            => Distributor.ReleaseTo(PlatformDistributions.MetaFlowExe, node(DstNode))
                        .OnNone(Notify)
                        .OnSome(dstPath => Notify(inform($"Transmitted distribution to {dstPath}")));

        [ShellCommand, Description("Publishes most recent distribution to an identified node")]
        public void compressTo(string DistId, string nodeId)
            => Distributor.CompressTo(DistId, node(nodeId))
                        .OnNone(Notify)
                        .OnSome(delivery => Notify(inform($"Transmitted {DistId} archive to {delivery.AbsolutePath}")));

        [ShellCommand, Description("Publishes most recent distribution to the release platform folder")]
        public void release(string DistId)
            => Distributor.ReleaseTo(DistId, TargetNode)
                        .OnNone(Notify)
                        .OnSome(delivery => Notify(inform($"Transmitted {DistId} archive to {delivery.AbsolutePath}")));

        

        [ShellCommand, Description("Enumerates agents known to the context")]
        public void agents()
        {
            PrintSequence(Reflector.PlatformAgents);
        }
                           

        [ShellCommand, Description("Synchronizes target runtime and persistent metadata stores")]
        public void sync()
        {
            C.PlatformDataFlows().FromType<PlatformSync>(SourceNode.LinkTo(TargetNode)).OnNone(Notify).OnSome(f => f.Execute(new SqlDataFlowArgs()));

        }

        [ShellCommand, Description("Synchronizes global runtime and persistent metadata stores")]
        public void syncG(bool PLL)
        {
            SyncPlatformDatabases(PLL).OnNone(Notify).OnSome(_ => Notify(inform("Success")));
        }
       
        [ShellCommand, Description("Synchronizes target server catalog with that of the source")]
        public void syncServerCatalog()
        {
            if (SourceNode != TargetNode)
                Witness(SyncDbServers(),
                    _ => Notify(inform($"Synchronized target {TargetNode} server catalog with source {SourceNode}")),
                    message => Notify(message));
            else
                Notify(warn("No!"));
        }


        [ShellCommand, Description("Generates proxies for a specifed subsystem")]
        public void proxyGen(string SysId, bool PLL)
        {
            var profiles = SolutionFolder(system(SysId)).GetFiles(FileExtension.Parse("sqlt"), true);
            iter(profiles, profile => Messaging.SubmitCommand(new C0.GenerateProxies(Host.NodeIdentifier, profile,PLL)));                           
        }

        [ShellCommand, Description("Deploys a dac package to a target node")]
        public void dacDeploy(string Package, string DstNode)
        {
            Messaging.SubmitCommand(new C0.DeploySqlDac(Host.NodeIdentifier, DstNode, Package));    
        }


        [ShellCommand, Description("Generates proxies that have been defined for a specified database")]
        public void dbProxyGen(string DbName, bool PLL)
        {
            iter(ProxyServices.GenerateDefinedProxies(DbName, PLL), result => Notify(result.Description));
        }

        [ShellCommand, Description("Enumerates available distribution archives")]
        public void distPackages(string distId)
            => PrintSequence(Distributor.ArchivedDistributions(distId));

        [ShellCommand, Description("Initiates build workflows for all platform solutions")]
        public void build()
            => Build().OnNone(Notify).OnSome(
                location => Notify(inform($"Target available at {location}")));

        [ShellCommand, Description("Initiates build workflows for all platform solutions a pushes to a specified host upon success")]
        public void buildTo(string Host)
            => Build().OnNone(Notify).OnSome(
                target => Distributor.ReleaseTo(PlatformDistributions.MetaFlowExe, 
                        target, node(Host)).OnNone(Notify).OnSome(destination => Notify(inform($"Distribution transmitted to {destination}"))));
                    
        [ShellCommand, Description("Emits the current platform version")]
        public void ver()
            => Print(PlatformVersion);

        [ShellCommand, Description("Builds a SQL package deployment report")]
        public void dacReport(string SourcePackage, string Host)
            => DacServices.CreateDacReport(SourcePackage, node(Host)).OnMessage(Notify);

        [ShellCommand, Description("Deploys Platform database to all nodes")]
        public void dacDeployPlatformG(bool PLL)
            => DacServices.DeploySystemDacs(PlatformSystems.PF, SqlNodes.Select(n => n.NodeIdentifier), PLL);

        [ShellCommand, Description("Deploys Hive database to all nodes")]
        public void dacDeployHiveG(bool PLL)
            => DacServices.DeploySystemDacs("Hive", SqlNodes
                .Select(n => n.NodeIdentifier), PLL);

        [ShellCommand, Description("Deploys SQL packages for a specified node/subsystem")]
        public void dacDeploySys(string System, string TargetNode, bool PLL)
            => DacServices.DeploySystemDacs(System, TargetNode, PLL);

        [ShellCommand, Description("Deploys SQL packages for a specified node/subsystem")]
        public void dacDeploySysG(string System,bool PLL)
            => iter(SqlNodes, target => DacServices.DeploySystemDacs(System, target, PLL),PLL);

        [ShellCommand, Description("Enumerates all system dacpacs")]
        public void dacpacs()
        {
            iter(DacServices.DescribeDacs(), 
                dac => Print($"{dac.PackageName}, {dac.References.Count} package dependencies"));
        }

        [ShellCommand, Description("Drops an identified server striggger")]
        public void dropTriggerG(string triggerName)
        {           
            iter(SqlNodes, 
                n => ServerRuntime(n).DropServerTrigger(triggerName)
                            .OnNone(Notify)
                            .OnSome(_ => Notify(inform($"Dropped {triggerName} on {n}"))));
        }

        ISqlSpaceServices SqlSpace
            => C.SqlSpaceServices();

        Option<NodeFilePath> ReificationWorkflow(ComponentDescriptor DefiningComponent)
            => from ass in Reflector.FindAssembly(DefiningComponent.ComponentId)
               from d in ass.Designator               
               let dstFileName = FileName.Parse(d.Identity) + FileExtension.Parse("dacpac")
               let dstPath = DacServices.DacRepositoryLocation + dstFileName
               from r in SqlSpace.ReifyModel(ass, dstPath)
               select r;

        Option<NodeFilePath> ReifySqlMetamodel(ComponentDescriptor DefiningComponent)
        {
            Notify(inform($"Creating SQL package as determined by {DefiningComponent}"));
            return ReificationWorkflow(DefiningComponent)
                .OnNone(Notify)
                .OnSome(dacpath => Notify(inform($"Created model at {dacpath}")));
                                    
        }

        [ShellCommand, Description("Constructs model-defined artifiacts")]
        public void reify()
        {
            iter(Metamodels, model => ReifySqlMetamodel(model)
            
            );
        }

        [ShellCommand, Description("Encrypts the supplied text")]
        public void encrypt(string s)
        {

            Print($"Plaintext: {s}");
            Print($"Encrypted: {PlatformKey.Encrypt(s)}");

        }

        [ShellCommand, Description("Decrypts the supplied text")]
        public void decrypt(string s)
        {

            Print($"Encrypted: {s}");
            Print($"Plaintext: {PlatformKey.Decrypt(s)}");            
        }

        [ShellCommand, Description("Enumerates database backup archives/files")]
        public void backups(string Host)
        {
            iter(NFS.PlatformNav(node(Host)).PublishedBackups, backup => Print(backup));
        }

        protected void Print(WF.ISystemTaskResult taskResult)
            => SystemConsole.Get().Write(
                taskResult.Succeeded 
                ? inform($"The {taskResult.TaskId} task succeeded") 
                : error($"The {taskResult.TaskId} task failed :{taskResult.ResultDescription}")
                );

        ISystemCommandRouter CommandRouter
        => C.HostContext().SystemCommandRouter();
        
        [ShellCommand, Description("Deploys a platform database")]
        public void deployDb(string db, string node)
        {
            var command = new C0.DeployDatabase(Host.NodeIdentifier,  DatabaseServer: node, DatabaseName: db);
            Messaging.SubmitCommand(command);
        }
        public void merge()
        {
            var script = PXM.TableType<TinyTypeTableRow>().MergeFrom("SyncMessageClasses", typeof(MessageClass), nameof(TinyTypeTableRow.TypeCode), true);

        }

        public void unpackDistribution()
        {
            UnpackDistribution();
        }

        void Print(IReadOnlyList<BackupDescription> backups)
            => iter(backups, backup => Print($"{backup.LogicalName} {backup.BackupSizeInBytes} bytes"));

        public void describeBackup(string HostPath)
        {
            var command = new C0.DescribeBackup(SourceNode.NodeIdentifier, SourceNode.NodeIdentifier, HostPath);
            Messaging.SubmitCommand(command);
            
        }
    }
}