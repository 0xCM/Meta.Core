//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    using B = SqlIndexBuilder;

    public class SqlIndexBuilder : SqlModelBuilder<SqlIndex>
    {

        SqlIndexName IndexName;
        SqlTableName TableName;
        bool unique = false;
        bool clustered = false;
        MutableList<SqlIndexColumn> columns = MutableList.Create<SqlIndexColumn>();
        MutableList<SqlIndexColumn> inclusions = MutableList.Create<SqlIndexColumn>();

        protected SqlIndexBuilder(SqlTableName TableName, params SqlColumnName[] columns)
        {
            this.TableName = TableName;
            this.IndexName = $"IX_{TableName.UnqualifiedName}"
                      + (columns.Length > 0 ? $"_{columns[0].UnqualifiedName}" : String.Empty);
            this.columns.AddRange(columns.Select(c => new SqlIndexColumn(c, true)));
        }

        internal SqlIndexBuilder(SqlIndexName IndexName, SqlTableName TableName, params SqlColumnName[] columns)
        {
            this.IndexName = IndexName;
            this.TableName = TableName;
            this.columns.AddRange(columns.Select(c => new SqlIndexColumn(c, true)));
        }

        public Builder<B> OnColumn(SqlColumnName column, bool ascending = true)
        {
            columns.Add(new SqlIndexColumn(column, ascending));
            return this;
        }

        public Builder<B> Include(params SqlColumnName[] columns)
        {
            this.inclusions.AddRange(columns.Select(c => new SqlIndexColumn(c)));
            return this;
        }

        public Builder<B> OnAscendingColumns(params SqlColumnName[] columns)
        {
            this.columns.AddRange(columns.Select(c => new SqlIndexColumn(c, true)));
            return this;
        }

        public Builder<B> OnDescendingColumns(params SqlColumnName[] columns)
        {
            this.columns.AddRange(columns.Select(c => new SqlIndexColumn(c, false)));
            return this;
        }

        public Builder<B> Cluster(bool clustered = true)
        {
            this.clustered = clustered;
            return this;
        }

        public Builder<B> Unique(bool unique = true)
        {
            this.unique = unique;
            return this;
        }

        public Builder<SqlDropIndexBuilder> Drop(bool CheckExistence = true)
            => new SqlDropIndexBuilder(TableName, IndexName, CheckExistence);

        public override SqlIndex Complete()
            => new SqlIndex(IndexName, TableName, columns, inclusions, clustered, unique);


    }

    /// <summary>
    /// Constructs in index for a proxy-identified table
    /// </summary>
    /// <typeparam name="P">The table proxy type</typeparam>
    public sealed class SqlIndexBuilder<P> : B
        where P : ISqlTableProxy, new()
    {

        static Lazy<SqlTableProxyInfo> _ProxyInfo
            = defer(() => SqlProxyMetadataProvider.ProxyMetadata<P>().Table<P>());

        static SqlTableProxyInfo TableProxy => _ProxyInfo.Value;

        public SqlIndexBuilder(SqlIndexName IndexName)
            : base(IndexName, TableProxy.ObjectName)
        {

        }
        public SqlIndexBuilder(params Expression<Func<P, object>>[] columns)
            : base(TableProxy.ObjectName, GetColumns(columns).Select(x => new SqlColumnName(x.ColumnName)).ToArray())
        {

        }

        public new Builder<SqlIndexBuilder<P>> Unique(bool unique = true)
        {
            base.Unique();
            return this;
        }

        static IEnumerable<SqlColumnProxyInfo> GetColumns(IEnumerable<Expression<Func<P, object>>> selectors)
            => from selector in selectors
               let property = selector.GetProperty()
               select TableProxy.Columns.Single(c => c.ClrElement as PropertyInfo == property);


        public Builder<SqlIndexBuilder<P>> OnDescendingColumns(params Expression<Func<P, object>>[] selectors)
        {
            iter(GetColumns(selectors),
                col => OnColumn(new SqlColumnName(col.ColumnName), false));
            return this;
        }

        public Builder<SqlIndexBuilder<P>> OnColumns(params Expression<Func<P, object>>[] selectors)
        {
            iter(GetColumns(selectors), col
                => OnColumn(new SqlColumnName(col.ColumnName), true));
            return this;
        }

        public Builder<SqlIndexBuilder<P>> Include(params Expression<Func<P, object>>[] selectors)
        {
            iter(GetColumns(selectors),
                col => Include(new SqlColumnName(col.ColumnName)));
            return this;
        }
    }
}