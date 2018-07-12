//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;

    using MetaFlow.Core;

    using N = SystemNodeIdentifier;
    
    using MetaFlow.Core.Storage;
    
    class SqlConnectorService : ApplicationService<SqlConnectorService, ISqlConnector>, ISqlConnector
    {
        IEnumerable<SqlDatabaseServer> GetSqlServers(IReadOnlySet<SystemNode> nodes)
            => from server in PlatformBroker.Get(new DatabaseServers()).OnNone(Notify).Items()
               let node = nodes.Where(n => n.NodeIdentifier == server.HostId).Single()
               select server.ToSqlDatabaseServer(node);
    
        public SqlConnectorService(IApplicationContext C)
            : base(C)
        {
            PlatformBroker = C.HostPlatformBroker(SqlCredentials(PlatformDatabaseKind.MetaFlow).Require());
            Databases = PlatformBroker.PlatformDatabases().Require();
            SystemNodes = map(PlatformBroker.Get(new PlatformServers()).Require(), n => n.ToSystemNode()).ToReadOnlySet();
            SystemServers = GetSqlServers(SystemNodes).ToReadOnlySet();            
        }

        IReadOnlySet<SqlDatabaseServer> SystemServers { get; }
              
        IReadOnlySet<SystemNode> SystemNodes { get; }

        IReadOnlySet<PlatformDatabase> Databases { get; }

        ISqlProxyBroker PlatformBroker { get; }

        public IEnumerable<SqlDatabaseServer> SqlNodes
            => SystemServers;

        public IEnumerable<PlatformDatabase> PlatformDatabases(N SqlNodeId)
            => Databases.Where(db => db.SqlNode.Identifier == SqlNodeId);

        Option<SqlServerAlias> ServerAlias(N SqlNodeId)
            => from server in SystemServers.TryGetSingle(x => x.NodeIdentifier == SqlNodeId)
               select server.Alias.ValueOrDefault();

        Option < SqlConnectionCredentials > SqlCredentials(PlatformDatabaseKind ? DbType = null)
            => from sqlUser in PlatformVariables.OperatorName.ResolveValue()
               from sqlPass in PlatformVariables.OperatorPass.ResolveValue()
               select new SqlConnectionCredentials(sqlUser, sqlPass);

        static readonly SqlDatabaseName PlatformControllerName = "MetaFlow";

        public PlatformDatabase PlatformController(N SqlNodeId)
            => Databases.Where(db => db.DatabaseType == PlatformDatabaseKind.MetaFlow
                                    && db.IsEnabled
                                    && db.IsPrimary
                                    && db.SqlNode == SqlNodeId).TryGetSingle().ValueOrElse
                            (() => new PlatformDatabase
                            (
                                PlatformControllerName,
                                PlatformDatabaseKind.MetaFlow,
                                PlatformNodes.Single(n => n.NodeIdentifier == SqlNodeId),
                                SqlNodeId,
                                true,
                                true,
                                false,
                                false)                                        
                            );

        public SqlUserCredentials UserCredentials(N SqlNodeId)
            => (from c in SqlCredentials()
                select new SqlUserCredentials(c.Username, c.Password)).Require();

        SqlConnectionString PlatformControlConnector(N SqlNodeId)
            =>     SqlConnectionString.Build()
                        .ConnectTo(ServerAlias(SqlNodeId).Require().AliasName, PlatformControllerName)
                        .UsingCredentials(SqlCredentials().Require())
                        .Finish();

        public PlatformDatabase PlatformDatabase(N SqlNodeId, PlatformDatabaseKind DbType)
            => Databases.Where(db => db.DatabaseType == DbType
                                    && db.IsEnabled
                                    && db.IsPrimary
                                    && db.SqlNode == SqlNodeId).Single();

        public Option<SqlConnectionString> Connection(N NodeId, PlatformDatabaseKind DbType)
        {
            var db = DbType == PlatformDatabaseKind.MetaFlow ? PlatformController(NodeId)
                : PlatformDatabase(NodeId, DbType);
            
            return
                    SqlConnectionString.Build()
                        .ConnectTo(ServerAlias(db.SqlNode).Require().AliasName, db.Name)
                        .UsingCredentials(SqlCredentials().Require())
                        .Finish();
        }

        public IEnumerable<SystemNode> PlatformNodes
            => SystemNodes;

        public IEnumerable<SqlDatabaseName> SqlDatabases(N NodeId)
            => from db in Databases
               where db.SqlNode == NodeId
               select db.Name;

        public IEnumerable<SqlDatabaseName> PlatformDatabases(N NodeId, PlatformDatabaseKind DbType)
            => from db in Databases
               where db.SqlNode == NodeId &&
               db.DatabaseType == DbType                               
               select db.Name;

        public Option<ISqlProxyBroker> SqlBroker<A>(N NodeId, PlatformDatabaseKind DbType)
            where A : class, ISqlProxyAssembly, new()
             => from c in Connection(NodeId, DbType)
                select new A().CreateBroker(c);

        public Option<SqlConnectionString> Connection(N SqlNodeId)
        {
            var query = from server in SystemServers.TryGetFirst(s => s.NodeIdentifier == SqlNodeId)
                        from c in SqlCredentials()
                        from a in server.Alias
                        let cs = SqlConnectionString.Build()
                                    .ConnectTo(a.AliasName)
                                    .UsingCredentials(c)
                        select cs.Finish();
            return query;
        }

        Option<SqlServerAlias> LookupAlias(N SqlNodeId)
            => from n in C.SqlNode(SqlNodeId)
               from a in ServerAlias(n)
               select a;

        public Option<SqlConnectionString> Connection(N SqlNodeId, SqlDatabaseName DbName)
            => from a in LookupAlias(SqlNodeId)
               from c in SqlCredentials()
               let build = SqlConnectionString.Build()
                                .ConnectTo(a.AliasName, DbName)
                                .UsingCredentials(c)
               select build.Finish();                                
                   
    }
}