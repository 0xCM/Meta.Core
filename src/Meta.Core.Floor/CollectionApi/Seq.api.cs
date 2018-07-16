//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;


using Meta.Core;
using Meta.Core.Modules;

using System.Collections.Generic;

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
    public static Seq<X> seq<X>(IEnumerable<X> values)
        => Seq.make(values);

    /// <summary>
    /// Applies the supplied item-index function to each element in the input sequence to produce a new sequence
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="s">The sequence to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static Seq<S> mapi<T, S>(Seq<T> s, Func<int, T, S> f)
        => Seq.mapi(s, f);

    /// <summary>
    /// Consructs a sequence of indexed pairs of <typeparamref name="X"/> values from a stream
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="values">The values from which to construct the sequence</param>
    /// <returns></returns>
    public static Seq<(int i, X value)> seqi<X>(IEnumerable<X> values)
        => mapi(Seq.make(values), (i, v) => (i, v));

    /// <summary>
    /// Consructs a sequence of indexed pairs of <typeparamref name="X"/> values from an existing sequence
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="s">The values from which to construct the sequence</param>
    /// <returns></returns>
    public static Seq<(int i, X value)> seqi<X>(Seq<X> s)
        => mapi(s, (i, item) => (i, item));

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
    /// Produces a sequence of relatively contiguous values within a specified range
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="min">The first value of the sequence</param>
    /// <param name="max">The last value of the sequence</param>
    /// <returns></returns>
    static IEnumerable<T> _range<T>(T min, T max)
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

    /// <summary>
    /// Zips the first stream with the second via a supplied mapping function
    /// </summary>
    /// <typeparam name="X">The item tyep of the first sequence</typeparam>
    /// <typeparam name="Y">The item type of the second sequence</typeparam>
    /// <typeparam name="Z">The mapping function codomain</typeparam>
    /// <param name="sx">The first sequence</param>
    /// <param name="sy">The second sequence</param>
    /// <param name="f">The mapping function</param>
    /// <returns></returns>
    public static Seq<Z> zip<X, Y, Z>(Seq<X> sx, Seq<Y> sy, Func<X, Y, Z> f)
        => seq(sx.Stream().Zip(sy.Stream(), f));

    /// <summary>
    /// Zips the first sequence with the second into a sequence of 2-tuples
    /// </summary>
    /// <typeparam name="X1">The item tyep of the first sequence</typeparam>
    /// <typeparam name="X2">The item type of the second sequence</typeparam>
    /// <param name="sx">The first sequence</param>
    /// <param name="sy">The second sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2)> zip<X1, X2>(Seq<X1> sx, Seq<X2> sy)
        => Seq.zip(sx, sy);

    /// <summary>
    /// Joins three sequences to produce a sequence of 3-tuples
    /// </summary>
    /// <typeparam name="X1">The item type of the first sequence</typeparam>
    /// <typeparam name="X2">The item type of the second sequence</typeparam>
    /// <typeparam name="X3">The item type of the third sequence</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3)> zip<X1, X2, X3>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3)
        => Seq.make(zip(s1, s2).Stream().Zip(s3.Stream(), (a, b) => (a.x1, a.x2, b)));

    /// <summary>
    /// Joins four sequences to produce a sequence of 4-tuples
    /// </summary>
    /// <typeparam name="X1">The item type of the first sequence</typeparam>
    /// <typeparam name="X2">The item type of the second sequence</typeparam>
    /// <typeparam name="X3">The item type of the third sequence</typeparam>
    /// <typeparam name="X4">The item type of the fourth sequence</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <param name="s4">The fourth input sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3, X4 x4)> zip<X1, X2, X3, X4>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4)
        => Seq.make(zip(s1, s2, s3).Stream().Zip(s4.Stream(), (a, b) => (a.x1, a.x2, a.x3, b)));

    /// <summary>
    /// Joins five sequences to produce a sequence of 5-tuples
    /// </summary>
    /// <typeparam name="X1">The item type of the first sequence</typeparam>
    /// <typeparam name="X2">The item type of the second sequence</typeparam>
    /// <typeparam name="X3">The item type of the third sequence</typeparam>
    /// <typeparam name="X4">The item type of the fourth sequence</typeparam>
    /// <typeparam name="X5">The item type of the fifth sequence</typeparam>
    /// <param name="s1">The first input sequence</param>
    /// <param name="s2">The second input sequence</param>
    /// <param name="s3">The third input sequence</param>
    /// <param name="s4">The fourth input sequence</param>
    /// <param name="s5">The fifth input sequence</param>
    /// <returns></returns>
    public static Seq<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)> zip<X1, X2, X3, X4, X5>(Seq<X1> s1, Seq<X2> s2, Seq<X3> s3, Seq<X4> s4, Seq<X5> s5)
        => Seq.make(zip(s1, s2, s3, s4).Stream().Zip(s5.Stream(), (a, b) => (a.x1, a.x2, a.x3, a.x4, b)));

}