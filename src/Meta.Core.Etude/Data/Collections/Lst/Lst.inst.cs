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

    public interface ILstEq<X> : IEq<Lst<X>> { }

    public interface IListPlus<X> : IPlus<X, Lst<X>> { }

    public interface ILstAlt<X> : IAlt<X, Lst<X>> { }

    public interface ILstAlternative<X, Y> : IAlternative<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>> { }

    public interface IListApply<X, Y> : IApply<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>> { }

    public interface IListBind<X, Y> : IBind<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>> { }

    public interface IListApplicative<X, Y> : IApplicative<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>> { }

    public interface IListMonad<X, Y> : IMonad<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>> { }

    public interface IListBifunctor<X1, X2, Y1, Y2> : IBifunctor<X1, Lst<X1>, X2, Lst<X2>, Y1, Lst<Y1>, Y2, Lst<Y2>> { }

    public interface IListFoldable<X> : IFoldable<X, Lst<X>> { }

    public interface IListFunctor<X, Y> : IFunctor<X, Lst<X>, Y, Lst<Y>> { }

    public interface IListInvariant<X, Y> : IInvariant<X, Lst<X>, Y, Lst<Y>> { }

    public interface IListTraversable<X, Y> : ITraversable<X, Lst<X>, Y, Lst<Y>> { }


    partial class Lst
    {

        readonly struct LstEq<X> : ILstEq<X>
        {
            public static readonly LstEq<X> instance = default;

            public bool eq(Lst<X> l1, Lst<X> l2)
                => Lst.eq(l1, l2);

            public bool neq(Lst<X> l1, Lst<X> l2)
                => not(eq(l1, l2));
        }


        /// <summary>
        /// Defines an <see cref="IFunctor"/> instance for <see cref="ILst{X}"/>
        /// </summary>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        readonly struct ListFunctor<X, Y> : IListFunctor<X, Y>
        {
            public static readonly ListFunctor<X, Y> instance = default;

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);
        }

        readonly struct LstAlt<X> : ILstAlt<X>
        {
            public static readonly LstAlt<X> instance = default;

            public Lst<X> alt(Lst<X> l1, Lst<X> l2)
                => Lst.concat(l1, l2);

            public Func<Lst<X>, Lst<X>> fmap(Func<X, X> f)
                => Lst.fmap(f);
        }

        readonly struct LstAlternative<X, Y> : ILstAlternative<X, Y>
        {
            public static readonly LstAlternative<X, Y> instance = default;

            public Lst<X> empty
                => Lst.zero<X>();

            public Lst<Y> apply(Lst<Func<X, Y>> cf, Lst<X> cx)
                => Lst.apply(cf, cx);

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);

            public Lst<X> pure(X x)
                => Lst.singleton(x);
        }


        readonly struct ListApply<X, Y> : IListApply<X, Y>
        {
            public static readonly ListApply<X, Y> instance = default;

            public Lst<Y> apply(Lst<Func<X, Y>> lf, Lst<X> lx)
                => Lst.apply(lf, lx);

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);
        }

        struct ListBind<X, Y> : IListBind<X, Y>
        {
            public static readonly ListBind<X, Y> instance = default;

            /// <summary>
            /// Applies a list of function to a list of values
            /// </summary>
            public Lst<Y> apply(Lst<Func<X, Y>> lf, Lst<X> lx)
                => Lst.apply(lf, lx);

            public Lst<Y> bind(Lst<X> list, Func<X, Lst<Y>> f)
                => Lst.bind(list, f);

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);
        }

        readonly struct ListApplicative<X, Y> : IListApplicative<X, Y>
        {
            public static readonly ListApplicative<X, Y> instance = default;


            public Lst<Y> apply(Lst<Func<X, Y>> lf, Lst<X> lx)
                => Lst.apply(lf, lx);

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);

            public Lst<X> pure(X x)
                => Lst.singleton(x);
        }

        public interface ILstMonoid<X> : IMonoid<Lst<X>> { }

        readonly struct LstMonoid<X> : ILstMonoid<X>
        {
            public static readonly LstMonoid<X> instance = default;

            public Lst<X> zero
                => Lst<X>.Empty;

            public Lst<X> combine(Lst<X> a1, Lst<X> a2)
                => a1 + a2;

            public bool eq(Lst<X> x1, Lst<X> x2)
                => x1 == x2;
        }
 
        readonly struct ListMonad<X, Y> : IListMonad<X, Y>
        {
            public static readonly ListMonad<X, Y> instance = default;

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);

            public Lst<Y> apply(Lst<Func<X, Y>> cf, Lst<X> cx)
                => Lst.apply(cf, cx);

            public Lst<X> pure(X x)
                => Lst.singleton(x);

            public Lst<Y> bind(Lst<X> f, Func<X, Lst<Y>> g)
                => Lst.bind(f, g);
        }

        /// <summary>
        /// Defines the default list <see cref="IPlus"/> instance
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        readonly struct ListPlus<X> : IListPlus<X>
        {
            public static readonly ListPlus<X> instance = default;

            public Lst<X> alt(Lst<X> l1, Lst<X> l2)
                => LstAlt<X>.instance.alt(l1, l2);

            public Func<Lst<X>, Lst<X>> fmap(Func<X, X> f)
                => LstAlt<X>.instance.fmap(f);

            public Lst<X> empty
                => Lst<X>.Empty;
        }


        readonly struct ListBifunctor<X1, X2, Y1, Y2> : IListBifunctor<X1, X2, Y1, Y2>
        {
            public static readonly ListBifunctor<X1, X2, Y1, Y2> instance = default;

            public Func<(Lst<X1>, Lst<X2>), (Lst<Y1>, Lst<Y2>)> bimap(Func<X1, Y1> f, Func<X2, Y2> g)
                => Bifunctor<X1, Lst<X1>, X2, Lst<X2>, Y1, Lst<Y1>, Y2, Lst<Y2>>.instance.bimap(f, g);
        }


        readonly struct ListInvariant<X, Y> : IListInvariant<X, Y>
        {
            public static readonly ListInvariant<X, Y> instance = default;

            public Func<Lst<X>, Lst<Y>> imap(Func<X, Y> f, Func<Y, X> g)
                => lx => Lst.imap(f, g, lx);
        }

        readonly struct ListFoldable<X> : IListFoldable<X>
        {
            public static readonly ListFoldable<X> instance = default;

            public X fold(IMonoid<X> m, Lst<X> container)
                => Foldable<X, Lst<X>>.instance.fold(m, container);

            public Y foldl<Y>(Func<Y, X, Y> f, Y y0, Lst<X> container)
                => Lst.foldl(f, y0, container);

            public Y foldr<Y>(Func<X, Y, Y> f, Y y0, Lst<X> container)
                => Lst.foldr(f, y0, container);
        }

        readonly struct ListTraversable<X, Y> : IListTraversable<X, Y>
        {
            public static readonly ListTraversable<X, Y> instance = default;

            public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
                => Lst.fmap(f);

            public Lst<Y> traverse(Func<X, Lst<Y>> f, Lst<X> cx)
                => Lst.traverse(f, cx);
        }


    }
}