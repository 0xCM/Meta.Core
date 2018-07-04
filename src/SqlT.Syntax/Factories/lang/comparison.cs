//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using static SqlSyntax;

    using Meta.Syntax;

    using static metacore;    
    using sxc = contracts;
    using static sql;

    

    partial class sql
    {
        public static comparison_expression gt<T>(T left, T right)
           where T : struct => new comparison_expression(gt_op.get(), L(left), L(right));

        public static comparison_expression gt(string left, string right)
            => new comparison_expression(gt_op.get(), L(left), L(right));

        public static comparison_expression gt(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(gt_op.get(), left, right);


        public static comparison_expression eq<T>(T left, T right)
           where T : struct => new comparison_expression(eq_op.get(), L(left), L(right));

        public static comparison_expression eq(string left, string right)
            => new comparison_expression(eq_op.get(), L(left), L(right));

        public static comparison_expression eq(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(eq_op.get(), left, right);

        public static comparison_expression gteq<T>(T left, T right)
            where T : struct => new comparison_expression(gteq_op.get(), L(left), L(right));

        public static comparison_expression gteq(string left, string right)
            => new comparison_expression(gteq_op.get(), L(left), L(right));

        public static comparison_expression gteq(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(gteq_op.get(), left, right);

        public static comparison_expression neq<T>(T left, T right)
          where T : struct => new comparison_expression(neq_op.get(), L(left), L(right));

        public static comparison_expression neq(string left, string right)
            => new comparison_expression(neq_op.get(), L(left), L(right));

        public static comparison_expression neq(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(neq_op.get(), left, right);

        public static comparison_expression lt(int left, int right)
                => new comparison_expression(lt_op.get(), L(left), L(right));

        public static comparison_expression lt(string left, string right)
            => new comparison_expression(lt_op.get(), L(left), L(right));

        public static comparison_expression lt(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(lt_op.get(), left, right);

        public static comparison_expression lteq<T>(T left, T right)
          where T : struct => new comparison_expression(lteq_op.get(), L(left), L(right));

        public static comparison_expression lteq(string left, string right)
            => new comparison_expression(lteq_op.get(), L(left), L(right));

        public static comparison_expression lteq(ISyntaxExpression left, ISyntaxExpression right)
            => new comparison_expression(lteq_op.get(), left, right);
    }

}