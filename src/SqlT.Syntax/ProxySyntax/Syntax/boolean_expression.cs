//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;
    using SqlT.Core;

    using sxc = Syntax.contracts;
    

    partial class SqlProxySyntax
    {

        public sealed class boolean_expression<p> : SyntaxExpression<boolean_expression<p>>, sxc.proxy_expression<p> , IBooleanExpression
            where p : ISqlTabularProxy
        {
            public boolean_expression()
            {

            }

            SqlTabularProxyInfo sxc.proxy_expression.Source
                => throw new NotImplementedException();

            ISyntaxExpression IUnaryExpression.Operand
                => this;
        }
    }
}