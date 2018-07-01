//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;    

    public sealed class UnaryOperatorApplication<OP, T> : OperatorApplication<OP>
        where OP : UnaryOperator<OP>
    {
        public UnaryOperatorApplication(UnaryOperator<OP> Operator, T Operand)
            : base(Operator, Operand)
        {

        }

        public T Operand => (T)Operands[0];

        public override string ToString()
            => $"{Operator}({Operand})";
    }
}
