//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an operator
    /// </summary>
    /// <typeparam name="OP">The operator type</typeparam>
    public abstract class Operator<OP> : IOperator where OP : Operator<OP>
    {
        protected Operator(string Name, string Symbol)
        {
            this.Name = Name;
            this.Symbol = Symbol;
        }

        /// <summary>
        /// The name of the operator
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The symbol used to denote the opeator
        /// </summary>
        public string Symbol { get; }


        public override string ToString()
            => Symbol;

        public abstract string FormatApply(params object[] args);

        protected abstract IOperatorApplication DoApply(params object[] args);

        IOperatorApplication IOperator.Apply(params object[] args)
            => DoApply(args);

    }

    
}
