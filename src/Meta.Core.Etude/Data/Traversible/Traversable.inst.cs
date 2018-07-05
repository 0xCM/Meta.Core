//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using Meta.Core.Modules;


    public interface IListTraversable<X,Y> : ITraversable<X, Lst<X>, Y, Lst<Y>>
    {

    }

    readonly struct ListTraversable<X, Y> : IListTraversable<X,Y>
    {
        public static readonly ListTraversable<X, Y> instance = default;

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);

        public Lst<Y> traverse(Func<X, Lst<Y>> f, Lst<X> cx)
            => List.traverse(f, cx);
    }

    public interface ISeqTraversable<X, Y> : ITraversable<X, Seq<X>, Y, Seq<Y>>
    {

    }

    readonly struct SeqTraversable<X, Y> : ISeqTraversable<X,Y>
    {
        public static readonly SeqTraversable<X, Y> instance = default;

        

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);

        public Seq<Y> traverse(Func<X, Seq<Y>> f, Seq<X> sx)
            => Seq.traverse(f, sx);
    }


}