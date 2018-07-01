//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IListAlternative<X,Y> 
        : IAlternative<X, List<X>, List<Func<X, Y>>, Y, List<Y>>
    {


    }

    readonly struct ListAlternative<X, Y> : IListAlternative<X,Y>
    {
        public static readonly ListAlternative<X,Y> instance = default;

        public List<X> empty
            => List.empty<X>();

        public List<Y> apply(List<Func<X, Y>> cf, List<X> cx)
            => List.apply(cf, cx);

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);

        public List<X> pure(X x)
            => List.singleton(x);
    }

    public interface ISeqAlternative<X,Y>
        : IAlternative<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
    {

    }

    readonly struct SeqAlternative<X, Y> : ISeqAlternative<X,Y>
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

}