//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using Meta.Core;
    using MetaFlow.Core;
    using MetaFlow.WF;

    using N = SystemNodeIdentifier;

    public static class ServiceFactory
    {

        public static IEnumerable<SystemNode> SystemNodes(this INodeContext C)
            => C.SqlConnector().PlatformNodes;

        public static IAgentControl AgentControl(this INodeContext C)
            => C.Service<IAgentControl>();

        public static ITaskQueueWorkflow TaskQueueWorkflow<K>(this INodeContext C)
            where K : class, ISystemCommand, ISqlTableTypeProxy, new()
                => C.Service<ITaskQueueWorkflow>(typeof(K).Name);

        public static I TaskQueueWorkflow<K, I>(this INodeContext C)
            where K : class, ISystemCommand, ISqlTableTypeProxy, new()
                where I : ITaskQueueWorkflow
                => C.Service<I>(typeof(K).Name);

        public static ISystemCommandWorkflow SystemCommandWorkflow(this INodeContext C)
            => C.Service<ISystemCommandWorkflow>(typeof(SystemCommand).Name);

        public static SqlConnectionString WorkflowConnector(this IApplicationContext C, N Host)
            => C.SqlConnector(Host, PlatformDatabaseKind.WF).Require();

        public static ISqlProxyBroker WorkflowBroker(this INodeContext C, SqlNotificationObserver Observer = null)
            => WorkflowBroker(C, C.Host, Observer ?? C.SqlObserver);

        public static ISqlProxyBroker WorkflowBroker(this IApplicationContext C, N Host, SqlNotificationObserver Observer = null)
            => MetaFlowWorkflowProxies.Broker(C.WorkflowConnector(Host), Observer ?? C.SqlObserver);

        static readonly FolderPathVariable DistRootDir = new FolderPathVariable("DistRootDir");

        public static ISqlHostServices SqlHostServices(this INodeContext C)
            => C.Service<ISqlHostServices>();
        public static IProxyServices PlatformProxyServices(this IApplicationContext C)
            => C.Service<IProxyServices>();

        public static ISqlDataFlowProvider PlatformDataFlows(this IApplicationContext C)
            => C.Service<ISqlDataFlowProvider>();

        public static IPlatformServiceProvider PlatformServices(this INodeContext C)
            => C.Service<IPlatformServiceProvider>();

        public static INodeConfiguration PlatformConfiguration(this INodeContext C)
            => C.Service<INodeConfiguration>();

        public static ISystemReflector SystemReflector(this IApplicationContext C)
                => C.Service<ISystemReflector>();

        public static INodeContext HostContext(this IApplicationContext C)
            => C.NodeContext(SystemNode.Local);

        public static IPlatformDistributor Distributor(this INodeContext C)
            => C.Service<IPlatformDistributor>();

        public static NodeFileSystem NFS(this IApplicationContext C)
            => new NodeFileSystem(C);

        public static ISqlProxyBroker PlatformBroker(this IApplicationContext C, N HostId)
            => C.SqlConnector().SqlBroker<MetaFlowCoreStorage>(HostId, PlatformDatabaseKind.MetaFlow).Require();

        public static ISqlProxyBroker SqlStoreBroker(this INodeContext C)
            => SqlTStoreProxies.Assembly.ProxyBroker(C.SqlConnector().Connection(C.Host, "SqlT").Require());

        public static IEntityStore EntityStore(this INodeContext C)
            => C.Service<IEntityStore>();

        public static IPlatformCatalog PlatformCatalog(this IApplicationContext C)
            => C.Service<IPlatformCatalog>();

        public static ICommandLineServices CommandLineServices(this IApplicationContext C)
            => C.Service<ICommandLineServices>();


        public static IPlatformBuildService PlatformBuildService(this IApplicationContext C)
            => C.Service<IPlatformBuildService>();

        public static IPlatformDacServices PlatformDacServices(this INodeContext C)
            => C.Service<IPlatformDacServices>();

        public static ISqlBackupServices SqlBackupServices(this INodeContext C)
            => C.Service<ISqlBackupServices>();

        public static ISystemMessaging SystemMessaging(this INodeContext C)
            => C.Service<ISystemMessaging>();

        public static ISystemCommandRouter SystemCommandRouter(this INodeContext C)
            => C.Service<ISystemCommandRouter>();

        public static IDevProjectManager ProjectManager(this IApplicationContext C)
            => C.HostContext().Service<IDevProjectManager>();

    }

}
