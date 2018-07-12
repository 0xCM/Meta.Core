//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using SqlT.Core;
    using MetaFlow.Core;

    using System;
    using System.Collections.Generic;
    using N = SystemNodeIdentifier;

    public interface ISqlConnector
    {
        IEnumerable<SystemNode> PlatformNodes { get; }

        IEnumerable<SqlDatabaseServer> SqlNodes { get; }

        Option<SqlConnectionString> Connection(N SqlNodeId, PlatformDatabaseKind DbType);

        IEnumerable<PlatformDatabase> PlatformDatabases(N SqlNodeId);

        PlatformDatabase PlatformDatabase(N SqlNodeId, PlatformDatabaseKind DbType);

        IEnumerable<SqlDatabaseName> PlatformDatabases(N SqlNodeId, PlatformDatabaseKind DbType);

        SqlUserCredentials UserCredentials(N SqlNodeId);
        Option<SqlConnectionString> Connection(N SqlNodeId, SqlDatabaseName DbName);

        Option<SqlConnectionString> Connection(N SqlNodeId);

        IEnumerable<SqlDatabaseName> SqlDatabases(N SqlNodeId);

        Option<ISqlProxyBroker> SqlBroker<A>(N SqlNodeId, PlatformDatabaseKind DbType)
            where A : class, ISqlProxyAssembly, new();
    }

}

