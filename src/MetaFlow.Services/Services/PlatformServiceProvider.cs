//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using Meta.Core;
    using MetaFlow.Core;
    
    using static metacore;

    sealed class PlatformServiceProvider : NodeService<PlatformServiceProvider, IPlatformServiceProvider>, IPlatformServiceProvider
    {
        public PlatformServiceProvider(INodeContext C)
         : base(C)
        {
            HostConfiguration = C.NodeContext(SystemNode.Local).PlatformConfiguration();
        }

        public INodeConfiguration HostConfiguration { get; }

        public SystemNodeIdentifier HostId
            => SystemNode.Local.NodeIdentifier;

        public IEnumerable<SystemNode> Nodes
            => Connector.PlatformNodes;

        public SystemNode Node(SystemNodeIdentifier Host)
            => Nodes.Single(x => x.NodeIdentifier == Host);

        public IJobScheduler Scheduler
            => C.Scheduler();

        public ISystemReflector Reflector
            => C.SystemReflector();

        public ICommandLineServices CommandLine
            => C.CommandLineServices();

        public INodeFileSystem NFS
            => C.NFS();

        public IProxyServices ProxyServices
            => C.PlatformProxyServices();

        public IPlatformCatalog PlatformCatalog
            => C.PlatformCatalog();

        public ISqlDataFlowProvider DataFlows
            => C.PlatformDataFlows();

        public ISqlConnector Connector
            => C.SqlConnector();

        public IJsonSerializer Serializer
            => C.JsonSerializer();

        public IEntityStore EntityStore
            => C.EntityStore();

        public IFileArchiveManager ArchiveManager
            => C.FileArchiveManager();

        public ISystemMessaging SystemMessaging
            => C.SystemMessaging();

        public IMetaBuild MetaBuild
            => C.MetaBuild();

        public IIconStore IconStore
            => C.IconStore();

        public ISqlHostServices HostServices
            => C.SqlHostServices();

        public Option<SqlConnectionString> SqlConnector(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType)
            => Connector.Connection(SqlNodeId, DatabaseType);

        public void OnSqlNotification(SqlNotification n)
            => Notify(n.ToApplicationMessage());

        public Option<ISqlProxyBroker> SqlBroker<A>(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new()
                => from connector in SqlConnector(SqlNodeId, DatabaseType)
                   select new A().CreateBroker(connector, OnSqlNotification);

        public Option<ISqlProxyBroker> PlatformBroker(SystemNodeIdentifier SqlNodeId)
            => SqlBroker<MetaFlowCoreStorage>(SqlNodeId, PlatformDatabaseKind.MetaFlow);

        public ISqlProxyBroker HostPlatformBroker
             => PlatformBroker(SystemNode.Local).Require();
    }
}