//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Elemental value producer
    /// </summary>
    /// <typeparam name="X">The type of produced value</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<X> StreamSource<X>();


    /// <summary>
    /// Elemental value receiver
    /// </summary>
    /// <typeparam name="X">The type of received value</typeparam>
    /// <returns></returns>
    public delegate void StreamTarget<in X>(IEnumerable<X> stream);

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


}
