//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    //base/Control/Category.hs
    public readonly struct Category<X> : ICategory<X>
    {
        public static readonly Category<X> instance
            = new Category<X>();

        //right-to-left composition (<<<)
        public Func<X, A, C> compose<A, B, C>(Func<X, B, C> f, Func<X, A, B> g)
            => (x, a) => f(x, g(x, a));

        public X id(X x)
            => x;


    }

    public readonly struct Category<X,A,B,C> : ICategory<X,A,B,C>
    {
        public static readonly Category<X,A,B,C> instance
            = new Category<X, A, B, C>();

        //right-to-left composition (<<<)
        public Func<X, A, C> compose(Func<X, B, C> f, Func<X, A, B> g)
            => (x, a) => f(x, g(x, a));

        public X id(X x)
            => x;


    }

}