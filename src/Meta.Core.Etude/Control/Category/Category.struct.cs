//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    //base/Control/Category.hs
    public readonly struct Category<K> : ICategory<K>
    {
        public static readonly Category<K> instance
            = new Category<K>();

        //right-to-left composition (<<<)
        public Func<K, A, C> compose<A, B, C>(Func<K, B, C> f, Func<K, A, B> g)
            => (x, a) => f(x, g(x, a));

        public K id(K x)
            => x;

    }

    public readonly struct Category<K, A, B, C> : ICategory<K, A, B, C>
    {
        public static readonly Category<K, A, B, C> instance
            = new Category<K, A, B, C>();

        public Func<K, A, C> compose(Func<K, B, C> f, Func<K, A, B> g)
            => (k, a) => f(k, g(k, a));

        public K id(K k)
            => k;
    }
}