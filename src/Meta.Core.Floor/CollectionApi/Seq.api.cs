﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;


using Meta.Core;
using Meta.Core.Modules;

using G = System.Collections.Generic;

partial class metacore
{
    /// <summary>
    /// Consructs a <see cref="Seq{T}"/> from a list of values
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="values">The values from which to construct the sequence</param>
    /// <returns></returns>
    public static Seq<X> seq<X>(params X[] values)
        => Seq.make(values);

    /// <summary>
    /// Consructs a <see cref="Seq{T}"/> from a stream of values
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="values">The values from which to construct the sequence</param>
    /// <returns></returns>
    public static Seq<X> seq<X>(G.IEnumerable<X> values)
        => Seq.make(values);


    /// <summary>
    /// Combines a sequence of values with the canonical <typeparamref name="X"/> semigroup combiner
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static X combine<X>(Seq<X> values)
        => Seq.combine(operators.add, values, default);

    /// <summary>
    /// Produces a sequence of relatively contiguous values within a specified range
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="min">The first value of the sequence</param>
    /// <param name="max">The last value of the sequence</param>
    /// <returns></returns>
    public static Seq<T> range<T>(T min, T max) 
        => Seq.make(_range(min, max));

    /// <summary>
    /// Wraps the enumerable with <see cref="Deferred{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static Deferred<T> defer<T>(Seq<T> items)
            => new Deferred<T>(items.Stream());

    /// <summary>
    /// Applies a function to a sequence and returns the result
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="f">The function to apply</param>
    /// <param name="s">The input sequence</param>
    /// <returns></returns>
    public static Seq<Y> map<X, Y>(Func<X, Y> f, Seq<X> s)
        => Seq.map(f, s);

    /// <summary>
    /// Produces a sequence of relatively contiguous values within a specified range
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="min">The first value of the sequence</param>
    /// <param name="max">The last value of the sequence</param>
    /// <returns></returns>
    static G.IEnumerable<T> _range<T>(T min, T max)
    {
        var currrent = min;
        while (operators.lteq(currrent, max))
        {
            yield return currrent;
            currrent = operators.increment(currrent);
        }
    }

}