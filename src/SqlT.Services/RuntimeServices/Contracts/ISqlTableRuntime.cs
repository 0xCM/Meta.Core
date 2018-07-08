//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlTableRuntime : ISqlObjectRuntime
    {
        SqlTableName Name { get; }

        Option<int> DropIfExists();

        Option<SqlTable> CreateIfMissing<T>()
             where T : ISqlTabularProxy, new();

        Option<int> Truncate();

        Option<int> Delete();

        Option<int> Count();

        Option<int> Count(string where);

        Option<int> CopyInto(SqlTableName target);

        Option<SqlDataFrame> Select(params SqlColumnName[] names);

        ScalarResult<T> Max<T>(SqlColumnName name);

        ScalarResult<T> Min<T>(SqlColumnName name);

        ISqlIndexRuntime Index(SqlIndexName name);

        ScalarResult<int> DistinctCount(SqlColumnName name);

        IEnumerable<T> Distinct<T>(SqlColumnName name);

        IEnumerable<Record<C0, C1>> Distinct<C0, C1>(SqlColumnName c0, SqlColumnName c1);

        ISqlDatabaseRuntime Database { get; }

    }

}