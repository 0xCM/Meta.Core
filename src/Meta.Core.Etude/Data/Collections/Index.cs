//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    partial class Index
    {
        /// <summary>
        /// Constructs the <see cref="IFunctor"/> Index instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IIndexFunctor<X,Y> Functor<X, Y>()
            => IndexFunctor<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IAlt"/> Index instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IIndexAlt<X> Alt<X>()
            => IndexAlt<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IBind"/> Index instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IIndexBind<X,Y> Bind<X, Y>()
            => IndexBind<X, Y>.instance;

        /// <summary>
        /// Constructs a monoid over an index
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IIndexMonoid<X> Monoid<X>()
            => IndexMonoid<X>.instance;

    }


}