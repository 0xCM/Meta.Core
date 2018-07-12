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
    using PX = MetaFlow.Core.Storage;

    using MetaFlow.Core;

    using static metacore;

    class NodeConfigurationService : NodeService<NodeConfigurationService, INodeConfiguration>, INodeConfiguration
    {
     
        IReadOnlySet<PlatformNode> Hosts { get; }

        IReadOnlySet<SqlDatabaseServer> SqlServers { get; }

        ISqlProxyBroker PlatformBroker { get; }


        IEnumerable<SqlDatabaseServer> GetSqlServers(IReadOnlySet<SystemNode> nodes)
            => from server in PlatformBroker.Get(new PX.DatabaseServers()).OnNone(Notify).Items()
               let node = nodes.Where(n => n.NodeIdentifier == server.HostId).Single()
               select server.ToSqlDatabaseServer(node);

        public IEnumerable<SqlDatabaseServer> DatabaseServers()
            => SqlServers;


        public IEnumerable<PlatformNode> PlatformNodes()
            => Hosts;
               

        public NodeConfigurationService(INodeContext C)
            : base(C)
        {
            PlatformBroker = C.PlatformBroker(C.Host);
            Hosts = PlatformBroker.Get(new PX.PlatformServers()).OnNone(Notify).Items().ToReadOnlySet();
            SqlServers = GetSqlServers(Hosts.Select(h => h.ToSystemNode()).ToReadOnlySet()).ToReadOnlySet();
        }
    }
}
