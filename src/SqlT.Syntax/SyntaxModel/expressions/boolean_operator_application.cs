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
    using SqlT.Core;

    using sxc = contracts;
    using sx = SqlSyntax;

    partial class SqlSyntax
    {
        public abstract class boolean_operator_application<O> : sx.operator_application<O>, IBooleanExpression
            where O : IBooleanOperator
        {
            public boolean_operator_application(O op, params ISyntaxExpression[] Operands)
                : base(op, Operands)
            {

            }


        }


        public sealed class boolean_operator_application<o, e> : boolean_operator_application<o>, IBooleanExpression<e>
            where o : IBooleanOperator
            where e : ISyntaxExpression
        {
            public boolean_operator_application(o Operator, e Operand)
                : base(Operator, Operand)
            {
                this.Operand = Operand;
            }


            public e Operand { get; }

            public override string ToString()
                => $"{applied_operator.Symbol} {Operand}";

        }


        public sealed class boolean_operator_application<O, L, R> : boolean_operator_application<O>, IBooleanExpression<L, R>
                where O : IBooleanOperator
                where L : ISyntaxExpression
                where R : ISyntaxExpression
        {
            public boolean_operator_application(O Operator, L Left, R Right)
                : base(Operator, Left, Right)
            {
                this.Left = Left;
                this.Right = Right;
            }

            public L Left { get; }
            public R Right { get; }

            public override string ToString()
                => $"{Left} {applied_operator.Symbol} {Right}";

        }



    }

}