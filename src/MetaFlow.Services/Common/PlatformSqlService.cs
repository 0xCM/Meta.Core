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

    public abstract class PlatformSqlService<T, I> : SqlNodeService<T, I>
       where T : PlatformSqlService<T, I>
       where I : INodeService
    {
        IPlatformServiceProvider SP { get; }

        public PlatformSqlService(ISqlContext C)
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

        protected Option<SqlConnectionString> SqlConnector(PlatformDatabaseKind DatabaseType)
            => SP.SqlConnector(HostId, DatabaseType);


        protected Option<ISqlProxyBroker> SqlBroker<A>(PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new()
                => SP.SqlBroker<A>(HostId, DatabaseType);

        protected Option<ISqlProxyBroker> PlatformBroker
            => SP.PlatformBroker(HostId);

        protected ISqlProxyBroker HostPlatformBroker
             => SP.HostPlatformBroker;

    }

    public abstract class PlatformSqlService<T, A, I> : PlatformSqlService<T, I>, INodeService
        where T : PlatformSqlService<T, A, I>
        where I : INodeService
        where A : class, ISqlProxyAssembly, new()
    {
        public PlatformSqlService(ISqlContext C, PlatformDatabaseKind DatabaseType)
           : base(C)
        {
            this.DatabaseType = DatabaseType;
            this.Broker = SqlBroker<A>(DatabaseType).Require();            
        }

        protected PlatformDatabaseKind DatabaseType { get; }

        protected new ISqlProxyBroker Broker { get; }
    }
}