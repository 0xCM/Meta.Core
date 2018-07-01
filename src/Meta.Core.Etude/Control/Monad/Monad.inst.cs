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

    public readonly struct SeqMonad<X, Y> : IMonad<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
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


    public readonly struct ListMonad<X, Y> : IMonad<X, List<X>, List<Func<X, Y>>, Y, List<Y>>
    {
        public static readonly ListMonad<X, Y> instance = default;

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);

        public List<Y> apply(List<Func<X, Y>> cf, List<X> cx)
            => List.apply(cf, cx);

        public List<X> pure(X x)
            => List.singleton(x);

        public List<Y> bind(List<X> f, Func<X, List<Y>> g)
            => List.bind(f, g);
    }


}