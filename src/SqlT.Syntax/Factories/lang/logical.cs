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

        public static logical_expression and<t>(t left, t right)
           where t : IBooleanExpression 
                => new logical_expression(and_op.get(), left, right);

        public static logical_expression not<t>(t operand)
            where t : IBooleanExpression
            => new logical_expression(not_op.get(), operand);

        public static logical_expression or<t>(t left, t right)
            where t : IBooleanExpression
                => new logical_expression(sqlops.OR, left, right);


    }

}