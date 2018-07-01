﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface ISeqPlus<X> : IPlus<X,Seq<X>>
    {

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

    public interface IListPlus<X> : IPlus<X, List<X>>
    {

    }
    /// <summary>
    /// Defines the default list <see cref="IPlus"/> instance
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    readonly struct ListPlus<X> : IListPlus<X>
    {
        public static readonly ListPlus<X> instance = default;

        public List<X> alt(List<X> l1, List<X> l2)
            => ListAlt<X>.instance.alt(l1, l2);

        public Func<List<X>, List<X>> fmap(Func<X, X> f)
            => ListAlt<X>.instance.fmap(f);

        public List<X> empty
            => List<X>.Empty;

    }

}