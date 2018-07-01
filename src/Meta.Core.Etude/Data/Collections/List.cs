//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    partial class List
    {
        /// <summary>
        /// Constructs the <see cref="IFunctor"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListFunctor<X,Y> Functor<X, Y>()
            => ListFunctor<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IAlt"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListAlt<X> Alt<X>()
            => ListAlt<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IInvariant"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListInvariant<X,Y> Invariant<X, Y>()
            => ListInvariant<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IFoldable"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListFoldable<X> Foldable<X>()
            => ListFoldable<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IApply"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListApply<X,Y> Apply<X, Y>()
            => ListApply<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IApplicative"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListApplicative<X,Y> Applicative<X, Y>()
            => ListApplicative<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IBind"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListBind<X,Y> Bind<X, Y>()
            => ListBind<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IPlus"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListPlus<X> Plus<X>()
            => ListPlus<X>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IMonad"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListMonad<X,Y> Monad<X, Y>()
            => ListMonad<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListTraversable<X,Y> Traversable<X, Y>()
            => ListTraversable<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static IListAlternative<X,Y> Alternative<X, Y>()
            => ListAlternative<X, Y>.instance;

    }


}