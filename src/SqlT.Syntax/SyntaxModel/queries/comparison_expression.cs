//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    
    using Meta.Syntax;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class comparison_expression : BooleanExpression<comparison_expression>, sxc.comparison_expression
        {

            public static implicit operator comparison_predicate(comparison_expression e)
                => new comparison_predicate(e);

            public comparison_expression(IComparisonOperator op, ISyntaxExpression left, ISyntaxExpression right)
            {
                this.op = op;
                this.Left = left;
                this.Right = right;
            }

            public IComparisonOperator op { get; }

            public ISyntaxExpression Left { get; }

            public ISyntaxExpression Right { get; }

            public comparison_predicate predicate()
                => new comparison_predicate(this);
        }
    }
}