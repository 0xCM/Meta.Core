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


}