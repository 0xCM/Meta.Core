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

    using static metacore;
    using sxc = contracts;

    partial class SqlSyntax
    {

        public class operator_application<o> : SyntaxExpression<operator_application<o>>, sxc.operator_application<o>
            where o : IOperator
        {

            public operator_application(o applied_operator, params ISyntaxExpression[] operands)
            {
                this.applied_operator = applied_operator;
                this.operands = operands.ToList();
            }

            public IReadOnlyList<ISyntaxExpression> operands { get; }

            IOperator sxc.operator_application.applied_operator
                => applied_operator;

            public o applied_operator { get; }

            public override string ToString()
            {
                var arglist = string.Join(",", map(operands, p => p.ToString()));
                var description = $"{applied_operator.Symbol}({arglist})";
                return description;
            }

        }

        public sealed class operator_application : operator_application<IOperator>
        {
            public operator_application(IOperator applied_operator, params ISyntaxExpression[] operands)
                : base(applied_operator, operands)
            {
            }
        }
    }   
}