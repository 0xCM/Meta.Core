//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlMetadataProvider
    {
        Option<SqlDatabaseMetadataSet> DescribeDatabase(SqlConnectionString Connector, 
            SqlDatabaseName Database, SqlMetadataSelectionOptions options = null);

        Option<SqlServerInstanceDescription> DescribeServer(SqlConnectionString Connector, SqlServerName Server);
    }
}
