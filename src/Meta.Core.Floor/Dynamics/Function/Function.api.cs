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
    public static Function<X, Y> function<X, Y>(Func<X, Y> f)
        => Function.make(f);

    /// <summary>
    /// Constructs a function from a from a delegate of type X1->X2->Y
    /// </summary>
    /// <typeparam name="X1">The type of the first input parameter</typeparam>
    /// <typeparam name="X2">The type of the second input parameter</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X1, X2, Y> function<X1, X2, Y>(Func<X1, X2, Y> f)
        => Function.make(f);

    /// <summary>
    /// Constructs a function from a from a delegate of type X1->X2->X3->Y
    /// </summary>
    /// <typeparam name="X1">The type of the first parameter</typeparam>
    /// <typeparam name="X2">The type of the second parameter</typeparam>
    /// <typeparam name="X3">The type of the third parameter</typeparam>
    /// <typeparam name="Y">The return type</typeparam>
    /// <param name="f">The delegate to lift</param>
    /// <returns></returns>
    public static Function<X1, X2, X3, Y> function<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
        => Function.make(f);

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
    public static Function<X1, X2, X3, X4, Y> function<X1, X2, X3, X4, Y>(Func<X1, X2, X3, X4, Y> f)
        => Function.make(f);


}