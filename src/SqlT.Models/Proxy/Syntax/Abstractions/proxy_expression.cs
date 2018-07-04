// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;

    using static SqlT.Core.SqlProxyMetadataProvider;
    using sxc = Syntax.contracts;
    using sx = Syntax.SqlSyntax;


    /// <summary>
    /// Ultimate supertype for expressions with proxy parametrizations
    /// </summary>
    /// <typeparam name="e">The expression type that is effectively being parametrized</typeparam>
    /// <typeparam name="p">The proxy type</typeparam>
    public abstract class proxy_expression<e, p> : UnaryExpression<e>, sxc.proxy_expression<e,p>
        where e : ISyntaxExpression
        where p : ISqlTabularProxy, new()
    {
        protected static SqlTabularProxyInfo tabular 
            = ProxyMetadata<p>().Tabular<p>();

        protected proxy_expression(e operand)
            : base(operand)
        {

        }

        public SqlTabularProxyInfo Source
            => tabular;

    }

}