//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Models;
    using SqlT.Core;

    using static SqlT.Syntax.SqlProxySyntax;
    using static SqlT.Core.SqlProxyMetadataProvider;

    using sxc = contracts;

    partial class SqlProxySytaxExtensions
    {
        public static SqlColumnName ColumnName<P, C>(this Expression<Func<P, C>> selector)
            where P : ISqlTabularProxy, new()
                => ProxyMetadata<P>().Column<P>(selector.GetValueMember().Name).ColumnName;

        public static IReadOnlyList<SqlColumnProxyInfo> Columns<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTabularProxy, new()
                => selector.Tabular().Columns;

        public static IReadOnlyList<SqlColumnProxyInfo> Columns<T>(this Expression<Func<object, T>> selector)
            where T : class, ISqlTabularProxy, new()
                => ProxyMetadata<T>().Tabular<T>().Columns;

        public static IReadOnlyList<SqlColumnProxyInfo> Columns<T>(this Expression<Func<T, object>> selector)
            where T : class, ISqlTabularProxy, new()
                => ProxyMetadata<T>().Tabular<T>().Columns;

        public static IReadOnlyList<SqlColumnName> ColumnNames<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTabularProxy, new()
            => selector.Columns().Map(c => c.ColumnName);

        public static IReadOnlyList<SqlColumnName> ColumnNames<T>(this Expression<Func<T, object>> selector)
            where T : class, ISqlTabularProxy, new()
            => selector.Columns().Map(c => c.ColumnName);

        public static IEnumerable<SqlColumnProxyInfo> TableTypeColumns<P>(this IEnumerable<Expression<Func<P, object>>> selectors)
            where P : ISqlTableTypeProxy, new()
                => SqlTableTypeBuilder<P>.GetColumns(selectors);

        public static IEnumerable<SqlColumnProxyInfo> TableColumns<P>(this IEnumerable<Expression<Func<P, object>>> selectors)
            where P : ISqlTableTypeProxy, new()
                => SqlTableBuilder<P>.GetColumns(selectors);

        public static column_expression<T> SyntaxColumn<T>(this SqlColumnProxyInfo c)
             where T : ISqlTabularProxy, new()
                => new column_expression<T>(c);

        public static column_expression<T> SyntaxColumn<T, C>(this Expression<Func<T, C>> selector)
             where T : class, ISqlTabularProxy, new()
            => PXM.Tabular<T>().FindColumnByRuntimeName(selector.GetValueMemberName()).SyntaxColumn<T>();
    }
}