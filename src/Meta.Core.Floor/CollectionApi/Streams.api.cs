//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Converts a sequence of 2-tuples to a <see cref="IReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TValue> dict<TKey, TValue>(IEnumerable<(TKey Key, TValue Value)> items)
        => items.ToDictionary(x => x.Key, x => x.Value);

    /// <summary>
    /// Represents an input sequence as a <see cref="IReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TSource">The input sequence item type</typeparam>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="source">The input sequence</param>
    /// <param name="keySelector">The key selector</param>
    /// <param name="valueSelector">The value selector</param>
    /// <returns></returns>    
    public static IReadOnlyDictionary<TKey, TValue> dict<TSource, TKey, TValue>
        (IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
            => source.ToDictionary(keySelector, valueSelector);

    /// <summary>
    /// Represents an input sequence as a <see cref="IReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TSource">The input sequence item type</typeparam>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="source">The input sequence</param>
    /// <param name="keySelector">The key selector</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TSource> dict<TSource, TKey, TValue>
        (IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => source.ToDictionary(keySelector).ToReadOnlyDictionary();

    /// <summary>
    /// Yields a <see cref="IReadOnlyList{T}"/> realization instance from an input sequence
    /// </summary>
    /// <typeparam name="T">The input item type</typeparam>
    /// <param name="items">The input items</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static ReadOnlyList<T> rolist<T>(IEnumerable<T> items)
        => ReadOnlyList.Create(items ?? new T[] { });

    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyList<T> roitems<T>(params T[] parms)
        => ReadOnlyList.Create(parms);

    /// <summary>
    /// Creates an empty readonly list
    /// </summary>
    /// <typeparam name="T">The list item type</typeparam>
    /// <returns></returns>
    public static ReadOnlyList<T> rolist<T>()
        => ReadOnlyList<T>.Empty;

    /// <summary>
    /// Evaluates the sequence
    /// </summary>
    /// <typeparam name="T">The input item type</typeparam>
    /// <param name="items">The input items</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<T> rovalues<T>(IEnumerable<T> items)
        where T : IValueObject => new ImmutableValueObjectList<T>(items ?? stream<T>());

    /// <summary>
    /// Applies the supplied function to each element in the input sequence for which a specified predicate is satisfied
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="seq">The sequence to transform</param>
    /// <param name="predicate">The predicate that is evaluated</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static ReadOnlyList<S> mapif<T, S>(IEnumerable<T> seq, Func<T, bool> predicate, Func<T, S> f, bool PLL = false)
        => map(seq.Where(predicate), f, PLL);

    /// <summary>
    /// Applies the supplied function to each element in the input sequence to produce a list
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="seq">The sequence to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static ReadOnlyList<S> mapi<T, S>(IEnumerable<T> seq, Func<int, T, S> f)
    {
        var src = seq.ToArray();
        var dst = new S[src.Length];
        for (var i = 0; i < src.Length; i++)
            dst[i] = f(i, src[i]);
        return ReadOnlyList.Create(dst);
    }

    /// <summary>
    /// Applies the supplied function to each element in the input sequence up to a specified maximum
    /// number of sequence elements
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="seq">The sequence to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static ReadOnlyList<S> mapi<T, S>(IEnumerable<T> seq, int limit, Func<int, T, S> f) =>
        seq.Mapi(limit, f);

    /// <summary>
    /// Applies the supplied function to each element in the input sequence
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="seq">The sequence to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static ReadOnlyList<S> map<T, S>(IEnumerable<T> seq, Func<T, S> f, bool PLL = false)
    {
        if (PLL)
        {
            var bag = new ConcurrentBag<S>();
            seq.AsParallel().ForAll(item => bag.Add(f(item)));
            return bag.ToReadOnlyList();
        }
        else
            return seq.Map(f);
    }

    /// <summary>
    /// Creates a mutable <see cref="MutableSet{T}"/> from the supplied sequence
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="items">The sequence</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static MutableSet<T> setM<T>(IEnumerable<T> items)
        => new MutableSet<T>(items);

    /// <summary>
    /// Creates a <see cref="HashSet{T}"/> from the supplied sequence
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="items">The sequence</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static ReadOnlySet<T> roset<T>(IEnumerable<T> items)
        => new ReadOnlySet<T>(items);

    /// <summary>
    /// Creates a <see cref="HashSet{T}"/> from an array
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="items">The array</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static ReadOnlySet<T> roset<T>(params T[] items)
        => new ReadOnlySet<T>(items);

    /// <summary>
    /// Creates a mutable <see cref="MutableSet{T}"/> from an array
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="items">The sequence</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static MutableSet<T> setM<T>(params T[] items)
        => new MutableSet<T>(items);

    /// <summary>
    /// Forms a union from the supplied sequences
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="sequences">The first sequence</param>
    [DebuggerStepperBoundary]
    public static IEnumerable<T> unionize<T>(params IEnumerable<T>[] sequences)
        => new MutableSet<T>(sequences.Reduce());

    /// <summary>
    /// Collapses an homogenous sequence of element sequences into a homogenous sequence of elements
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="source">The source elements</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static IEnumerable<T> flatten<T>(IEnumerable<IEnumerable<T>> source)
            => source.SelectMany(x => x);

    /// <summary>
    /// Carries an homogenous sequence of elements onto another via the supplied selector
    /// </summary>
    /// <typeparam name="TSource">The input element type</typeparam>
    /// <typeparam name="TResult">The output element type</typeparam>
    /// <param name="source">The source elements</param>
    /// <param name="selector">The selector</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static IEnumerable<TResult> flatMap<TSource, TResult>
        (IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
            => Enumerable.SelectMany(source, selector);

    /// <summary>
    /// Creates a stream from an arbitrary number of items
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="items">The items included in the stream</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(params T[] items)
        => items;

    /// <summary>
    /// Constructs a nonemmpty stream
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="head">The first element in the stream</param>
    /// <param name="tail">The remaining elements of the stream</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(T head, params T[] tail)
    {
        yield return head;
        foreach (var t in tail)
            yield return t;
    }

    /// <summary>
    /// Concatenates the supplied streams to create a new stream
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="head">The first part of the sequence</param>
    /// <param name="tail">The last part of the sequence</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(IEnumerable<T> head, IEnumerable<T> tail)
        => head.Concat(tail);

    /// <summary>
    /// Concatenates the supplied streams to create a new stream
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <param name="s3"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(IEnumerable<T> s1, IEnumerable<T> s2, IEnumerable<T> s3)
        => s1.Concat(s2).Concat(s3);

    /// <summary>
    /// Concatenates the supplied streams to create a new stream
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <param name="s3"></param>
    /// <param name="s4"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(IEnumerable<T> s1, IEnumerable<T> s2, IEnumerable<T> s3, IEnumerable<T> s4)
        => s1.Concat(s2).Concat(s3).Concat(s4);

    /// <summary>
    /// Concatenates an arbitrary number of streams
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="sequences">The sequence to concatenate</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static IEnumerable<T> join<T>(params IEnumerable<T>[] sequences)
        => sequences.SelectMany(x => x);

    /// <summary>
    /// Yields a single element from the stream if that sequence contains exactly one
    /// element; otherwise, an exception is raised
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="sequence">The sequence to examine</param>
    /// <returns></returns>
    public static T single<T>(IEnumerable<T> sequence)
        => sequence.Single();

    /// <summary>
    /// Defines a stream based on function result values
    /// </summary>
    /// <typeparam name="X">The type of the streamed item</typeparam>
    /// <param name="x0">The first input to the producer</param>
    /// <param name="producer">The item emitter</param>
    /// <returns></returns>
    public static IEnumerable<X> yield<X>(X x0, Func<X, Option<X>> producer)
    {
        var option = producer(x0);
        while (option)
        {
            var value = option.ValueOrDefault();
            yield return value;

            option = producer(value);
        }
    }

}
