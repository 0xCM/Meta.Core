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


    partial class Lst
    {
        /// <summary>
        /// Gets the canonical <see cref="IEq"/> instance for a list
        /// </summary>
        /// <returns></returns>
        public static IEq<Lst<X>> List<X>()
            => LstEq<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IFunctor"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstFunctor<X,Y> Functor<X, Y>()
            => ListFunctor<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IAlt"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstAlt<X> Alt<X>()
            => LstAlt<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IInvariant"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstInvariant<X,Y> Invariant<X, Y>()
            => ListInvariant<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IFoldable"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstFoldable<X> Foldable<X>()
            => ListFoldable<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IApply"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstApply<X,Y> Apply<X, Y>()
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
        public static ILstBind<X,Y> Bind<X, Y>()
            => ListBind<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IPlus"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstPlus<X> Plus<X>()
            => ListPlus<X>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IMonad"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstMonad<X,Y> Monad<X, Y>()
            => ListMonad<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstTraversable<X,Y> Traversable<X, Y>()
            => ListTraversable<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstAlternative<X,Y> Alternative<X, Y>()
            => LstAlternative<X, Y>.instance;

        /// <summary>
        /// Constructs a monoid over a list
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ILstMonoid<X> Monoid<X>()
            => LstMonoid<X>.instance;

        /// <summary>
        /// Constructs <see cref="IExtend"/> over a list
        /// </summary>
        /// <typeparam name="X">The source list item type</typeparam>
        /// <typeparam name="Y">The target list item type</typeparam>
        /// <returns></returns>
        public static ILstExtend<X, Y> Extend<X, Y>()
            => ListExtend<X, Y>.instance;


        /// <summary>
        /// Parses a list representation
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="formatted">The formatted list</param>
        /// <returns></returns>
        public static Lst<X> parse<X>(string formatted)
            => Lst.make(from list in formatted.GetBoundedContent('[', ']')
                        from item in list.Split(",")
                        select metacore.parse<X>(item));
    }

}