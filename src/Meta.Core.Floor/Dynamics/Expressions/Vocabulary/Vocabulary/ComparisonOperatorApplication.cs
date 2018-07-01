//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class ComparisonOperatorApplication<OP, T> : OperatorApplication<OP>
        where OP : BinaryOperator<OP>
    {
        public ComparisonOperatorApplication(BinaryOperator<OP> Operator, T Left, T Right)
            : base(Operator, Left, Right)
        {
        }

        public T Left => (T)Operands[0];

        public T Right => (T)Operands[1];


        public override string ToString()
            => $"{Left} {Operator} {Right}";
    }
}
