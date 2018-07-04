//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using sxc = contracts;

    using Meta.Syntax;
    using Meta.Models;


    partial class SqlSyntax
    {
        public sealed class logical_expression : SyntaxExpression<logical_expression>, ILogicalExpression
        {

            public logical_expression(ILogicalOperator op, ISyntaxExpression operand)
            {
                this.op = op;
                this.Left = operand;
                this.Right = operand;
            }

            public logical_expression(ILogicalOperator op, ISyntaxExpression left, ISyntaxExpression right)
            {
                this.op = op;
                this.Left = left;
                this.Right = right;
            }


            public ILogicalOperator op { get; }
           

            public ISyntaxExpression Left { get; }

            public ISyntaxExpression Right { get; }

            ILogicalOperator ILogicalExpression.Operator
                => op;

            public override string ToString()
                => $"{Left} {op} {Right}";
        }




    }


}