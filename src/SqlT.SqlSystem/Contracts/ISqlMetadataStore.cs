//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
