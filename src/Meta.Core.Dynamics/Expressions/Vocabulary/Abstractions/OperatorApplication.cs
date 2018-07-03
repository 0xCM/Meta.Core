//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;    
    using System.Linq;


    /// <summary>
    /// Represents the application of an operator to a set of operands
    /// </summary>
    /// <typeparam name="O"></typeparam>
    public abstract class OperatorApplication<O> : IOperatorApplication
        where O : Operator<O>
    {

        protected OperatorApplication(IOperator Operator, params object[] Operands)
        {
            this.Operator = Operator;
            this.Operands = Operands.ToReadOnlyList();
        }

        /// <summary>
        /// Specifies the operator
        /// </summary>
        public IOperator Operator { get; }

        /// <summary>
        /// Specivies the operands
        /// </summary>
        public IReadOnlyList<object> Operands { get; }

        public override string ToString()
            => $"{Operator}(" + string.Join(",", Operands) + ")";

    }


}
