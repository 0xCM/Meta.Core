//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public static class SqlTabularX
    {
        const string MIN_TEMPLATE =
            @"select min(@ColumnName) from @TableName";

        const string MAX_TEMPLATE
            = @"select max(@ColumnName) from @TableName";

        const string DatabaseExists
            = @"select isnull((select 1 from [sys].[databases] where name = '@DatabaseName'), 0)";

        const string DatabaseExists_Qualified
            = @"select isnull((select 1 from [@ServerName].[master].[sys].[databases] where name = '@DatabaseName'), 0)";

        static SqlScript sql(this string template, object parameters)
            => SqlScript.FromText(template, parameters);

        public static Option<SqlScript> CountDistinct(this sxc.tabular_name t, SqlColumnName col)
            => SqlScript.FromResources(SqlResourceScriptNames.DistinctCount,
                new
                {
                    ObjectSchema = t.SchemaNamePart,
                    ObjectName = t.UnqualifiedName,
                    ColumnName = col.UnqualifiedName,
                });

        public static ScalarResult<int> CountDistinct(this ISqlTabularHandle h, SqlColumnName col)
            => h.Broker.ExecuteScalarScript<int>(CountDistinct(h.ElementName, col).Require());
                   
        
        public static ScalarResult<int> Count(this ISqlTabularHandle h)
            => h.Broker.ExecuteScalarScript<int>($"select count(*) from {h.ElementName}");

        public static ScalarResult<int> Count(this ISqlTabularHandle h, string where)
            => h.Broker.ExecuteScalarScript<int>($"select count(*) from {h.ElementName} where {where}");

        public static Option<int> SelectInto(this ISqlTabularHandle SrcTable, SqlTableName DstTable)
        => SrcTable.Broker.ExecuteNonQuery(SqlScript.FromText("select * into @Target from @Source",
            new
            {
                Source = SrcTable.ElementName,
                Target = DstTable,
            }));

        public static Option<SqlDataFrame> Select(this ISqlTabularHandle h, IEnumerable<SqlColumnName> columns)
        {
            var _cols = columns.ToReadOnlyList();
            var cols = _cols.Count == 0 ? " * " : string.Join(", ", columns);
            return h.Broker.Select($"select {cols} from {h.ElementName}");
        }

        public static IEnumerable<DataFrameRow<C0, C1>> Distinct<C0, C1>(this ISqlTabularHandle h,
            string col0, string col1)
                => h.Broker.SelectColumns<C0, C1>($"select distinct {col0}, {col1} from {h}");

        public static Option<SqlDataFrame> Select(this ISqlTabularHandle h)
            => h.Broker.Select($"select * from {h.ElementName}");

        public static string SQL_MIN(this sxc.tabular_name TableName, SqlColumnName ColumnName)
            => sql(MIN_TEMPLATE, new
            {
                TableName,
                ColumnName
            });

        public static string SQL_MAX(this sxc.tabular_name TableName, SqlColumnName ColumnName)
            => sql(MAX_TEMPLATE, new
            {
                TableName,
                ColumnName
            });

        public static ScalarResult<C> Min<T, C>(this ISqlTabularHandle<T> h, Expression<Func<T, C>> c)
            where T : class, ISqlTabularProxy, new()
        {
            var column = h.Broker.Metadata.Column<T>(c.GetMember().Name);
            var sql = h.ElementName.SQL_MIN(column.ColumnName);
            return h.Broker.ExecuteScalarScript<C>(sql);
        }

        public static ScalarResult<T> Min<T>(this ISqlTabularHandle h, SqlColumnName col)
                => h.Broker.ExecuteScalarScript<T>($"select min({col}) from {h.ElementName}");

        public static IEnumerable<V> Distinct<V>(this ISqlTabularHandle h, SqlColumnName ColumnName)
            => h.Broker.SelectColumn<V>($"select distinct({ColumnName}) from {h}");

        public static ScalarResult<V> Max<T, V>(this ISqlTabularHandle<T> h, Expression<Func<T, V>> c)
            where T : class, ISqlTabularProxy, new()
        {
            var column = h.Broker.Metadata.Column<T>(c.GetMember().Name);
            var sql = h.ElementName.SQL_MAX(column.ColumnName);
            return h.Broker.ExecuteScalarScript<V>(sql);
        }

        public static ScalarResult<V> Max<V>(this ISqlTabularHandle h, SqlColumnName ColumnName)            
            => h.Broker.ExecuteScalarScript<V>($"select max({ColumnName}) from {h.ElementName}");

        public static string SQL_EXISTS(this SqlDatabaseName database)
            => sql(database.IsServerQualified ? DatabaseExists_Qualified : DatabaseExists,
                new
                {
                    ServerName = database.ServerName,
                    DatabaseName = database.UnqualifiedName

                });
    }
}