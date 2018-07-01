//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    public readonly struct Foldable<X, CX> : IFoldable<X,CX>
        where CX : IContainer<X>
    {
        public static Foldable<X, CX> instance = new Foldable<X, CX>();

        /// <summary>
        /// Folds the contained elements using required aspects of a supplied
        /// monoid
        /// </summary>
        /// <param name="m">The monoid providing the required combiner</param>
        /// <param name="container">The structure to be folded/aggregated</param>
        /// <returns></returns>
        public X fold(IMonoid<X> m, CX container)
            => Seq.foldr(m.combine, m.zero, Seq.make(container.Stream()));

        /// <summary>
        /// Implements a left-fold over the container
        /// </summary>
        /// <typeparam name="Y">The type of the accumulated value</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The seed value</param>
        /// <param name="container"></param>
        /// <returns></returns>
        public Y foldl<Y>(Func<Y, X, Y> f, Y y0, CX container)
            => Seq.foldl(f, y0, Seq.make(container.Stream()));

        /// <summary>
        /// Implements a right-fold over the container
        /// </summary>
        /// <typeparam name="Y">The type of the accumulated value</typeparam>
        /// <param name="f">The accumulator</param>
        /// <param name="y0">The seed value</param>
        /// <param name="container"></param>
        /// <returns></returns>
        public Y foldr<Y>(Func<X, Y, Y> f, Y y0, CX container)
            => Seq.foldr(f, y0, Seq.make(container.Stream()));
    }

}