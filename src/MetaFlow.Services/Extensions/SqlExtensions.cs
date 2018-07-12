//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using SqlT.Core;
    using SqlT.Services;
    using Meta.Core;
    using MetaFlow.Core;

    using static metacore;

    using PX = MetaFlow.Core.Storage;
    using N = SystemNode;

    public static class SqlExtensions
    {

        public static Option<SystemNodeIdentifier> SqlNodeId(this SqlServerName server)
            => server.IsLocalHost 
            ? SystemNodeIdentifier.Local 
            :  (from p in new PlatformDatabaseServers()
                where string.Compare(p.NodeName, server.UnquotedLocalName, true) == 0
                || string.Compare(p.SqlNodeId, server.UnquotedLocalName, true) == 0
                select p).TryGetFirst().Map(x => SystemNodeIdentifier.Parse(x.SqlNodeId));

        public static Option<SystemNodeIdentifier> TargetNodeId(this SqlConnectionString cs)
            => cs.ServerName.SqlNodeId();

        internal static ISqlProxyBroker HostPlatformBroker(this IApplicationContext C, SqlConnectionCredentials Credentials)
        {
            var dbName = "MetaFlow";
            var dbServer = SystemNode.Local.NodeName;
            var connector = SqlConnectionString.Build(dbServer, dbName).UsingCredentials(Credentials);
            return MetaFlowCoreStorage.Broker(connector);
        }

        internal static Option<ReadOnlySet<PlatformDatabase>> PlatformDatabases(this ISqlProxyBroker PlatformBroker)
        {

            var query = from descriptions in PlatformBroker.Get<PX.PlatformDatabaseDescription>()
                        let db = map(descriptions, d => new PlatformDatabase
                            (
                                Name: d.DatabaseName,
                                DatabaseType: parseEnum(d.DatabaseType, PlatformDatabaseKind.None),
                                Host: d.HostId,
                                SqlNode: d.SqlNodeId,
                                IsPrimary: d.IsPrimary,
                                IsEnabled: d.IsEnabled,
                                IsModel: d.IsModel,
                                IsRestore: d.IsRestore
                             ))
                        select db;

            return query.Map(x => x.ToReadOnlySet());
        }


        public static string Description(this MemberInfo t)
            => t.GetCustomAttribute<DescriptionAttribute>()?.Description;

        /// <summary>
        /// Constructs a <see cref="INodeContext"/> predicated on an existing application-level context
        /// and a node identifier
        /// </summary>
        /// <param name="C">The source context</param>
        /// <param name="NodeId">Identifies the node for which a context will be specialized</param>
        /// <returns></returns>
        public static INodeContext NodeContext(this IApplicationContext C, SystemNodeIdentifier NodeId)
            => global::NodeContext.Get(C,
                C.SqlConnector().PlatformNodes.Where(n => n.NodeIdentifier == NodeId).Single());

        public static SqlConnectionString CommandStoreConnector(this IApplicationContext C, N Host)
              => C.SqlConnector(Host, PlatformDatabaseKind.MetaFlow).Require();

        public static ISqlConnector SqlConnector(this IApplicationContext C)
            => C.Service<ISqlConnector>();

        public static ISqlContext SqlContext(this INodeContext C, SqlConnectionString Connector)
            => new SqlContext(C, Connector);

        public static ISqlConnector SqlConnect(this IApplicationContext C)
            => C.Service<ISqlConnector>();

        public static Option<SqlConnectionString> SqlConnector(this IApplicationContext C, N SqlNodeId, PlatformDatabaseKind DatatabaseType)
            => C.SqlConnector().Connection(SqlNodeId, DatatabaseType);

        public static Option<SqlConnectionString> SqlConnector(this IApplicationContext C, N SqlNodeId)
            => C.SqlConnector().Connection(SqlNodeId);

        public static Option<SqlConnectionString> SqlConnector(this IApplicationContext C, SystemNodeIdentifier SqlNodeId, PlatformDatabaseKind DatatabaseType)
            => C.SqlConnector().Connection(SqlNodeId, DatatabaseType);

        public static Option<SqlConnectionString> SqlConnector(this IApplicationContext C, SystemNodeIdentifier SqlNodeId)
            => C.SqlConnector().Connection(SqlNodeId);

        /// <summary>
        /// Constructs the linked SQL context between two databases
        /// </summary>
        /// <param name="C">The base context</param>
        /// <param name="SourceDb">The source database</param>
        /// <param name="TargetDb">The target database</param>
        /// <returns></returns>
        public static ILinkedSqlContext SqlContext(this ILinkedContext C, SqlDatabaseName SourceDb, SqlDatabaseName TargetDb)
        {
            var srcCredentials = C.SqlConnect().UserCredentials(C.SourceNode);
            var dstCredentials = C.SqlConnect().UserCredentials(C.TargetNode);
            var srcConnector = SqlConnectionString.Build(C.SourceNode.NodeName, SourceDb).UsingCredentials(srcCredentials).Finish();
            var dstConnector = SqlConnectionString.Build(C.TargetNode.NodeName, TargetDb).UsingCredentials(srcCredentials).Finish();
            return new LinkedSqlContext(C, C.Link, link(srcConnector,dstConnector));
        }

        public static N PlatformNode(this IApplicationContext C, SystemNodeIdentifier id)
            => C.SqlConnector().PlatformNodes.Single(n => n.NodeIdentifier == id || n.NodeName == id);

        public static Option<N> LookupNode(this IApplicationContext C, SystemNodeIdentifier id)
            => C.SqlConnector().PlatformNodes.TryGetFirst(n => n.NodeIdentifier == id || n.NodeName == id);

        public static IEnumerable<N> PlatformNodes(this IApplicationContext C)
            => C.SqlConnector().PlatformNodes;

        public static IEnumerable<SqlDatabaseServer> SqlNodes(this IApplicationContext C)
            => C.SqlConnector().SqlNodes;

        public static Option<SqlDatabaseServer> SqlNode(this IApplicationContext C, SystemNodeIdentifier id)
            => C.SqlConnector().SqlNodes.TryGetSingle(n => n.NodeIdentifier == id || n.NodeName == id);

        public static ISqlProxyChannelFactory ChannelFactory<A>(this ILinkedContext C, PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new()
            => SqlChannelFactory.CreateFactory<A>(n => C.SqlObserver(n),
                    new SqlContext(C.SourceContext,
                        C.SourceContext.SqlConnector(C.SourceNode.NodeIdentifier, DatabaseType).Require()),
                    new SqlContext(C.TargetContext,
                        C.TargetContext.SqlConnector(C.TargetNode.NodeIdentifier, DatabaseType).Require()));

        public static ISqlProxyChannelFactory ChannelFactory<A, B>(this ILinkedContext C, PlatformDatabaseKind DatabaseType)
            where A : class, ISqlProxyAssembly, new()
            => SqlChannelFactory.CreateFactory<A>(n => C.SqlObserver(n),
                    new SqlContext(C.SourceContext,
                        C.SourceContext.SqlConnector(C.SourceNode.NodeIdentifier, DatabaseType).Require()),
                    new SqlContext(C.TargetContext,
                        C.TargetContext.SqlConnector(C.TargetNode.NodeIdentifier, DatabaseType).Require()));

        public static ISqlProxyChannelFactory ChannelFactory<A, B>(this ILinkedContext C, PlatformDatabaseKind SourceDbType, PlatformDatabaseKind TargetDbType)
            where A : class, ISqlProxyAssembly, new()
            => SqlChannelFactory.CreateFactory<A>(n => C.SqlObserver(n),
                    new SqlContext(C.SourceContext,
                        C.SourceContext.SqlConnector(C.SourceNode.NodeIdentifier, SourceDbType).Require()),
                    new SqlContext(C.TargetContext,
                        C.TargetContext.SqlConnector(C.TargetNode.NodeIdentifier, TargetDbType).Require()));

        public static Option<SqlContext> SqlContext(this INodeContext C, PlatformDatabaseKind DbType)
            => from connector in C.SqlConnector(C.Host, DbType)
               select new SqlContext(C, connector);

        /// <summary>
        /// Obtains a connection string for a classified target database
        /// </summary>
        /// <param name="TargetDb">The target classification</param>
        /// <returns></returns>
        public static Option<SqlConnectionString> TargetConnector(this ILinkedContext C, PlatformDatabaseKind TargetDb)
            => C.SqlConnector().Connection(C.TargetNode, TargetDb);

        /// <summary>
        /// Obtains a connection string for an uclassified target database
        /// </summary>
        /// <param name="TargetDb">The source classification</param>
        /// <returns></returns>
        public static Option<SqlConnectionString> TargetConnector(this ILinkedContext C, SqlDatabaseName TargetDb)
            => C.TargetConnector(TargetDb);

        /// <summary>
        /// Obtains a connection string for a classified source database
        /// </summary>
        /// <param name="SourceDb">The source classification</param>
        /// <returns></returns>
        public static Option<SqlConnectionString> SourceConnector(this ILinkedContext C, PlatformDatabaseKind SourceDb)
            => C.SqlConnector().Connection(C.SourceNode, SourceDb);

        /// <summary>
        /// Obtains a connection string for an uclassified source database
        /// </summary>
        /// <param name="SourceDb">The source classification</param>
        /// <returns></returns>
        public static Option<SqlConnectionString> SourceConnector(this ILinkedContext C, SqlDatabaseName SourceDb)
            => C.SourceConnector(SourceDb);

        /// <summary>
        /// Creates a channel between supplied brokers
        /// </summary>
        /// <param name="C"></param>
        /// <param name="SourceBroker"></param>
        /// <param name="TargetBroker"></param>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel(this ILinkedContext C, ISqlProxyBroker SourceBroker, ISqlProxyBroker TargetBroker)
            => new SqlProxyChannel(C, SourceBroker, TargetBroker);

        /// <summary>
        /// Creates an unclassified typeline between source and target in same database
        /// </summary>
        /// <typeparam name="A">Designates the assemblys whose types mediate interaction with the data source</typeparam>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel<A>(this ILinkedContext C, SqlDatabaseName Db)
            where A : class, ISqlProxyAssembly, new()
                => from src in C.SourceConnector(Db)
                   from dst in C.TargetConnector(Db)
                   let pa = new A()
                   from channel in C.Channel(pa.CreateBroker(src), pa.CreateBroker(dst))
                   select channel;

        /// <summary>
        /// Creates an classified typeline between source and target in same database
        /// </summary>
        /// <typeparam name="A">Designates the assemblys whose types mediate interaction with the data source</typeparam>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel<A>(this ILinkedContext C, PlatformDatabaseKind Db)
            where A : class, ISqlProxyAssembly, new()
                => from src in C.SourceConnector(Db)
                   from dst in C.TargetConnector(Db)
                   let pa = new A()
                   from channel in C.Channel(pa.CreateBroker(src), pa.CreateBroker(dst))
                   select channel;

        /// <summary>
        /// Creates a typed pipline from a source database to a target database
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with both the source and target</typeparam>
        /// <param name="SourceDb">The name of the source database</param>
        /// <param name="TargetDb">The name of the target database</param>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel<A>(this ILinkedContext C, SqlDatabaseName SourceDb, SqlDatabaseName TargetDb)
            where A : class, ISqlProxyAssembly, new()
                => from src in C.SourceConnector(SourceDb)
                   from dst in C.TargetConnector(TargetDb)
                   let pa = new A()
                   from channel in C.Channel(pa.CreateBroker(src), pa.CreateBroker(dst))
                   select channel;

        /// <summary>
        /// Creates a typed pipline from a source database to a target database
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with the source</typeparam>
        /// <typeparam name="B">Designates the assembly whose types mediate interaction with the target</typeparam>
        /// <param name="SourceDb">The name of the source database</param>
        /// <param name="TargetDb">The name of the target database</param>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel<A, B>(this ILinkedContext C, SqlDatabaseName SourceDb, SqlDatabaseName TargetDb)
            where A : class, ISqlProxyAssembly, new()
            where B : class, ISqlProxyAssembly, new()
                => from src in C.SourceConnector(SourceDb)
                   from dst in C.TargetConnector(TargetDb)
                   let pa = new A()
                   let pb = new B()
                   from channel in C.Channel(pa.CreateBroker(src), pb.CreateBroker(dst))
                   select channel;

        /// <summary>
        /// Creates a typed pipline from a classfied source database to a classified target database
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with the source</typeparam>
        /// <typeparam name="B">Designates the assembly whose types mediate interaction with the target</typeparam>
        /// <param name="SourceDb">The source database type</param>
        /// <param name="TargetDb">The target database type</param>
        /// <returns></returns>
        public static Option<ISqlProxyChannel> Channel<A, B>(this ILinkedContext C, PlatformDatabaseKind SourceDb, PlatformDatabaseKind TargetDb)
            where A : class, ISqlProxyAssembly, new()
            where B : class, ISqlProxyAssembly, new()
                => from src in C.SourceConnector(SourceDb)
                   from dst in C.TargetConnector(TargetDb)
                   let pa = new A()
                   let pb = new B()
                   from channel in C.Channel(pa.CreateBroker(src), pb.CreateBroker(dst))
                   select channel;

        /// <summary>
        /// Creates a classified source broker
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with the source</typeparam>
        /// <param name="SourceDb">The source classification</param>
        /// <returns></returns>
        public static Option<ISqlProxyBroker> SourceBroker<A>(this ILinkedContext C, PlatformDatabaseKind SourceDb)
            where A : class, ISqlProxyAssembly, new()
                => from c in C.SourceConnector(SourceDb)
                   select new A().CreateBroker(c);

        /// <summary>
        /// Creates a classified source contract 
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with the target</typeparam>
        /// <typeparam name="O">The operation contract type</typeparam>
        /// <param name="SourceDb">The target classification</param>
        /// <returns></returns>
        public static Option<O> SourceOps<A, O>(this ILinkedContext C, PlatformDatabaseKind SourceDb)
            where A : class, ISqlProxyAssembly, new()
                => from b in C.SourceBroker<A>(SourceDb)
                   from o in b.Operations<O>()
                   select o;

        /// <summary>
        /// Creates a classified target broker
        /// </summary>
        /// <typeparam name="A">Designates the assemblys whose types mediate interaction with the target</typeparam>
        /// <param name="TargetDb">The target classification</param>
        /// <returns></returns>
        public static Option<ISqlProxyBroker> TargetBroker<A>(this ILinkedContext C, PlatformDatabaseKind TargetDb)
            where A : class, ISqlProxyAssembly, new()
                => from c in C.TargetConnector(TargetDb)
                   select new A().CreateBroker(c);

        /// <summary>
        /// Creates a classified target contract 
        /// </summary>
        /// <typeparam name="A">Designates the assembly whose types mediate interaction with the target</typeparam>
        /// <typeparam name="O">The operation contract type</typeparam>
        /// <param name="TargetDb">The target classification</param>
        /// <returns></returns>
        public static Option<O> TargetOps<A, O>(this ILinkedContext C, PlatformDatabaseKind TargetDb)
            where A : class, ISqlProxyAssembly, new()
                => from b in C.TargetBroker<A>(TargetDb)
                   from o in b.Operations<O>()
                   select o;
    }
}