//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Types.Lists;
    using SqlT.Dac;
    using System.Collections.Concurrent;

    
    using static metacore;
    using static StatusMessages;

    using MetaFlow.Core;
    using PX = MetaFlow.Core.Storage;

    using N = SystemNode;
    
    using Meta.Core;


    class PlatformDacServices : PlatformService<PlatformDacServices, IPlatformDacServices>, IPlatformDacServices
    {
        public PlatformDacServices(INodeContext C)
            : base(C)
            
        {
            SqlMessages = new SqlSessionMessages(C);
            PacMan = C.SqlPackageManager();
            DacNavigator = NFS.SqlDacNav(Host);

        }

        SqlSessionMessages SqlMessages { get; }


        SqlDacNav DacNavigator { get; }

        ISqlPackageManager PacMan { get; }

        IEnumerable<SqlDatabaseServer> SqlNodes
            => C.SqlConnector().SqlNodes;


        SqlDatabaseServer server(SystemNodeIdentifier NodeId)
            => SqlNodes.TryGetSingle(n => n.NodeIdentifier == NodeId)
                .OnNone(() => Notify(inform($"Lookup of node {NodeId} failed")))
                .Require();

        void OnDacMessage(IAppMessage Message)
            => Notify(Message);

        Option<DacDeploymentToken> LogDacDeployStart(SqlPackageName DACPAC, SystemNodeIdentifier TargetNode, SqlDatabaseName TargetDatabase, CorrelationToken CT)
            => from token in C.PlatformBroker(Host).Get(new PX.LogDacDeployStart(Host.NodeIdentifier, DACPAC, TargetNode, TargetDatabase, CT))
               select token.Single();

        Option<int> LogDacDeployFinish(int DeploymentId, IAppMessage Message)
            => C.PlatformBroker(Host).Call(new PX.LogDacDeployFinish(DeploymentId, not(Message.IsError()), Message.Format(false)));
        
        DacDeploymentSummary ManageDacDeployment(SqlPackageName DACPAC, SystemNodeIdentifier Target, CorrelationToken? _ct = null)
        {

            var dacPath
                = from dac in DacNavigator.DacPacFile(DACPAC)
                  select dac;
            if (!dacPath)
                return new DacDeploymentSummary(NodeFilePath.Empty(), Target, dacPath.Message);
            var resolvedPath = dacPath.ValueOrDefault();

            var profilePath
                = from profile in DacNavigator.ProfileFile(DACPAC, server(Target))
                  select profile;
            if (!profilePath)
                return new DacDeploymentSummary(resolvedPath, Target, profilePath.Message);


            var targetDb = from p in profilePath
                               from m in PacMan.LoadProfile(p)
                               select m.TargetDatabaseName;
            if(!targetDb)
                return new DacDeploymentSummary(resolvedPath, Target, targetDb.Message);

            var ct = _ct ?? CorrelationToken.Create();
            var logStart = LogDacDeployStart(DACPAC, Target, targetDb.ValueOrDefault(), ct);
            if(!logStart)
                return new DacDeploymentSummary(resolvedPath, Target, logStart.Message);

            var workflow =
               from apf in profilePath
               from adp in dacPath
               from result in PacMan.Publish(adp, apf, OnDacMessage)
               select result;

            var message = workflow.IsNone() 
                    ? DacDeployFailure(DACPAC, Target, workflow.Message) 
                    : DacDeploySuccess(ct, DACPAC, Target);

            Notify(message);

            var logFinish = LogDacDeployFinish(logStart.ValueOrDefault().DeploymentId, message);
            return new DacDeploymentSummary(resolvedPath, Target, workflow.Message, ct);
            
        }

        public DacDeploymentSummary DeployDac(SqlPackageName DACPAC, SystemNodeIdentifier Target, CorrelationToken? CT = null)
        {

            var ct = CT ?? CorrelationToken.Create();
            Notify(DacDeployStart(ct, DACPAC, Target));
            var deployment = ManageDacDeployment(DACPAC, Target,ct);
            Notify(deployment.Message);
            return deployment;
        }

        public Option<NodeFilePath> DeployDacOld(SqlPackageName DACPAC, SystemNodeIdentifier Target)
        {
            var ct = CorrelationToken.Create();
            Notify(DacDeployStart(ct, DACPAC, Target));
            var deployment = ManageDacDeployment(DACPAC, Target,ct);
            Notify(deployment.Message);
            return 
                deployment.Succeded 
               ? deployment.SourcePackage 
               : none<NodeFilePath>(deployment.Message);

        }

        public void DeploySystemDacs(SystemIdentifier System, SystemNodeIdentifier TargetId, bool PLL)
        {
            throw new NotImplementedException();
        }

        public void DeploySystemDacs(SystemIdentifier System, IEnumerable<SystemNodeIdentifier> Targets, bool PLL)
            => iter(Targets, target => DeploySystemDacs(System, target, PLL), PLL);

        public NodeFolderPath DacRepositoryLocation
            => DacNavigator.DacPacLocation;

        public Option<SqlPackageDescription> DescribeDac(SqlPackageName PackageName)
            => from package in DacNavigator.DacPacFile(PackageName)
               from description in PacMan.DescribePackage(package)
               select description;

        public IEnumerable<SqlPackageDescription> DescribeDacs()
            => from file in DacNavigator.DacPacFiles
               let description = PacMan.DescribePackage(file)
               where description.IsSome()
               select description.ValueOrDefault();

        public Option<SqlPackageProfile> DefaultProfile(SystemNodeIdentifier TargetNode, SqlDatabaseName TargetDb)
            => from cs in C.SqlConnector(TargetNode)
              
               select new SqlPackageProfile()
               {
                   CreateNewDatabase = false,
                   TargetDatabaseName = TargetDb,
                   ScriptDatabaseOptions = true,
                   TargetConnectionString = cs,
                   BlockOnPossibleDataLoss = true,
                   DeployScriptFileName = FileName.Parse(concat(server(TargetNode).NodeName, TargetDb.UnquotedLocalName)).AddExtension("sql"),
                   DropObjectsNotInSource = true
               };


        public IReadOnlySet<Option<NodeFilePath>> DeployDacs(SqlPackageDependencySet Packages, SystemNodeIdentifier TargetNode, bool PLL = true)
        {

            var results = new ConcurrentBag<Option<NodeFilePath>>();

            iter(Packages.SupplierPackages,
                    package => results.Add(DeployDacOld(package, TargetNode)), PLL);

            results.Add(DeployDacOld(Packages.ClientPackage, TargetNode));
            return results.ToReadOnlySet();
        }

        public Option<DacDeploymentSummary> DeployDatabase(SqlDatabaseName DatabaseName, SystemNodeIdentifier TargetNode)
        {
            var profile = from p in HostPlatformBroker.Get(new PX.FindDatabaseProfiles(DatabaseName))
                          let selected = p.FirstOrDefault(x => x.ServerId == TargetNode)
                          select selected;
            if(!profile)                
                return none<DacDeploymentSummary>(error($"Profile for {DatabaseName} database on {TargetNode} not found"));

            var component = (from p in HostPlatformBroker.Get(new PX.TargetedDatabaseComponents()).OnNone(Notify).Items()
                            where p.TargetedDatabase == DatabaseName
                            select p).TryGetSingle();

            return component.Map(tb => ManageDacDeployment(tb.SqlPackageName, TargetNode));
        }

        public Option<int> CreateDacReport(SqlPackageName PackageName , SystemNodeIdentifier TargetId)
        {
            var target = server(TargetId);
            Notify(inform($"Creating {target} deployment report for {PackageName}"));

            var sqlDistId = DistributionIdentifier.Parse("metaflow-sql");
            var dacSegment = FolderName.Parse("dacpac");
            var reportSegment = FolderName.Parse("dac.reports");

            var sqlDistDir = PlatformVariables.DistRootDir.ResolveValue().Require();
            var dacDistDir = sqlDistDir + FolderName.Parse(dacSegment);
            var reportDistDir = sqlDistDir + FolderName.Parse(reportSegment);
            var createDir = reportDistDir.CreateIfMissing();
            if (!createDir)
                return createDir.ToNone<int>();

            var dacFileName = FileName.Parse(PackageName).AddExtension(SqlPackageName.DefaultExtension);
            var dacPath = dacDistDir + dacFileName;
            if (!dacPath.Exists())
                return none<int>(error($"{dacFileName} does not exitst"));

            var profileFileName = dacFileName.RemoveExtension().AddExtension(target.NodeName).AddExtension(SqlPackageProfile.DefaultFileExtension);
            var profilePath = dacDistDir + profileFileName;
            if (!profilePath.Exists())
                return none<int>(error($"{profilePath} does not exist"));

            var reportFileName = dacFileName.RemoveExtension().AddExtension($"{target.NodeName}.report.xml");
            var reportPath = reportDistDir + reportFileName;
            
            var commandSpec = new SqlDacReport(dacPath, profilePath, reportPath);
            var args = commandSpec.Expand();
            var tool = RegisteredTools.SqlPackage.ToExecutable();
            tool.SaveBatchScript(args, reportPath.ChangeExtension("bat"))
                    .OnMessage(Notify);
            var process = tool.Execute(args, false);
            process.WaitForExit();
            return process.ExitCode != 0 ? none<int>(error($"Exit code {process.ExitCode}")) : some(0, inform($"Created report {reportPath}"));

        }

    }

}