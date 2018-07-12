//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;

    public interface IIndexAlt<X> : IAlt<X, Index<X>> { }

    public interface IIndexBind<X, Y> : IBind<X, Index<X>, Index<Func<X, Y>>, Y, Index<Y>> { }

    public interface IIndexFunctor<X, Y> : IFunctor<X, Index<X>, Y, Index<Y>> { }

    public interface IIndexMonoid<X> : IMonoid<Index<X>> { }

    partial class Index
    {
        readonly struct IndexAlt<X> : IIndexAlt<X>
        {
            public static readonly IndexAlt<X> instance = default;

            public Index<X> alt(Index<X> s1, Index<X> s2)
                => Index.concat(s1, s2);

            public Func<Index<X>, Index<X>> fmap(Func<X, X> f)
                => Index.fmap(f);
        }

        readonly struct IndexMonoid<X> : IIndexMonoid<X>
        {
            public static readonly IndexMonoid<X> instance = default;

            public Index<X> zero
                => Index<X>.Empty;

            public Index<X> combine(Index<X> a1, Index<X> a2)
                => a1 + a2;

            public bool eq(Index<X> x1, Index<X> x2)
                => x1 == x2;
        }

        readonly struct IndexBind<X, Y> : IIndexBind<X, Y>
        {
            public static readonly IndexBind<X, Y> instance = default;

            /// <summary>
            /// Applies a Index of function to a Index of values
            /// </summary>
            public Index<Y> apply(Index<Func<X, Y>> lf, Index<X> lx)
                => Index.apply(lf, lx);

            public Index<Y> bind(Index<X> index, Func<X, Index<Y>> f)
                => Index.bind(index, f);

            public Func<Index<X>, Index<Y>> fmap(Func<X, Y> f)
                => Index.fmap(f);
        }

        /// <summary>
        /// Defines an <see cref="IFunctor"/> instance for <see cref="IIndex"/>
        /// </summary>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        readonly struct IndexFunctor<X, Y> : IIndexFunctor<X, Y>
        {
            public static readonly IndexFunctor<X, Y> instance = default;

            public Func<Index<X>, Index<Y>> fmap(Func<X, Y> f)
                => Index.fmap(f);
        }

    }
}