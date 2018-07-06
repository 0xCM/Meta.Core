//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using SqlT.Core;

    public interface ISqlMetadataStore
    {
        Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlServerMetadataSet set);

        Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlDatabaseMetadataSet set);

        Option<SqlMetadataStats> Save(SqlConnectionString cs, SqlServerInstanceDescription description);
    }

}
