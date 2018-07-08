//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Transforms a function X->Y->Z to a function Y->X->Z
    /// </summary>
    /// <typeparam name="X">The domain of the input function</typeparam>
    /// <typeparam name="Y">The domain of the output function</typeparam>
    /// <typeparam name="Z">The codomain of both functions</typeparam>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Func<Y, X, Z> flip<X, Y, Z>(Func<X, Y, Z> f)
        => (Y y, X x) => f(x, y);

    public static Func<B> curry<A, B>(Func<A, B> f, A x1)
        => () => f(x1);

    //curry :: ((a, b) -> c) -> a -> (b -> c)
    public static Func<B, C> curry<A, B, C>(Func<A, B, C> f, A a)
        => y => f(a, y);
    
    /// <summary>
    /// Composes two delegates
    /// </summary>
    /// <typeparam name="X1">The type input value</typeparam>
    /// <typeparam name="X2">The return type of the inner/first function and the input type of the outer/second function</typeparam>
    /// <typeparam name="X3">The return type of the second/outer function</typeparam>
    /// <param name="f">The inner function</param>
    /// <param name="g">The outer function</param>
    /// <returns></returns>
    public static Func<X1, X3> compose<X1, X2, X3>(Func<X1, X2> f, Func<X2, X3> g)
        => x => g(f(x));

    /// <summary>
    /// Defines a delegate X1->X4 via chained composition of X1->X2, X->X3, and X3->X4 delegates
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="X3"></typeparam>
    /// <typeparam name="X4"></typeparam>
    /// <param name="f"></param>
    /// <param name="g"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public static Func<X1, X4> compose<X1, X2, X3, X4>(Func<X1, X2> f, Func<X2, X3> g, Func<X3, X4> h)
        => x => h(g(f(x)));

    /// <summary>
    /// Defines a constant delegate over (X,_)
    /// </summary>
    /// <typeparam name="X">The input type</typeparam>
    /// <param name="x">The output value</param>
    /// <param name="y">The forgotten value</param>
    /// <returns></returns>
    public static X @const<X>(X x, object y)
        => x;
}