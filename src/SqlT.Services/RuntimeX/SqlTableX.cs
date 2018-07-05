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
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Language;

    using static metacore;

    public static partial class SqlBrokerExtensions
    {
        static string sql(object value)
            => SqlClrValueFormatters.FormatClrValue(value);

        internal static string col<V, T>(Expression<Func<V, T>> ex)
            => ex.GetMember().Name;

        /// <summary>
        /// Retrieves a proxy-identfied column handle
        /// </summary>
        /// <typeparam name="T">The table proxy type</typeparam>
        /// <typeparam name="C">The column runtime data type</typeparam>
        /// <param name="h"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static SqlColumnHandle<T, C> Column<T, C>(this ISqlTableHandle<T> h, Expression<Func<T, C>> selector)
            where T : class, ISqlTableProxy, new()
                => new SqlColumnHandle<T, C>(h.Broker, h.Broker.Metadata.Column<T>(selector.GetMember().Name).ColumnName);

        /// <summary>
        /// Truncates the data in the underlying table
        /// </summary>
        /// <param name="h">A handle to the table that will be truncated</param>
        public static Option<int> TruncateIfExists(this ISqlTableHandle h)
        {
            var exists = h.Exists();
            if (exists.IsNone())
                return exists.ToNone<int>();
            else
            if (exists.Value() == SqlBooleanValue.False)
                return some(0, inform($"The table {h.ElementName} does not exist"));
            else
                return h.Broker.ExecuteNonQuery($"truncate table {h}");
        }

        /// <summary>
        /// Deletes the data in contained by the represented table
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Option<int> Delete(this ISqlTableHandle h)
            => h.Broker.ExecuteNonQuery($"delete {h}");

        /// <summary>
        /// Counts the records in the referenced table in the most naive manner possible
        /// </summary>
        /// <param name="h">Identifies the represented table</param>
        /// <returns></returns>
        public static Option<int> Count(this ISqlTableHandle h)
            => h.Broker.ExecuteScalarScript<int>($"select count(*) from {h}")
                       .TryMapValue(x => x);

        /// <summary>
        /// Drops the represented table
        /// </summary>
        /// <param name="h">Identifies the represented table</param>
        /// <returns></returns>
        public static Option<int> DropIfExists(this ISqlTableHandle h)
        {
            var exists = h.Exists();
            if (exists.IsNone())
                return exists.ToNone<int>();
            else if (exists.Value() == SqlBooleanValue.False)
                return some(0, inform($"The table {h.ElementName} does not exist"));
            else
                return h.Broker.ExecuteNonQuery($"drop table {h}");
        }

        /// <summary>
        /// Generates and applies a create table statement based on a proxy definition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="h"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        static Option<SqlTable> Create<T>(this ISqlTableHandle h, SqlTableName name)
            where T : ISqlTabularProxy, new()
        {            
            var typeInfo = h.Broker.ProxyBroker<T>().Metadata.Tabular<T>();
            var tableColumns = map(typeInfo.Columns, c => new SqlTableColumn(c.DefineSqlColumn()));
            var table = new SqlTable(name, tableColumns);
            var tSql = table.TSqlCreate();
            var script = tSql.GenerateScript();
            return h.Broker.ExecuteNonQuery(script)
                            .MapValueOrElse(_ => table, 
                                msg => none<SqlTable>(msg.ToApplicationMessage()));
        }

        /// <summary>
        /// Creates a table prdicated on a tabular proxy definition if it doesn't exist
        /// </summary>
        /// <typeparam name="T">The tabular proxy type</typeparam>
        /// <param name="h">The table handle</param>
        /// <param name="name">The name of  the table</param>
        /// <returns></returns>
        public static Option<SqlTable> CreateIfMissing<T>(this ISqlTableHandle h, SqlTableName name)
            where T : ISqlTabularProxy, new()
        {
            var exists = h.Exists();
            if (exists.IsNone())
                return exists.ToNone<SqlTable>();
            else if (exists.Value() == SqlBooleanValue.True)
                return none<SqlTable>(inform($"The table {name} exists"));
            else
                return h.Create<T>(name);
        }

        /// <summary>
        /// Selects a distinct column from a table
        /// </summary>
        /// <typeparam name="T">The table proxy type</typeparam>
        /// <typeparam name="C0">The type of value being selected</typeparam>
        /// <param name="h">The handle being extended</param>
        /// <param name="ex0">The selection expression</param>
        /// <returns></returns>
        public static IEnumerable<C0> Distinct<T, C0>(this ISqlTableHandle<T> h, Expression<Func<T, C0>> ex0)
            where T : ISqlTableProxy, new()
                => h.Broker.SelectColumn<C0>($"select distinct {col(ex0)} from {h}");

        public static SqlTableQuery Filter<V>(this SqlTableName resolvedTable,
            (SqlColumnName Name, V Value) filter)
            => new SqlTableQuery(SourceName: resolvedTable,
                        Script: new SqlScript(
                            $"select * from {resolvedTable.TrimServer()} where {filter.Name} = {sql(filter.Value)}"),
                        Filter: (filter.Name.UnqualifiedName, toString(filter.Value)));

        public static SqlTableQuery SelectTable<V>(this SqlServerName serverName, SqlDatabaseName srcDbName,
            SqlTableName srcTableName, (SqlColumnName Name, V Value) filter)
                => Filter(serverName + srcDbName + srcTableName, filter);

        public static SqlTableQuery Select<T, V>(this SqlTableHandle<T> h, Expression<Func<T, V>> filter, V filterValue)
            where T : class, ISqlTableProxy, new()
                => h.ConnectedServer.SelectTable(h.DefiningCatalog,
                    PXM.TableName<T>(), (filter.GetMember().Name, filterValue));
    }
}
