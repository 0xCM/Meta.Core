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
    using System.Text;

    public abstract class UnaryOperator<OP> : Operator<OP>
        where OP : UnaryOperator<OP>
    {

        protected UnaryOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }


        public UnaryOperatorApplication<OP, T> Apply<T>(T Operand)
            => new UnaryOperatorApplication<OP, T>(this, Operand);


        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args.First());


        public override string FormatApply(params object[] args)
            => $"{Symbol}({args.FirstOrDefault()}";
    }
}
