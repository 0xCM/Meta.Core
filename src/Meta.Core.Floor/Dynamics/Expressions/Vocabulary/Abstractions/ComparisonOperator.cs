//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    

    /// <summary>
    /// Represents a comparison operator
    /// </summary>
    /// <typeparam name="O"></typeparam>
    public abstract class ComparisonOperator<O> : BinaryOperator<O>, IComparisonOperator
        where O : ComparisonOperator<O>
    {
        protected ComparisonOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }

        public new ComparisonOperatorApplication<O, T> Apply<T>(T Left, T Right)
            => new ComparisonOperatorApplication<O, T>(this, Left, Right);

        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args[0], args[1]);

    }
}
