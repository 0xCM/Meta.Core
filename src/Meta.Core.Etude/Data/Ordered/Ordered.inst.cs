//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    using Operators;

    /// <summary>
    /// Defines a default instance of <see cref="IOrdered"/> predicated on operator implementations
    /// </summary>
    /// <typeparam name="X">The ordered type</typeparam>
    readonly struct DefaultOrder<X> : IOrdered<X>
    {
        
        public static readonly Option<IOrdered<X>> instance
            = operators.orderable<X>() 
            ? new DefaultOrder<X>() 
            : none<IOrdered<X>>();

        public static readonly Option<IOrderOperators<X>> orderops
            = instance.Map(i => new OrderOps<X>(i) as IOrderOperators<X>);


        static DefaultOrder()
        { 
           
        }
        
        public bool eq(X x1, X x2)
            => operators.eq(x1, x2);

        public bool gt(X x1, X x2)
            => operators.gt(x1, x2);

        public bool lt(X x1, X x2)
            => operators.lt(x1, x2);

        public bool neq(X x1, X x2)
           => !eq(x1, x2);

        public bool gteq(X x1, X x2)
            => gt(x1, x2) || eq(x1, x2);

        public bool lteq(X x1, X x2)
            => lt(x1, x2) || eq(x1, x2);

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