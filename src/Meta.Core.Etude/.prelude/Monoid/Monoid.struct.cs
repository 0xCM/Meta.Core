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

    /// <summary>
    /// Defines a monioid over <typeparamref name="X"/> predicated on constructor-injected functions
    /// </summary>
    /// <typeparam name="X">The monoid element type</typeparam>
    public readonly struct Monoid<X> :  IMonoid<X>        
    {

        public Monoid(Equator<X> Equator, Combiner<X> Combiner, X Zero)
        {
            this.Equator = Equator;
            this.Combiner = Combiner;
            this.zero = Zero;
        }

        Equator<X> Equator { get; }

        Combiner<X> Combiner { get; }

        /// <summary>
        /// The monoid's zero element
        /// </summary>
        public X zero { get; }


        public X combine(X x1, X x2)
           => Combiner(x1, x2);

        public bool eq(X x1, X x2)
            => Equator(x1, x2);

        public bool isZero(X a)
           => object.ReferenceEquals(a, zero);

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));

        public override string ToString()
            => "Monoid" + embrace(typeof(X).Name);
    }
}