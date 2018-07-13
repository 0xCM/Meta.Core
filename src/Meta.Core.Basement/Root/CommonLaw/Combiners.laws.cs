//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;


    /// <summary>
    /// Contract for an homogenous combiner: a function that creates 
    /// a new X-value by combining two existing X-values
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    /// <remarks>Every group-like structure has a canonical combiner</remarks>
    public delegate X Combiner<X>(X x1, X x2);

    /// <summary>
    /// Contract signature for a non-homogenous, binary combinator
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public delegate Y Combiner<in X1, in X2, out Y>(X1 x, X2 y);

    /// <summary>
    /// Canonical signature for a (potentially) non-homogenous ternary combinator
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="X3"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <param name="x3"></param>
    /// <returns></returns>
    public delegate Y Combiner<in X1, in X2, in X3, out Y>(X1 x1, X2 x2, X3 x3);


}