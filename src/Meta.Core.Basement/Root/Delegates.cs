//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;


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
