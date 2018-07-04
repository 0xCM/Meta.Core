//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using Meta.Models;
    using Meta.Syntax;

    partial class SqlSyntax
    {

        public sealed class comparision_expression : SyntaxExpression<comparision_expression>
        {

            public comparision_expression(comparison_operator op, ISyntaxExpression left, ISyntaxExpression right)
            {
                this.op = op;
                this.left = left;
                this.right = right;
            }

            public comparison_operator op { get; }

            public ISyntaxExpression left { get; }

            public ISyntaxExpression right { get; }

            public override string ToString()
                => $"{left} {op} {right}";
        }
    }

}