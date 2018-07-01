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

    readonly struct ListAlt<X> : IAlt<X, List<X>>
    {
        public static readonly ListAlt<X> instance = default;

        public List<X> alt(List<X> l1, List<X> l2)
            => List.concat(l1, l2);

        public Func<List<X>, List<X>> fmap(Func<X, X> f)
            => List.fmap(f);
    }

    readonly struct SeqAlt<X> : IAlt<X, Seq<X>>
    {
        public static readonly SeqAlt<X> instance = default;

        public Seq<X> alt(Seq<X> s1, Seq<X> s2)
            => Seq.concat(s1, s2);

        public Func<Seq<X>, Seq<X>> fmap(Func<X, X> f)
            => Seq.fmap(f);
    }

    readonly struct IndexAlt<X> : IAlt<X, Index<X>>
    {
        public static readonly IndexAlt<X> instance = default;

        public Index<X> alt(Index<X> s1, Index<X> s2)
            => Index.concat(s1, s2);

        public Func<Index<X>, Index<X>> fmap(Func<X, X> f)
            => Index.fmap(f);
    }


 
}