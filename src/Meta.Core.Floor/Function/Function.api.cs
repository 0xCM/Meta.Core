//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Constructs a function from a from a delegate of type X->Y
    /// </summary>
    /// <typeparam name="X">The input type</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X, Y> func<X, Y>(Func<X, Y> f)
        => Function.wrap(f);

    /// <summary>
    /// Constructs a function from a from a delegate of type X1->X2->Y
    /// </summary>
    /// <typeparam name="X1">The type of the first input parameter</typeparam>
    /// <typeparam name="X2">The type of the second input parameter</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X1, X2, Y> func<X1, X2, Y>(Func<X1, X2, Y> f)
        => Function.wrap(f);

    /// <summary>
    /// Constructs a function from a from a delegate of type X1->X2->X3->Y
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X1, X2, X3, Y> func<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
        => Function.wrap(f);

    /// <summary>
    /// Lifts a delegate to a Function value
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    /// <typeparam name="X4">The type of the fourth parameter</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X1, X2, X3, X4, Y> func<X1, X2, X3, X4, Y>(Func<X1, X2, X3, X4, Y> f)
        => Function.wrap(f);

    /// <summary>
    /// Flows an input value into a function to effect evaluation
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The evaluation function</param>
    /// <returns>The function evaluation f(x)</returns>
    public static Y pipe<X, Y>(X x, Function<X, Y> f)
        => x > f;

    /// <summary>
    /// Defines a pipe X1->X2->X3 via two functions
    /// </summary>
    /// <typeparam name="X1">The input type</typeparam>
    /// <typeparam name="X2">The respective codomain/domain of the first function and second functions</typeparam>
    /// <typeparam name="X3">The the output type</typeparam>
    /// <param name="f">The pipe entry gateway</param>
    /// <param name="g">The pipe exit gateway</param>
    /// <returns>A delegate that effects the flow X1 -> X2 -> X3</returns>
    public static Func<X1, X3> pipe<X1, X2, X3>(Function<X1, X2> f, Function<X2, X3> g)
         => x => x > f > g;

    /// <summary>
    /// Defines a pipe X1->X2->X3->X4 via three functions
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="X3"></typeparam>
    /// <typeparam name="X4"></typeparam>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <param name="f3"></param>
    /// <returns>A delegate that effects the flow X1 -> .. -> X4</returns>
    public static Func<X1, X4> pipe<X1, X2, X3, X4>(Function<X1, X2> f1, Function<X2, X3> f2, 
        Function<X3, X4> f3)
            => x => x > f1 > f2 > f3;
}