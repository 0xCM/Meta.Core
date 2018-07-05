//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlMetadataProvider
    {
        Option<SqlDatabaseMetadataSet> DescribeDatabase(SqlConnectionString Connector, SqlDatabaseName Database, SqlMetadataSelectionOptions options = null);

        Option<SqlServerInstanceDescription> DescribeServer(SqlConnectionString Connector, SqlServerName Server);
    }
}
