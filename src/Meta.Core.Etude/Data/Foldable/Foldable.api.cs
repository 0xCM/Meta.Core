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
    public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, List<X> container)
        => ListFoldable<X>.instance.foldl(f, y0, container);

    /// <summary>
    /// Applies a right-fold over a list 
    /// </summary>
    /// <typeparam name="X">The input list item type</typeparam>
    /// <typeparam name="Y">The output list item type</typeparam>
    /// <param name="f">The accumulator</param>
    /// <param name="y0">The starting value</param>
    /// <param name="container">The list containing the elements to be folded</param>
    /// <remarks>
    /// See http://hackage.haskell.org/package/base-4.11.1.0/docs/src/GHC.Base.html#fold
    /// </remarks>
    public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, List<X> container)
        => ListFoldable<X>.instance.foldr(f, y0, container);

    public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, Seq<X> container)
        => SeqFoldable<X>.instance.foldl(f, y0, container);

    public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, Seq<X> container)
        => SeqFoldable<X>.instance.foldr(f, y0, container);


    /// <summary>
    /// Computes a right fold using a specified combiner
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="m"></param>
    /// <param name="subject"></param>
    /// <returns></returns>
    public static X fold<X>(IMonoid<X> m, Seq<X> subject)
        => foldr(m.combine, m.zero, subject);

}

