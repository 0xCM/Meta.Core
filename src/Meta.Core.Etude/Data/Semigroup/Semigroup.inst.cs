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
    /// Defines a semigroup over <typeparamref name="X"/> predicated on intrinsics
    /// </summary>
    /// <typeparam name="X">The semigroup element type</typeparam>
    readonly struct DefaultSemigroup<X> : ISemigroup<X>
    {
        public static readonly DefaultSemigroup<X> instance = default;

        public X combine(X x1, X x2)
            => operators.add(x1, x2);

        public bool eq(X x1, X x2)
            => operators.eq(x1, x2);

        public bool neq(X x1, X x2)
            => !eq(x1, x2);

        public Type subject
            => typeof(X);
    }


    readonly struct SemigroupOrdering : ISemigroup<Ordering>
    {
        public Ordering combine(Ordering a1, Ordering a2)
            => a1 == Ordering.LT ? Ordering.LT
            : a1 == Ordering.GT ? Ordering.GT
            : Ordering.EQ;

        public bool eq(Ordering x1, Ordering x2)
            => x1 == x2;
    }

}