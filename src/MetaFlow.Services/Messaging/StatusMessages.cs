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

    using Meta.Core;

    using SqlT.Core;
    using MetaFlow.WF;

    using DistId = DistributionIdentifier;
    using N = SystemNodeIdentifier;

    using static metacore;
    
    static class StatusMessages
    {

        public static IAppMessage ExecutorNotFound(string CommandUri)
            => error($"Executor for the command {CommandUri} could not be found");

        public static IAppMessage ReactorNotFound(SystemUri EventUri)
            => error($"Reactor for the event {EventUri} could not be found");

        public static IAppMessage SqlPackageProfileNotFound(SqlPackageName PackageName, SystemNode Node, NodeFilePath ExpectedLocation)
            => error($"The @PackageName package profile for @NodeName was not found at the expected location @ExpectedLocation",
                new
                {
                    PackageName,
                    Node.NodeName,
                    ExpectedLocation
                });

        public static IAppMessage SqlPackageNotFound(SqlPackageName PackageName, NodeFilePath ExpectedLocation)
            => error($"The @PackageName package was not found at the expected location @ExpectedLocation",
                new
                {
                    PackageName,
                    ExpectedLocation
                });

        public static IAppMessage SqlAssemblyNotFound(SqlPackageName PackageName, NodeFilePath ExpectedLocation)
            => error($"The @PackageName package assembly file was not found at the expected location @ExpectedLocation",
                new
                {
                    PackageName,
                    ExpectedLocation
                });

        public static IAppMessage SynchronizedProxyProfiles(int count)
            => inform($"Synchronized {count} proxy generation profiles");

        public static IAppMessage SynchronizedPlatformSystems()
            => inform($"Synchronized platform systems");

        public static IAppMessage SynchronizedMessageTypeRegistry()
            => inform($"Synchronized platform systems");

        public static IAppMessage SynchronizedDistributionRegistry()
            => inform($"Synchronized distribution registry");

        public static IAppMessage SynchronizedPlatformDacRegistry()
            => inform($"Synchronized platform dac registry");

        public static IAppMessage SynchronizedDataFlowRegistry()
            => inform($"Synchronized platform data flow registry");

        public static IAppMessage SynchronizedPlatformAgents()
            => inform($"Synchronized platform agents");

        public static IAppMessage SynchronizedEventRegistry()
            => inform($"Synchronized event registry");

        public static IAppMessage SynchronizedCommandRegistry()
            => inform($"Synchronized command registry");

        public static IAppMessage SynchronizedPlatformSolutions()
            => inform($"Synchronized platform solutions");

        public static IAppMessage SynchronizedPlatformProjects()
            => inform($"Synchronized platform projects");

        public static IAppMessage SynchronizedPlatformComponents()
            => inform($"Synchronized platform components");

        public static IAppMessage ArchivedDistribution(Link<DistId, FilePath> DataFlow)
            => inform($"Archived distribution: @DataFlow", new { DataFlow });

        public static IAppMessage GeneratingProxies(FilePath ProfilePath)
            => inform($"Generating proxies specified by the profile {ProfilePath}");


        public static IAppMessage CreatingArchive(DistId DistId, FilePath ArchivePath)
            => inform($"Creating {DistId} distribution archive at {ArchivePath}");

        public static IAppMessage TransmittingDistribution(DistId DistId, N Target)
            => inform($"Transmitting {DistId} distribution to {Target}");

        public static IAppMessage ReleasingDistribution(DistId DistId, NodeFilePath DstPath)
            => inform($"Releasing {DistId} distribution to {DstPath}");

        public static IAppMessage OperationNotFound(SystemOperation SystemOp)
            => error($"The operation {SystemOp} was not found");

        public static IAppMessage SubmittedCommand<K>(K Command)
            where K : ISystemCommand
            => inform($"Submmitted {Command.GetType().Name} to {Command.CommandNode}");                                                                                    

        public static IAppMessage TaskCreated(ISystemTask task)
            => inform($"Submmitted {task.CommandUri}");

        public static IAppMessage DefinedTask(ISystemTaskDefinition definition)
            => inform($"Defined {definition.CommandUri} task on {definition.TargetNodeId}");

        public static IAppMessage Executing(string CommandUri, long TaskId)
            => inform($"Executing {CommandUri}, @Taskid = {TaskId}");

        public static IAppMessage ExecutionSuccess(string CommandUri, long TaskId)
            => inform($"Execution of command {CommandUri}, @TaskId = {TaskId} completed with success");

        public static IAppMessage ExecutionFailure(string CommandUri, long TaskId, string Reason)
            => error($"Execution of command {CommandUri}, @TaskId = {TaskId} completed with failure: {Reason}");

        public static IAppMessage DacDeployStart(CorrelationToken CT, SqlPackageName DACPAC, SystemNodeIdentifier Target)
            => inform($"Deploying {DACPAC} to {Target}/ct({CT})");

        public static IAppMessage DacDeploySuccess(CorrelationToken CT, SqlPackageName DACPAC, SystemNodeIdentifier Target)
            => inform($"Deployed {DACPAC} to {Target}/ct({CT})");

        public static IAppMessage DacDeployFailure(SqlPackageName DACPAC, SystemNodeIdentifier Target, IAppMessage Reason)
            => error($"{DACPAC} to {Target} deployment failed: {Reason.Format(false)}");

        public static IAppMessage SynchronizedDacProfiles()
            => inform($"Synchronized platform dac profiles"); 
    }

}