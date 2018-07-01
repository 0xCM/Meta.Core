//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;    

    public interface ISeqFunctor<X,Y> : IFunctor<X, Seq<X>, Y, Seq<Y>>
    {

    }

    /// <summary>
    /// Defines an <see cref="IFunctor"/> instance for <see cref="ISeq{X}"/>
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    readonly struct SeqFunctor<X, Y> : ISeqFunctor<X,Y>
    {
        public static readonly SeqFunctor<X, Y> instance = default;

        public Func<Seq<X>, Seq<Y>> fmap(Func<X, Y> f)
            => Seq.fmap(f);
    }


    public interface IListFunctor<X,Y> : IFunctor<X, List<X>, Y, List<Y>>
    {


    }

    /// <summary>
    /// Defines an <see cref="IFunctor"/> instance for <see cref="IList{X}"/>
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    readonly struct ListFunctor<X, Y> : IListFunctor<X,Y>
    {
        public static readonly ListFunctor<X, Y> instance = default;

        public Func<List<X>, List<Y>> fmap(Func<X, Y> f)
            => List.fmap(f);
    }


    public interface IIndexFunctor<X,Y> : IFunctor<X, Index<X>, Y, Index<Y>>
    {

    }

    /// <summary>
    /// Defines an <see cref="IFunctor"/> instance for <see cref="IIndex"/>
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    readonly struct IndexFunctor<X, Y> : IIndexFunctor<X,Y>
    {
        public static readonly IndexFunctor<X, Y> instance = default;

        public Func<Index<X>, Index<Y>> fmap(Func<X, Y> f)
            => Index.fmap(f);
    }
}