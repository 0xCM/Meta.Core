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

    using static metacore;

    public interface ISeqBind<X,Y> : IBind<X, Seq<X>, Seq<Func<X, Y>>, Y, Seq<Y>>
    { }

    readonly struct SeqBind<X, Y> : ISeqBind<X,Y>
    {
        public static readonly SeqBind<X, Y> instance = default;

        public Seq<Y> apply(Seq<Func<X, Y>> sf, Seq<X> sx)
            => Seq.apply(sf, sx);

        public Seq<Y> bind(Seq<X> s, Func<X, Seq<Y>> f)
            => Seq.bind(s, f);

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);
    }

    public interface IListBind<X, Y> : IBind<X, List<X>, List<Func<X, Y>>, Y, List<Y>>
    {

    }

    struct ListBind<X, Y> : IListBind<X,Y>
    {
        public static readonly ListBind<X, Y> instance = default;

        /// <summary>
        /// Applies a list of function to a list of values
        /// </summary>
        public List<Y> apply(List<Func<X, Y>> lf, List<X> lx)
            => List.apply(lf, lx);

        public List<Y> bind(List<X> list, Func<X, List<Y>> f)
            => List.bind(list, f);

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);
    }

    public interface IIndexBind<X,Y> : IBind<X, Index<X>, Index<Func<X, Y>>, Y, Index<Y>>
    {

    }

    readonly struct IndexBind<X, Y> : IIndexBind<X,Y>
    {
        public static readonly IndexBind<X, Y> instance = default;

        /// <summary>
        /// Applies a Index of function to a Index of values
        /// </summary>
        public Index<Y> apply(Index<Func<X, Y>> lf, Index<X> lx)
            => Index.apply(lf, lx);

        public Index<Y> bind(Index<X> index, Func<X, Index<Y>> f)
            => Index.bind(index, f);

        public Func<Index<X>, Index<Y>> fmap(Func<X, Y> f)
            => Index.fmap(f);
    }

}