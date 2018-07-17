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
    /// Defines a monoid over <typeparamref name="X"/> predicated on intrinsics
    /// </summary>
    /// <typeparam name="X">The monoid element type</typeparam>
    readonly struct DefaultMonoid<X> : IMonoid<X>
    {
        public static readonly DefaultMonoid<X> instance = default;

        static IMonoid<X> _Default
            = new Monoid<X>(operators.eq, operators.add, operators.zero<X>());

        public X zero
            => _Default.zero;            

        public X combine(X a1, X a2)
            => _Default.combine(a1, a2);

        public bool eq(X x1, X x2)
            => _Default.eq(x1, x2);

    }




}