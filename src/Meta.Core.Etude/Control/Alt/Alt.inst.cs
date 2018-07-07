//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    

    public interface IListAlt<X> : IAlt<X, Lst<X>>
    {

    }

    readonly struct ListAlt<X> : IListAlt<X>
    {
        public static readonly ListAlt<X> instance = default;

        public Lst<X> alt(Lst<X> l1, Lst<X> l2)
            => Lst.concat(l1, l2);

        public Func<Lst<X>, Lst<X>> fmap(Func<X, X> f)
            => Lst.fmap(f);
    }

    public interface ISeqAlt<X> : IAlt<X, Seq<X>>
    {

    }

    readonly struct SeqAlt<X> : ISeqAlt<X>
    {
        public static readonly SeqAlt<X> instance = default;

        public Seq<X> alt(Seq<X> s1, Seq<X> s2)
            => Seq.concat(s1, s2);

        public Func<Seq<X>, Seq<X>> fmap(Func<X, X> f)
            => Seq.fmap(f);
    }

    public interface IIndexAlt<X> : IAlt<X, Index<X>>
    {

    }

    readonly struct IndexAlt<X> : IIndexAlt<X>
    {
        public static readonly IndexAlt<X> instance = default;

        public Index<X> alt(Index<X> s1, Index<X> s2)
            => Index.concat(s1, s2);

        public Func<Index<X>, Index<X>> fmap(Func<X, X> f)
            => Index.fmap(f);
    }
 
}