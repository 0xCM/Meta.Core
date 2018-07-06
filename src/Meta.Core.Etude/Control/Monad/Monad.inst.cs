//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    public interface ISeqMonad<X,Y> : IMonad<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
    {

    }

    readonly struct SeqMonad<X, Y> : ISeqMonad<X,Y>
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

    public interface IListMonad<X, Y> : IMonad<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>>
    {

    }

    readonly struct ListMonad<X, Y> : IListMonad<X,Y>
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


}