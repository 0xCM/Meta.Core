//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;    
    using static SqlT.Core.SqlProxyMetadataProvider;
    using static SqlT.Syntax.SqlProxySyntax;

    using sx = SqlT.Syntax.SqlSyntax;

    public sealed class SqlSelectBuilder<P> : SqlSelectBuilder<SqlSelectBuilder<P>, P>
       where P : ISqlTabularProxy, new()
    {
        static Lazy<SqlTabularProxyInfo> _Tabular
            = defer(() => ProxyMetadata<P>().Tabular<P>());

        static SqlTabularProxyInfo Tabular
            => _Tabular.Value;

        static SqlColumnProxyInfo colinfo(Expression<Func<P, object>> selector)
            => Tabular.FindColumnByRuntimeName(selector.GetValueMemberName());

        static SqlColumnProxyInfo colinfo<c>(Expression<Func<P, c>> selector)
            => Tabular.FindColumnByRuntimeName(selector.GetValueMemberName());

        static SqlColumnProxyInfo colinfo(Expression<Func<P, bool>> predicate)
            => Tabular.FindColumnByRuntimeName(predicate.GetValueMemberName());

        static SqlColumnName colname(Expression<Func<P, object>> selector)
            => colinfo(selector).ColumnName;

        static SqlColumnName colname(Expression<Func<P, bool>> predicate)
            => colinfo(predicate).ColumnName;

        static SqlColumnName colname<C>(Expression<Func<P, C>> selector)
            => colinfo(selector).ColumnName;

        public SqlSelectBuilder()
        {
            Columns(Tabular.Columns.Select(c => c.ColumnName));
        }

        public Builder<SqlSelectBuilder<P>> OrderBy(Expression<Func<P, object>> selector, sx.sort_direction direction = null)
        {
            var orderby = new sort_column<P>(selector, direction ?? sx.DESC);
            return this;
        }

        public Builder<SqlSelectBuilder<P>> OrderBy(params Expression<Func<P, object>>[] selectors)
        {
            var orderbys = map(selectors, selector => new sort_column<P>(selector, sx.DESC));
            return this;
        }

        public Builder<SqlSelectBuilder<P>> OrderBy(sx.sort_direction direction, params Expression<Func<P, object>>[] selectors)
        {
            var orderbys = map(selectors, selector => new sort_column<P>(selector, direction));
            return this;
        }

        public Builder<SqlSelectBuilder<P>> And<C>(Expression<Func<P, C>> selector)
        {
            return this;
        }

        public Builder<SqlSelectBuilder<P>> OrderBy<C>(Expression<Func<P, C>> selector,
            sort_direction_kind? direction = null,
            string collation = null)
        {
            var column = (from col in Tabular.Columns
                          let m = selector.GetValueMember()
                          where isNotNull(m) && col.RuntimeName == m.Name
                          select col.ColumnName).TryGetFirst();
            if (column)
                OrderBy(column.ValueOrDefault(), direction, collation);
            return this;
        }
    }
}