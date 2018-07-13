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

    public interface ISeqEq<X> : IEq<Seq<X>> { }

    public interface ISeqFoldable<X> : IFoldable<X, Seq<X>> { }

    public interface ISeqPlus<X> : IPlus<X, Seq<X>> { }

    public interface ISeqMonoid<X> : IMonoid<Seq<X>> { }

    public interface ISeqAlternative<X, Y> : IAlternative<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> { }

    public interface ISeqApplicative<X, Y> : IApplicative<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> { }

    public interface ISeqMonad<X, Y> : IMonad<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> { }

    public interface ISeqBind<X, Y> : IBind<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> { }

    public interface ISeqAlt<X> : IAlt<X, Seq<X>> { }

    public interface ISeqFunctor<X, Y> : IFunctor<X, Seq<X>, Y, Seq<Y>> { }

    public interface ISeqTraversable<X, Y> : ITraversable<X, Seq<X>, Y, Seq<Y>> { }



    partial class Seq
    {

        public readonly struct SeqEq<X> : ISeqEq<X>
        {
            public static readonly SeqEq<X> instance = default;

            public bool eq(Seq<X> s1, Seq<X> s2)
                => Seq.eq(s1, s2);

            public bool neq(Seq<X> s1, Seq<X> s2)
                => not(eq(s1, s2));
        }


        /// <summary>
        /// Defines an <see cref="IFunctor"/> instance for <see cref="ISeq{X}"/>
        /// </summary>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        readonly struct SeqFunctor<X, Y> : ISeqFunctor<X, Y>
        {
            public static readonly SeqFunctor<X, Y> instance = default;

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);
        }


        readonly struct SeqMonoid<X> : ISeqMonoid<X>
        {
            public static readonly SeqMonoid<X> instance = default;

            public Seq<X> zero
                => Seq<X>.Empty;

            public Seq<X> combine(Seq<X> a1, Seq<X> a2)
                => a1 + a2;

            public bool eq(Seq<X> x1, Seq<X> x2)
                => x1 == x2;
        }

        readonly struct SeqBind<X, Y> : ISeqBind<X, Y>
        {
            public static readonly SeqBind<X, Y> instance = default;

            public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
                => Seq.apply(sf, sx);

            public Seq<Y> bind(Seq<X> s, Func<X, Seq<Y>> f)
                => Seq.bind(s, f);

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);
        }

        readonly struct SeqAlt<X> : ISeqAlt<X>
        {
            public static readonly SeqAlt<X> instance = default;

            public Seq<X> alt(Seq<X> s1, Seq<X> s2)
                => Seq.concat(s1, s2);

            public Func<Seq<X>, Seq<X>> fmap(Func<X, X> f)
                => Seq.fmap(f);
        }

         readonly struct SeqAlternative<X,Y> : ISeqAlternative<X,Y>
         { 
        
            public static readonly SeqAlternative<X, Y> instance = default;

            public Seq<X> empty
                => Seq.empty<X>();

            public Seq<Y> apply(Seq<Func<X, Y>> cf, Seq<X> cx)
                => Seq.apply(cf, cx);

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);

            public Seq<X> pure(X x)
                => Seq.singleton(x);
        }

        public interface ISeqApply<X, Y> : IApply<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>> { }

        readonly struct SeqApply<X, Y> : ISeqApply<X, Y>
        {
            public static readonly SeqApply<X, Y> instance = default;

            public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
                => Seq.apply(sf, sx);

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);
        }


        readonly struct SeqApplicative<X, Y> : ISeqApplicative<X, Y>
        {
            public static readonly SeqApplicative<X, Y> instance = default;

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);

            public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
                => Seq.apply(sf, sx);

            public Seq<X> pure(X x)
                => Seq.singleton(x);
        }

        readonly struct SeqMonad<X, Y> : ISeqMonad<X, Y>
        {
            public static readonly SeqMonad<X, Y> instance = default;

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);

            public Seq<Y> apply(Seq<Func<X, Y>> cf, Seq<X> cx)
                => Seq.apply(cf, cx);

            public Seq<X> pure(X x)
                => Seq.singleton(x);

            public Seq<Y> bind(Seq<X> f, Func<X, Seq<Y>> g)
                => Seq.bind(f, g);
        }

        /// <summary>
        /// Defines the default sequence <see cref="IPlus"/> instance
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        readonly struct SeqPlus<X> : ISeqPlus<X>
        {
            public static readonly SeqPlus<X> instance = default;

            public Seq<X> alt(Seq<X> l1, Seq<X> l2)
                => SeqAlt<X>.instance.alt(l1, l2);

            public Func<Seq<X>, Seq<X>> fmap(Func<X, X> f)
                => SeqAlt<X>.instance.fmap(f);

            public Seq<X> empty
                => Seq<X>.Empty;
        }

        readonly struct SeqFoldable<X> : ISeqFoldable<X>
        {
            public static readonly SeqFoldable<X> instance = default;

            public X fold(IMonoid<X> m, Seq<X> s)
                => Foldable<X, Seq<X>>.instance.fold(m, s);

            public Y foldl<Y>(Func<Y, X, Y> f, Y y0, Seq<X> s)
                => Seq.foldl(f, y0, s);

            public Y foldr<Y>(Func<X, Y, Y> f, Y y0, Seq<X> s)
                => Seq.foldr(f, y0, s);
        }

        readonly struct SeqTraversable<X, Y> : ISeqTraversable<X, Y>
        {
            public static readonly SeqTraversable<X, Y> instance = default;

            public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
                => Seq.fmap(f);

            public Seq<Y> traverse(Func<X, Seq<Y>> f, Seq<X> sx)
                => Seq.traverse(f, sx);
        }
    }
}