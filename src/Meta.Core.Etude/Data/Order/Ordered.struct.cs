//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;

    using static metacore;

    /// <summary>
    /// Defines a <see cref="IOrdered{X}"/> instance predicated on a supplied <see cref="Orderer{X}"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct Ordered<X> : IOrdered<X>
    {        
        public Ordered(Orderer<X> Orderer)
            => this.Orderer = Orderer;

        Orderer<X> Orderer { get; }

        public Type subject
            => typeof(X);

        public Ordering compare(X x1, X x2)
            => Orderer(x1, x2);

        public bool lt(X x1, X x2)
            => Orderer(x1, x2) == Ordering.LT;

        public bool gt(X x1, X x2)
            => Orderer(x1, x2) == Ordering.GT;

        public bool eq(X x1, X x2)
            => Orderer(x1, x2) == Ordering.EQ;

        public bool gteq(X x1, X x2)
            => gt(x1, x1) || eq(x1, x2);

        public bool lteq(X x1, X x2)
            => lt(x1, x2) || eq(x1, x2);

        public bool between(X x, X x1, X x2)
            => gteq(x, x1) && lteq(x, x2);

        public X max(X x1, X x2)
            => gteq(x1, x2) ? x1 : x2;

        public X min(X x1, X x2)
            => lteq(x1, x2) ? x1 : x2;

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));
    }

}