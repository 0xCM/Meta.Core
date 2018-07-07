//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
    /// Applies a function to a sequence and returns the result
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="f">The function to apply</param>
    /// <param name="s">The input sequence</param>
    /// <returns></returns>
    public static Seq<Y> map<X, Y>(Seq<X> s, Func<X, Y> f)
        => Seq.map(f, s);

    /// <summary>
    /// Applies the supplied item-index function to each element in the input sequence to produce a new sequence
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="list">The list to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static Seq<S> mapi<T, S>(Seq<T> s, Func<int, T, S> f)
    {
        var idx = 0;
        return Seq.make(
            from item in s.Stream()
            select f(idx++, item)
            );
    }


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

    /// <summary>
    /// Returns true if array is empty, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static bool empty<X>(Seq<X> a)
        => a.Any();

    /// <summary>
    /// Retrieves the last element if it exists; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="s">The array to examine</param>
    /// <returns></returns>
    public static Option<X> last<X>(Seq<X> s)
        => s.Last();

    /// <summary>
    /// Retrieves the first element; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="s">The sequence to examine</param>
    /// <returns></returns>
    public static Option<X> first<X>(Seq<X> s)
        => s.First();

    /// <summary>
    /// Retrieves the length of the array
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The sequence to examine</param>
    /// <returns></returns>
    public static int len<X>(Seq<X> a)
        => a.Stream().Count();

    /// <summary>
    /// Collapses a sequence of item sequences into a sequence of items
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="ss">The input sequence</param>
    /// <returns></returns>
    public static Seq<X> flatten<X>(Seq<Seq<X>> ss)
        => Seq.flatten(ss);
}