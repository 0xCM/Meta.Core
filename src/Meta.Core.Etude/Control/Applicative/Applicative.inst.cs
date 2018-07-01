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

    public interface IListApplicative<X,Y> : IApplicative<X, List<X>, List<Func<X, Y>>, Y, List<Y>>
    {

    }
    
    readonly struct ListApplicative<X, Y> : IListApplicative<X,Y>
    {
        public static readonly ListApplicative<X, Y> instance = default;
        

        public List<Y> apply(List<Func<X, Y>> lf, List<X> lx)
            => List.apply(lf, lx);

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);

        public List<X> pure(X x)
            => List.singleton(x);
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