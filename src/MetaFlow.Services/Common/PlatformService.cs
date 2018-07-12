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
    using SqlT.Core;
    using Meta.Core;

    using MetaFlow.Core;

    using static metacore;

    public abstract class PlatformService<T,I> : NodeService<T,I>, INodeService
        where T : PlatformService<T,I>
    {
        IPlatformServiceProvider SP { get; }

        protected PlatformService(INodeContext C)
            : base(C)
        {
            
            SP = C.PlatformServices();
        }

        protected INodeConfiguration HostConfiguration
            => SP.HostConfiguration;

        protected SystemNodeIdentifier HostId
            => SP.HostId;

        protected IEnumerable<SystemNode> Nodes
            => SP.Nodes;

        protected SystemNode node(SystemNodeIdentifier Host)
            => SP.Node(Host);

        protected IJobScheduler Scheduler
            => SP.Scheduler;

        protected ISystemReflector Reflector
            => SP.Reflector;

        protected ICommandLineServices CommandLine
            => SP.CommandLine;

        protected NodeFileSystem NFS
            => C.NFS();

        protected IProxyServices ProxyServices
            => SP.ProxyServices;

        protected IPlatformCatalog PlatformCatalog
            => SP.PlatformCatalog;

        protected ISqlDataFlowProvider DataFlows
            => SP.DataFlows;

        protected ISqlConnector Connector
            => SP.Connector;

        protected IJsonSerializer Serializer
            => SP.Serializer;

        protected IFileArchiveManager ArchiveManager
            => SP.ArchiveManager;

        protected ISystemMessaging Messaging
            => SP.SystemMessaging;

        protected SystemIdentifier DefiningSystem
            => DefiningAssembly.DesignatedModule.DefiningSystem();

        protected Option<SqlConnectionString> SqlConnector(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType)
            => SP.SqlConnector(SqlNodeId, DatabaseType);

        protected void OnSqlNotification(SqlNotification n)
            => SP.OnSqlNotification(n);

        protected Option<ISqlProxyBroker> SqlBroker<A>(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new()
                => SP.SqlBroker<A>(SqlNodeId, DatabaseType);

        protected Option<ISqlProxyBroker> PlatformBroker(SystemNodeIdentifier SqlNodeId = null)
            => SP.PlatformBroker(SqlNodeId ?? HostId);

        protected ISqlProxyBroker HostPlatformBroker
             => SP.HostPlatformBroker;
    }
}