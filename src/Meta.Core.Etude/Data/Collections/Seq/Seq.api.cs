//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

partial class etude
{

    public static Seq<X> alt<X>(Seq<X> s1, Seq<X> s2)
        => Seq.Alt<X>().alt(s1, s2);

    public static Seq<Y> apply<X, Y>(Seq<Func<X, Y>> sf, Seq<X> sx)
        => Seq.apply(sf, sx);

    /// <summary>
    /// Instantiates the <see cref="IMonad"/> instance for a sequence
    /// </summary>
    /// <typeparam name="X">The source type</typeparam>
    /// <typeparam name="Y">The target type</typeparam>
    /// <returns></returns>
    public static ISeqMonad<X, Y> seqM<X, Y>()
        => Seq.Monad<X, Y>();

    public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, Seq<X> container)
        => Seq.foldl(f, y0, container);

    public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, Seq<X> container)
        => Seq.foldr(f, y0, container);

    /// <summary>
    /// Computes a right fold using a specified combiner
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="m"></param>
    /// <param name="subject"></param>
    /// <returns></returns>
    public static X fold<X>(IMonoid<X> m, Seq<X> subject)
        => foldr(m.combine, m.zero, subject);

    public static Seq<Y> fmap<X, Y>(Func<X, Y> f, Seq<X> list)
        => Seq.fmap(f)(list);

    public static Seq<Y> traverse<X, Y>(Func<X, Seq<Y>> f, Seq<X> sx)
        => Seq.traverse(f, sx);

}


