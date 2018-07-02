//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    /// <summary>
    /// Defines a default instance of <see cref="IOrdered"/> predicated on operator implementations
    /// </summary>
    /// <typeparam name="X">The ordered type</typeparam>
    readonly struct OrderedIntrinsic<X> : IOrderOperators<X>
    {
        public static IOrderOperators<X> Default { get; }
            = new OrderedIntrinsic<X>();

        public bool eq(X x1, X x2)
            => operators.eq(x1, x2);

        public bool neq(X x1, X x2)
            => operators.neq(x1, x2);

        public bool gt(X x1, X x2)
            => operators.gt(x1, x2);

        public bool gteq(X x1, X x2)
            => operators.gteq(x1, x2);

        public bool lt(X x1, X x2)
            => operators.lt(x1, x2);

        public bool lteq(X x1, X x2)
            => operators.lteq(x1, x2);

        public X min(X x1, X x2)
            => lteq(x1, x2) ? x1 : x2;

        public X max(X x1, X x2)
            => gteq(x1, x2) ? x1 : x2;

        public bool between(X x, X lower, X upper)
            => gteq(x, lower) && lteq(x, upper);

        public Ordering compare(X x1, X x2)
            => lt(x1, x2) ? Ordering.LT
             : gt(x1, x2) ? Ordering.GT
             : Ordering.EQ;
    }

}