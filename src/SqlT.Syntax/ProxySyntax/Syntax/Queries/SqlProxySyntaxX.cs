//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Syntax;

    using SqlT.Core;

    using static SqlT.Syntax.SqlSyntax;
    using static SqlT.Core.SqlProxyMetadataProvider;
    using static SqlT.Syntax.SqlProxySyntax;

    using sxc = contracts;
    
    public static partial class SqlProxySytaxExtensions
    {

        public static sxc.tabular_name TabularName<T, C>(this Expression<Func<T, C>> selector)
            where T : class, ISqlTabularProxy, new()
                => ProxyMetadata<T>().Tabular<T>().ObjectName;

        public static SqlTabularProxyInfo Tabular<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTabularProxy, new()
                => ProxyMetadata<T>().Tabular<T>();

        public static sxc.tabular_name TabularName<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTabularProxy, new()
                => ProxyMetadata<T>().Tabular<T>().ObjectName;

        public static SqlTableProxyInfo Table<T>(this Expression<Func<T, object>> selector)
            where T : class, ISqlTableProxy, new()
                => ProxyMetadata<T>().Table<T>();

        public static SqlTableProxyInfo Table<T>(this Expression<Func<object, T>> selector)
            where T : class, ISqlTableProxy, new()
                => ProxyMetadata<T>().Table<T>();

        public static SqlTableName TableName<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTableProxy, new()
                => ProxyMetadata<T>().Table<T>().ObjectName;

        public static SqlTableName TableName<T,C>(this Expression<Func<T,C>> selector)
            where T : class, ISqlTableProxy, new()
                => ProxyMetadata<T>().Table<T>().ObjectName;

        public static SqlTableTypeProxyInfo TableType<T>(this Expression<Func<T, object>> selector)
            where T : class, ISqlTableTypeProxy, new()
                => ProxyMetadata<T>().TableType<T>();

        public static SqlTableTypeName TableTypeName<T>(this Expression<Func<T>> selector)
            where T : class, ISqlTableTypeProxy, new()
                => ProxyMetadata<T>().TableType<T>().ObjectName;

        public static SqlTableTypeName TableTypeName<T, C>(this Expression<Func<T, C>> selector)
            where T : class, ISqlTableTypeProxy, new()
                => ProxyMetadata<T>().TableType<T>().ObjectName;

        public static SqlViewProxyInfo View<T>(this Expression<Func<T, object>> selector)
            where T : class, ISqlViewProxy, new()
                => ProxyMetadata<T>().View<T>();

        public static SqlViewName ViewName<T>(this Expression<Func<T>> selector)
            where T : class, ISqlViewProxy, new()
                => ProxyMetadata<T>().View<T>().ObjectName;

        public static SqlViewName ViewName<T, C>(this Expression<Func<T, C>> selector)
            where T : class, ISqlViewProxy, new()
                => ProxyMetadata<T>().View<T>().ObjectName;

        public static alias_expression<e, p> ToSyntaxAlias<e, p>(this sxc.proxy_expression<e, p> x, string name)
            where e : ISyntaxExpression
            where p : ISqlTabularProxy, new()
                => new alias_expression<e, p>(x.Operand, name);

        public static procedure<P> SyntaxElement<P>(this P proxy)
            where P : class, ISqlProcedureProxy<P>, new()
            => new procedure<P>(proxy);

        public static procedure<P, R> SyntaxElement<P, R>(this P proxy)
            where P : class, ISqlProcedureProxy<P, R>, new()
            where R : class, ISqlTabularProxy, new()
            => new procedure<P, R>(proxy);

        public static ISyntaxExpression SyntaxExec<P, R>(this P proxy, params routine_argument[] args)
            where P : class, ISqlProcedureProxy<P, R>, new()
            where R : class, ISqlTabularProxy, new()
                => new procedure_call<procedure<P, R>, R>(proxy.SyntaxElement<P, R>(), args);

        public static sxc.procedure_call SyntaxExec<P>(this P proxy, params routine_argument[] args)
            where P : class, ISqlProcedureProxy<P>, new()
                => new procedure_call<procedure<P>>(proxy.SyntaxElement(), args);
    }

}