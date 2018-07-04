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
    using System.Reflection;
    using System.Linq;

    using Meta.Syntax;

    using static contracts;
    using sxc = contracts;

    partial class SqlSyntax
    {
        public class sqlops   : TypedItemList<sqlops, IOperator>
        {

            public static readonly assignment_op ASSIGN = assignment_op.get();

            //Comparison operators
            public static readonly eq_op EQ = eq_op.get();
            public static readonly gteq_op GTEQ = gteq_op.get();
            public static readonly ngt_op NGT = ngt_op.get();
            public static readonly nlt_op NLT = nlt_op.get();
            public static readonly neq_op NEQ = neq_op.get();
            public static readonly lteq_op LTEQ = lteq_op.get();
            public static readonly gt_op GT = gt_op.get();
            public static readonly lt_op LT = lt_op.get();

            //Set operators
            public static readonly except_op EXCEPT  = except_op.get();
            public static readonly union_op UNION = union_op.get();
            public static readonly intersect_op INTERSECT = intersect_op.get();

            //Logical operators
            public static readonly some_op SOME = some_op.get();
            public static readonly all_op ALL = all_op.get();
            public static readonly or_op OR = or_op.get();
            public static readonly not_op NOT = not_op.get();
            public static readonly and_op AND = and_op.get();
            public static readonly like_op LIKE = like_op.get();
            public static readonly between_op BETWEEN = between_op.get();
            public static readonly any_op ANY = any_op.get();
            public static readonly not_op EXISTS = not_op.get();
            public static readonly in_op IN = in_op.get();

            //Bitwise operators
            public static readonly bw_not_op BW_NOT = bw_not_op.get();
            public static readonly bw_or_op BW_OR = bw_or_op.get();
            public static readonly bw_andeq_op BW_ANDEQ = bw_andeq_op.get();
            public static readonly bw_and_op BW_AND = bw_and_op.get();
            public static readonly bw_xoreq_op BW_XOREQ = bw_xoreq_op.get();
            public static readonly bw_oreq_op BW_OREQ = bw_oreq_op.get();
            public static readonly bw_xor_op BW_XOR = bw_xor_op.get();

            //Arithmetic operators
            public static readonly sub_op SUB = sub_op.get();
            public static readonly mul_op MUL = mul_op.get();
            public static readonly mod_op MOD = mod_op.get();
            public static readonly div_op DIV = div_op.get();
            public static readonly add_op ADD = add_op.get();

            //Compound arithmetic operators
            public static readonly sub_assign_op SUBASSIGN = sub_assign_op.get();
            public static readonly add_assign_op ADDASSIGN = add_assign_op.get();
            public static readonly mul_assign_op MULASSIGN = mul_assign_op.get();
            public static readonly div_assign_op DIVASSIGN = div_assign_op.get();
            public static readonly mod_assign_op MODASSIGN = mod_assign_op.get();

            //Unary operators
            public static readonly neg_op NEG = neg_op.get();
            public static readonly pos_op POS = pos_op.get();
            public static readonly dollar_op DOLLAR = dollar_op.get();




        }
    }
}