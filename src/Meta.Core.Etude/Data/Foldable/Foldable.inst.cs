﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    public interface ISeqFoldable<X> 
        : IFoldable<X, Seq<X>> { }

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

    public interface IListFoldable<X> 
        : IFoldable<X,List<X>> { }

    readonly struct ListFoldable<X> : IListFoldable<X>
    {
        public static readonly ListFoldable<X> instance = default;        

        public X fold(IMonoid<X> m, List<X> container)
            => Foldable<X, List<X>>.instance.fold(m, container);

        public Y foldl<Y>(Func<Y, X, Y> f, Y y0, List<X> container)
            => List.foldl(f, y0, container);

        public Y foldr<Y>(Func<X, Y, Y> f, Y y0, List<X> container)
            => List.foldr(f, y0, container);
     }

}