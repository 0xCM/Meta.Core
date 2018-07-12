//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static minicore;

    partial class Seq
    {
        /// <summary>
        /// Constructs the sequence <see cref="IEq"/> instance
        /// </summary>
        /// <returns></returns>
        public static IEq<Seq<X>> Eq<X>()
            => SeqEq<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IFunctor"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public ISeqFunctor<X,Y> Functor<X, Y>()
            => SeqFunctor<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IAlt"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqAlt<X> Alt<X>()
            => SeqAlt<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IFoldable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqFoldable<X> Foldable<X>()
            => SeqFoldable<X>.instance;

        /// <summary>
        /// Constructs the <see cref="IApply"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqApply<X,Y> Apply<X, Y>()
            => SeqApply<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IApplicative"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqApplicative<X, Y> Applicative<X, Y>()
            => SeqApplicative<X, Y>.instance;

        /// <summary>
        /// Constructs the <see cref="IBind"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqBind<X, Y> Bind<X, Y>()
            => SeqBind<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IPlus"/> list instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqPlus<X> Plus<X>()
            => SeqPlus<X>.instance;

        /// <summary>
        /// Cosntructs the <see cref="IMonad"/> seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqMonad<X,Y> Monad<X, Y>()
            => SeqMonad<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqTraversable<X, Y> Traversable<X, Y>()
            => SeqTraversable<X, Y>.instance;

        /// <summary>
        /// Cosntructs the <see cref="ITraversable"/> Seq instance over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqAlternative<X,Y> Alternative<X, Y>()
            => SeqAlternative<X, Y>.instance;

        /// <summary>
        /// Constructs a monoid over a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <returns></returns>
        public static ISeqMonoid<X> Monoid<X>()
            => SeqMonoid<X>.instance;
       
    }


}