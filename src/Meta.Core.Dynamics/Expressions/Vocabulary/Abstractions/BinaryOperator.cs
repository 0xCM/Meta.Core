//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Represents a binary operator
    /// </summary>
    /// <typeparam name="O"></typeparam>
    public abstract class BinaryOperator<O> : Operator<O>, IBinaryOperator
        where O : BinaryOperator<O>
    {
        protected BinaryOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }

        public BinaryOperatorApplication<O, T> Apply<T>(T Left, T Right)
            => new BinaryOperatorApplication<O, T>(this, Left, Right);

        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args[0], args[1]);

        public override string FormatApply(params object[] args)
            => $"{args.FirstOrDefault()} {Symbol} {args.SecondOrDefault()}";


        IOperatorApplication IBinaryOperator.Apply(object Left, object Right)
            => DoApply(Left, Right);
    }



}
