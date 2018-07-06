//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface IIdentityFunctor<X,CX> 
        : IFunctor<X, CX, X, CX> 
            where CX : IContainer<X, CX>, new()
    {

    }

    public readonly struct IdentityFunctor<X, CX> : IIdentityFunctor<X,CX>
        where CX : IContainer<X, CX>, new()
    {
        public static readonly IdentityFunctor<X, CX> instance = default;

        public Func<CX, CX> fmap(Func<X, X> f)
            => cx => cx;
    }

    public interface ISeqFunctor<X,Y> 
        : IFunctor<X, Seq<X>, Y, Seq<Y>> { }

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


    public interface IListFunctor<X,Y> 
        : IFunctor<X, Lst<X>, Y, Lst<Y>> { }

    /// <summary>
    /// Defines an <see cref="IFunctor"/> instance for <see cref="ILst{X}"/>
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    readonly struct ListFunctor<X, Y> : IListFunctor<X,Y>
    {
        public static readonly ListFunctor<X, Y> instance = default;

        public Func<Lst<X>, Lst<Y>> fmap(Func<X, Y> f)
            => Lst.fmap(f);
    }

    

    public interface IIndexFunctor<X,Y> 
        : IFunctor<X, Index<X>, Y, Index<Y>> { }

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