//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;
    using SqlT.Models;

    public static class SqlDatabaseOperations
    {
        public static ScalarResult<T> ExecuteScalarScript<T>(this ISqlDatabaseHandle h,
            string sql, params (string, object)[] args)
                => h.Broker.ExecuteScalarScript<T>(sql, args);

        public static Option<SqlVersion> GetCompatibilityVersion(this ISqlDatabaseHandle h)
        {
            var sql = h.DatabaseName.SQL_COMPATIBILITY_LEVEL();
            return h.ExecuteScalarScript<byte>(sql).TryMapValue(x => ((SqlVersionIndicator)x).GetVersion());
        }


    }
}
