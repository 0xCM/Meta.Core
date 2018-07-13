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
    public static Lst<Y> bind<X, Y>(Lst<X> list, Function<X, Lst<Y>> f)
        => Lst.bind(list, f.F);

    public static Lst<Y> apply<X, Y>(Lst<Func<X, Y>> lf, Lst<X> lx)
        => Lst.apply(lf, lx);

    /// <summary>
    /// Implements the <![CDATA[<|>]]> operator for lists
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="l1">The first list</param>
    /// <param name="l2">The second list</param>
    /// <returns></returns>
    public static Lst<X> alt<X>(Lst<X> l1, Lst<X> l2)
        => Lst.concat(l1, l2);

    public static Y foldl<X, Y>(Func<Y, X, Y> f, Y y0, Lst<X> container)
        => Lst.foldl(f, y0, container);

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
    public static Y foldr<X, Y>(Func<X, Y, Y> f, Y y0, Lst<X> container)
        => Lst.foldr(f, y0, container);

    /// <summary>
    /// Constructs the canonical <see cref="IMonad"/> instance for a list
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <typeparam name="Y">The transformed element type</typeparam>
    /// <returns></returns>
    public static ILstMonad<X, Y> listM<X, Y>()
        => Lst.Monad<X, Y>();

    public static Lst<Y> fmap<X, Y>(Func<X, Y> f, Lst<X> list)
        => Lst.fmap(f)(list);

    public static Lst<Y> traverse<X, Y>(Func<X, Lst<Y>> f, Lst<X> sx)
        => Lst.traverse(f, sx);

}


