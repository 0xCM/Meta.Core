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

    using static metacore;
    using MetaFlow.Core;

    public interface IPlatformServiceProvider
    {
        INodeConfiguration HostConfiguration { get; }

        SystemNodeIdentifier HostId { get; }

        IEnumerable<SystemNode> Nodes { get; }

        SystemNode Node(SystemNodeIdentifier Host);

        IJobScheduler Scheduler { get; }

        ISystemReflector Reflector { get; }

        ICommandLineServices CommandLine { get; }

        INodeFileSystem NFS { get; }

        IProxyServices ProxyServices { get; }

        IPlatformCatalog PlatformCatalog { get; }

        ISqlDataFlowProvider DataFlows { get; }

        ISqlConnector Connector { get; }

        IJsonSerializer Serializer { get; }

        IEntityStore EntityStore { get; }

        IFileArchiveManager ArchiveManager { get; }

        IMetaBuild MetaBuild { get; }

        Option<SqlConnectionString> SqlConnector(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType);

        void OnSqlNotification(SqlNotification n);

        Option<ISqlProxyBroker> SqlBroker<A>(SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new();

        Option<ISqlProxyBroker> PlatformBroker(SystemNodeIdentifier SqlNodeId);

        ISqlProxyBroker HostPlatformBroker { get; }

        ISystemMessaging SystemMessaging { get; }

        IIconStore IconStore { get; }

        ISqlHostServices HostServices { get; }


    }



}