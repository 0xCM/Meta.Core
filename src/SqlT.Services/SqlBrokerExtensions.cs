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
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlT.Syntax.SqlFunctions;
    using static SqlT.Syntax.SqlSyntax;
    
    using sxc = SqlT.Syntax.contracts;

    static partial class SqlBrokerExtensions
    {
        public static ISqlProxyBroker ProxyBroker<T>(this ISqlClientBroker cb)
            where T : ISqlProxy, new()
                => SqlProxyBroker.CreateBroker<T>(cb.ConnectionString).Require();

        public static ISqlIndexHandle Index(this ISqlTabularBroker broker, SqlIndexName IndexName)
            => new SqlIndexHandle(broker.InnerBroker, broker.TabularInfo.ObjectName.AsTableName(), IndexName);

        public static ISqlIndexHandle Index(this ISqlProxyBroker broker, SqlTableName TableName, SqlIndexName IndexName)
            => new SqlIndexHandle(broker, TableName, IndexName);

        public static ISqlIndexHandle Index<T>(this ISqlTabularBroker<T> broker, SqlIndexName IndexName)
                where T : class, ISqlTableProxy, new()
            => new SqlIndexHandle(broker.InnerBroker, broker.TabularInfo.ObjectName.AsTableName(), IndexName);

        public static ISqlViewHandle View(this ISqlProxyBroker broker, SqlViewName ViewName)
                => new SqlViewHandle(broker, ViewName);

        public static ISqlViewHandle<T> View<T>(this ISqlProxyBroker broker)
            where T : class, ISqlViewProxy, new()
            => new SqlViewHandle<T>(broker);

        public static ISqlViewHandle View(this ISqlTabularBroker broker)
                => new SqlViewHandle(broker.InnerBroker, broker.BrokeredObjectName.AsViewName());

        public static ISqlViewHandle<T> View<T>(this ISqlTabularBroker broker)
            where T : class, ISqlViewProxy, new()
            => new SqlViewHandle<T>(broker.InnerBroker);

        public static ISqlTableHandle Table(this ISqlProxyBroker broker, SqlTableName TableName)
                => new SqlTableHandle(broker, TableName);

        public static ISqlTableHandle Table(this ISqlTabularBroker broker)
            => new SqlTableHandle(broker.InnerBroker, broker.BrokeredObjectName.AsTableName());

        public static ISqlTableTypeHandle TableType(this ISqlProxyBroker broker, SqlTableTypeName TypeName)
                => new SqlTableTypeHandle(broker, TypeName);

        public static ISqlTableTypeHandle<T> TableType<T>(this ISqlProxyBroker broker)
            where T : class, ISqlTableTypeProxy, new()
                => new SqlTableTypeHandle<T>(broker);

        public static ISqlTableTypeHandle TableType(this ISqlTabularBroker broker)
                => new SqlTableTypeHandle(broker.InnerBroker, broker.BrokeredObjectName.AsTableTypeName());

        public static ISqlTableTypeHandle<T> TableType<T>(this ISqlTabularBroker broker)
            where T : class, ISqlTableTypeProxy, new()
                => new SqlTableTypeHandle<T>(broker.InnerBroker);

        public static ISqlTabularHandle Tabular(this ISqlProxyBroker broker, sxc.tabular_name TabularName)
        {
            switch(TabularName)
            {
                case SqlViewName n:
                    return new SqlViewHandle(broker, n);
                case SqlTableName n:
                    return new SqlTableHandle(broker, n);
                case SqlTableTypeName n:
                    return new SqlTableTypeHandle(broker, n);
                default:
                    throw new NotSupportedException($"The tabular {TabularName} is unrecognized");
            }            
        }

        static string concat(params string[] values)
            => string.Join(space(), values);

        public static ScalarResult<C> Max<T, C>(this ISqlTabularBroker<T> broker, Expression<Func<T, C>> selector)
            where T : class, ISqlTabularProxy, new()
        {
            var column = selector.SyntaxColumn();
            var src = column.Source.ObjectName.ToString();
            var sql = concat(SELECT, column.Max().FormatSyntax(), FROM, src);
            return broker.ExecuteScalarScript<C>(sql);
        }

        public static ScalarResult<C> Min<T, C>(this ISqlTabularBroker<T> broker, Expression<Func<T, C>> selector)
            where T : class, ISqlTabularProxy, new()
        {
            var column = selector.SyntaxColumn();
            var src = column.Source.ObjectName.ToString();
            var sql = concat(SELECT, column.Min().FormatSyntax(), FROM, src);
            return broker.ExecuteScalarScript<C>(sql);
        }

        static Builder<SqlSelectBuilder<T>> Where<T>(this ISqlTabularBroker<T> broker)
             where T : class, ISqlTabularProxy, new()
                => new SqlSelectBuilder<T>();

        public static Builder<SqlSelectBuilder<T>> Query<T>(this ISqlProxyBroker broker)
             where T : class, ISqlTabularProxy, new()
                => new SqlTabularBroker<T>(broker).Where();

        public static ScalarResult<C> Min<C>(this ISqlProxyBroker broker, SqlTableName table, SqlColumnName column)
        {
            var sql = concat(SELECT, column.Min().FormatSyntax(), FROM, table);
            return broker.ExecuteScalarScript<C>(sql);
        }

        public static ScalarResult<C> Max<C>(this ISqlProxyBroker broker, SqlTableName table, SqlColumnName column)
        {
            var sql = concat(SELECT, column.Max().FormatSyntax(), FROM, table);
            return broker.ExecuteScalarScript<C>(sql);
        }

        public static ScalarResult<int> Count<T, C>(this ISqlTabularBroker<T> broker, Expression<Func<T, C>> selector, Range<C> window)
            where T : class, ISqlTabularProxy, new()
            where C : IComparable
        {
            var column = selector.SyntaxColumn();
            var src = column.Source.ObjectName.ToString();
            var sql = concat(SELECT, $"{COUNT}{lparen()}{STAR}{rparen()}",
                        FROM, src, WHERE, column.AsNameExpression().FormatSyntax(),
                        BETWEEN,
                        CoreDataValue.Require(window.Min).ToSqlLiteral().FormatSyntax(),
                        AND,
                        CoreDataValue.Require(window.Max).ToSqlLiteral().FormatSyntax());
            return broker.ExecuteScalarScript<int>(sql);
        }

        public static Option<IReadOnlyList<T>> Select<T>(this ISqlProxyBroker broker)
           where T : class, ISqlTabularProxy, new()
               => broker.Get<T>(string.Empty).ToOption();

        public static IReadOnlyList<C> SelectPagedColumn<T, C>(this ISqlProxyBroker broker,
            Expression<Func<T, C>> columnSelector, int pageSize, int pageNumber)
                where T : class, ISqlTabularProxy, new()
        {
            var srcName = broker.QualifiedName<T>();
            var column = broker.ColumnDescription(columnSelector);
            var colName = column.ColumnName;
            var offset = pageSize * (pageNumber - 1);
            var sql = $"select {colName} from {srcName} order by {colName} offset {offset} rows fetch next {pageSize} rows only";
            return broker.SelectColumn<C>(sql).ToList();
        }

        public static SqlOutcome<IReadOnlyList<T>> SelectTop<T, C>(this ISqlProxyBroker broker, int count, Expression<Func<T, C>> selector)
            where T : class, ISqlTabularProxy, new()
            where C : IComparable
        {
            var srcName = broker.QualifiedName<T>();
            var colName = broker.ColumnDescription(selector).ColumnName;
            var sql = $"select top({count}) * from {srcName} order by {colName}";
            return broker.Get<T>(sql);
        }

        public static Option<IReadOnlyList<T>> SelectTop<T, C>(this ISqlTabularBroker<T> broker, int count, Expression<Func<T, C>> orderby)
             where T : class, ISqlTabularProxy, new()
            where C : IComparable
        {
            var srcName = broker.QualifiedName<T>();
            var colName = broker.ColumnDescription(orderby).ColumnName;
            var sql = $"select top({count}) * from {srcName} order by {colName}";
            return broker.Get(sql);
        }

        public static ISqlTabularHandle Tabular<T>(this ISqlProxyBroker broker)
            where T : class, ISqlTabularProxy, new()
                => broker.Tabular(broker.Metadata.Tabular<T>().ObjectName);

        public static ISqlTabularHandle Tabular<T>(this ISqlTabularBroker broker)
            where T : class, ISqlTabularProxy, new()
                => broker.InnerBroker.Tabular(broker.Metadata.Tabular<T>().ObjectName);

        public static ScalarResult<int> Count<T>(this ISqlProxyBroker h)
            where T : class, ISqlTabularProxy, new()
                => h.Tabular<T>().Count();

        public static ScalarResult<int> CountDistinct<T>(this ISqlProxyBroker broker, SqlColumnName col)
                where T : class, ISqlTabularProxy, new()
            => broker.Tabular<T>().CountDistinct(col);

        public static ScalarResult<int> CountDistinct<T>(this ISqlTabularBroker broker, SqlColumnName col)
                where T : class, ISqlTabularProxy, new()
            => broker.Tabular<T>().CountDistinct(col);

        public static IEnumerable<V> Distinct<T,V>(this ISqlTabularBroker<T> broker, SqlColumnName ColumnName)
            where T : class, ISqlTabularProxy, new()
            => broker.SelectColumn<V>($"select distinct({ColumnName}) from {broker.BrokeredObjectName}");

        public static ScalarResult<V> Max<T, V>(this ISqlProxyBroker broker, Expression<Func<T, V>> selector)
            where T : class, ISqlTabularProxy, new()
            where V : struct
                => broker.ExecuteScalarScript<V>($"select max({selector.ColumnName()}) from {selector.TabularName()}");

        public static IEnumerable<V> Distinct<T, V>(this ISqlProxyBroker broker, Expression<Func<T,V>> selector)
            where T : class, ISqlTabularProxy, new()
            => broker.SelectColumn<V>($"select distinct({selector.ColumnName()}) from {selector.TabularName()}");

        public static ScalarResult<C> Min<C>(this ISqlProxyBroker broker, SqlColumnName ColumnName)
                => broker.ExecuteScalarScript<C>($"select min({ColumnName}) from {ColumnName}");

        public static ScalarResult<C> Min<T, C>(this ISqlProxyBroker broker, Expression<Func<T, C>> selector)
            where T : class, ISqlTabularProxy, new()            
                => broker.ExecuteScalarScript<C>($"select min({selector.ColumnName()}) from {selector.TabularName()}");

        public static Option<int> SelectInto<Src>(this ISqlTabularBroker broker, SqlTableName DstTable)
            where Src : class, ISqlTabularProxy, new()
            => broker.InnerBroker.ExecuteNonQuery(SqlScript.FromText("select * into @Target from @Source",
                new
                {
                    Source = broker.BrokeredObjectName,
                    Target = DstTable,
                })).ToOption();

        public static Option<int> SelectInto<Src>(this ISqlProxyBroker broker, Src SrcTabular, SqlTableName DstTable)
            where Src : class, ISqlTabularProxy, new()
            => broker.ExecuteNonQuery(SqlScript.FromText("select * into @Target from @Source",
                new
                {
                    Source = broker.Metadata.Tabular<Src>().ObjectName,
                    Target = DstTable,
                })).ToOption();
    }


}