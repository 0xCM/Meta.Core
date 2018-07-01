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

    public class PredicateApplication<O,X> : IPredicateAplication
        where O : Operator<O>
    {

        public PredicateApplication(O Operator)
        {
            this.Operator = Operator;
        }
        public O Operator { get; }

        protected virtual IReadOnlyList<object> Operands
            => new object[] { };

        IOperator IOperatorApplication.Operator
            => Operator;

        IReadOnlyList<object> IOperatorApplication.Operands
            => Operands;


    }
}
