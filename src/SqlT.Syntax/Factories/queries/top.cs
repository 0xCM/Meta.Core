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
    using SqlT.Core;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using static SqlSyntax;

    public static partial class sql
    {

        public static top_clause top(sxc.scalar_expression expression)
            => new top_clause(expression);

        public static top_clause top(sxc.scalar_expression expression, kwt.PERCENT PERCENT)
            => new top_clause(expression, true);

        public static top_clause top(sxc.scalar_expression expression, kwt.WITH WITH, kwt.TIES TIES)
            => new top_clause(expression, false, true);

        public static top_clause top(sxc.scalar_expression expression, kwt.PERCENT PERCENT, kwt.WITH WITH, kwt.TIES TIES)
            => new top_clause(expression, true, true);
    }

}