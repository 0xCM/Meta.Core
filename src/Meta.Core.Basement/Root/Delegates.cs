//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Classifies an binary order evaluation
    /// </summary>
    public enum Ordering
    {
        /// <summary>
        /// Indicates the left value was less than the right value
        /// </summary>
        LT = -1,

        /// <summary>
        /// Indcates the the left and right values were equal
        /// </summary>
        EQ = 0,

        /// <summary>
        /// Indicates the left value was greater than the right value
        /// </summary>
        GT = 1
    }

    /// <summary>
    /// Canonical signature for a function that determines whether one value is 
    /// less than, greater than or equal to another
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    public delegate Ordering Orderer<in X>(X x1, X x2);

    /// <summary>
    /// Contract for a function that materializes a stream
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<X> Streamer<X>();

    /// <summary>
    /// Contract for unary function composition
    /// </summary>
    /// <typeparam name="X">The domain of the first function</typeparam>
    /// <typeparam name="Y">The codomain of the first function and the domain of the second function</typeparam>
    /// <typeparam name="Z">The codomain of the second function</typeparam>
    /// <param name="f">The first function</param>
    /// <param name="g">The second function</param>
    /// <returns></returns>
    public delegate Func<X, Z> Composer<X, Y, Z>(Func<X, Y> f, Func<Y, Z> g);


    /// <summary>
    /// Contract for function that finds a key-identified value in some source
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="key">The key value</param>
    /// <returns></returns>
    public delegate Option<TValue> KeyedLookup<in TKey, TValue>(TKey key);

    /// <summary>
    /// Contract for function that determines whether two values are equal
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="x1">The first value</param>
    /// <param name="x2">The second value</param>
    /// <returns></returns>
    /// <remarks>Every set, as defined within this infractructure has a canonical combiner</remarks>
    public delegate bool Equator<in X>(X x1, X x2);

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
