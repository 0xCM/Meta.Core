//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Syntax;

    using SqlT.Core;

    public static partial class contracts
    {
        public interface proxy_expression : IUnaryExpression
        {
            SqlTabularProxyInfo Source { get; }

        }


        public interface proxy_expression<p> : proxy_expression
            where p : ISqlTabularProxy
        {

        }

        public interface proxy_expression<e, p> : proxy_expression<p>, IUnaryExpression<e>
            where e : ISyntaxExpression
            where p : ISqlTabularProxy
        {
        }
    }
}