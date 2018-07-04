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

    using Meta.Syntax;

    using static SqlSyntax;

    using static metacore;
    using sxc = contracts;    

    public static partial class sql
    {

        public static between_expression between<t>(ISyntaxExpression test_expression, t begin_value, t end_value)
            where t : ISyntaxExpression
                => new between_expression(test_expression, begin_value, end_value);


    }
}