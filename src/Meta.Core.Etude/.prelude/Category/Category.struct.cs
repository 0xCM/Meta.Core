//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    
    public readonly struct Category<X> : ICattegory<X>
    {
        public static readonly Category<X> instance
            = new Category<X>();

        public Func<X, X1, X3> compose<X1, X2, X3>(Func<X, X2, X3> f, Func<X, X1, X2> g)
            => Semigroupoid<X>.instance.compose(f, g);

        public X identity(X x)
            => x;

        public Func<X, X1, X3> rcompose<X1, X2, X3>(Func<X, X1, X2> f, Func<X, X2, X3> g)
            => Semigroupoid<X>.instance.rcompose(f, g);

    }


}