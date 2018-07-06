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

    using static metacore;

    public interface IListApply<X,Y> : IApply<X, Lst<X>, Lst<Func<X, Y>>, Y, Lst<Y>>
    {

    }

    readonly struct ListApply<X, Y> : IListApply<X,Y>
    {
        public static readonly ListApply<X, Y> instance = default;

        public Lst<Y> apply(Lst<Func<X, Y>> lf, Lst<X> lx)
            => Lst.apply(lf, lx);

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => Lst.fmap(f);
    }

    public interface ISeqApply<X, Y> : IApply<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
    {

    }

    readonly struct SeqApply<X, Y> : ISeqApply<X,Y>    
    {
        public static readonly SeqApply<X, Y> instance = default;

        public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
            => Seq.apply(sf, sx);

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);
    }



}