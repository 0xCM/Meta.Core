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
        : IAlternative<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>>
    {


    }

    readonly struct ListAlternative<X, Y> : IListAlternative<X,Y>
    {
        public static readonly ListAlternative<X,Y> instance = default;

        public Lst<X> empty
            => Lst.empty<X>();

        public Lst<Y> apply(Lst<Func<X, Y>> cf, Lst<X> cx)
            => Lst.apply(cf, cx);

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => Lst.fmap(f);

        public Lst<X> pure(X x)
            => Lst.singleton(x);
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