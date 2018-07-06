//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    public interface IListApplicative<X,Y> : IApplicative<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>>
    {

    }
    
    readonly struct ListApplicative<X, Y> : IListApplicative<X,Y>
    {
        public static readonly ListApplicative<X, Y> instance = default;
        

        public Lst<Y> apply(Lst<Func<X, Y>> lf, Lst<X> lx)
            => Lst.apply(lf, lx);

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => Lst.fmap(f);

        public Lst<X> pure(X x)
            => Lst.singleton(x);
    }

    public interface ISeqApplicative<X,Y> : IApplicative<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
    {

    }

    readonly struct SeqApplicative<X, Y> : ISeqApplicative<X,Y>
    {
        public static readonly SeqApplicative<X, Y> instance = default;

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);

        public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
            => Seq.apply(sf, sx);

        public Seq<X> pure(X x)
            => Seq.singleton(x);
    }

}