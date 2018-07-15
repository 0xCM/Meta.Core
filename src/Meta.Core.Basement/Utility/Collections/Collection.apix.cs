//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Diagnostics;

//using static metacore;
using Meta.Core;
using static CommonMessages;

using G = System.Collections.Generic;

/// <summary>
/// Defines set extensions
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Creates a transformed array
    /// </summary>
    /// <typeparam name="S">The source item type</typeparam>
    /// <typeparam name="T">The target item type</typeparam>
    /// <param name="src">The source sequence</param>
    /// <param name="transform">The transformation function</param>
    /// <returns></returns>
    public static T[] ToArray<S, T>(this IEnumerable<S> src, Func<S, T> transform)
        => src.Select(transform).ToArray();


    /// <summary>
    /// Returns a segment of an array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static T[] SubArray<T>(this T[] input, int startIndex, int length)
    {
        var result = MutableList.Create<T>();
        for (int i = startIndex; i < length; i++)
            result.Add(input[i]);
        return result.ToArray();
    }

    /// <summary>
    /// Creates a new array by appending the elements determined by the second array
    /// to the elements determined by the first array
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="head">The first array</param>
    /// <param name="tail">The second array</param>
    /// <returns></returns>
    public static X[] Append<X>(this X[] head, X[] tail)
    {
        var result = new X[head.Length + tail.Length];
        Array.Copy(head, 0, result, 0, head.Length);
        Array.Copy(tail, 0, result, head.Length, tail.Length);
        return result;
    }

    /// <summary>
    /// Creates a new array from a (contiguous) subset of an existing array
    /// </summary>
    /// <typeparam name="T">The array element type</typeparam>
    /// <param name="src">The source array</param>
    /// <param name="startpos">The position of the first element of the source array </param>
    /// <param name="endpos">The position of the last element of the source array</param>
    /// <returns></returns>
    public static T[] Subset<T>(this T[] src, int startpos, int endpos)
    {
        var len = endpos - startpos + 1;
        var dst = new T[len];
        Array.Copy(src, startpos, dst, 0, len);
        return dst;
    }

    /// <summary>
    /// Applies an action to each member of the collection
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items to enumerate</param>
    /// <param name="action">The action to apply</param>
    /// <param name="pll">Indicates whether the action should be applied concurrently</param>
    [DebuggerStepThrough]
    public static void Iterate<T>(this IEnumerable<T> items, Action<T> action, bool pll = false)
    {
        if (pll)
            items.AsParallel().ForAll(action);
        else
            foreach (var item in items)
                action(item);
    }
    /// <summary>
    /// Convenience wrapper for Enumerable.SelectMany that yields a sequence of elements from a sequence of sequences
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static IEnumerable<T> Reduce<T>(this IEnumerable<IEnumerable<T>> x)
        => x.SelectMany(y => y);

    /// <summary>
    /// Prepends one or more items to the head of the sequence
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The sequence that will be prependend</param>
    /// <param name="preceding">The items that will be prepended</param>
    /// <returns></returns>
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items, params T[] preceding)
        => preceding.Concat(items);

    /// <summary>
    /// Partitions the sequence into subsequences of a maximum length
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static IEnumerable<IReadOnlyList<T>> Partition<T>(this IEnumerable<T> items, int max)
    {
        var list = MutableList.Create<T>();
        foreach (var item in items)
        {
            list.Add(item);
            if (list.Count == max)
            {
                yield return list;
                list = MutableList.Create<T>();
            }
        }
        if (list.Count != 0)
            yield return list;
    }

    /// <summary>
    /// Applies a function to an input sequence to yield a transformed output sequence
    /// </summary>
    /// <typeparam name="TSource">The type of input element</typeparam>
    /// <typeparam name="TResult">The type of output element</typeparam>
    /// <param name="src">The source sequence</param>
    /// <param name="f">The mapping function</param>
    public static ReadOnlyList<TResult> Map<TSource, TResult>(this IEnumerable<TSource> src, Func<TSource, TResult> f)
        => ReadOnlyList.Create(src.Select(item => f(item)));

    /// <summary>
    /// Applies a function to an input sequence to yield a transformed output sequence
    /// </summary>
    /// <typeparam name="TSource">The type of input element</typeparam>
    /// <typeparam name="TResult">The type of output element</typeparam>
    /// <param name="src">The source sequence</param>
    /// <param name="f">The mapping function</param>
    /// <param name="max">The maximum number of elements from the sequence to map</param>      
    internal static ReadOnlyList<TResult> ApplyI<TSource, TResult>(this IEnumerable<TSource> src, int max, Func<int, TSource, TResult> f)
    {
        var dstList = MutableList.Create<TResult>();
        var srcList = src.ToList();
        for (int i = 0; i < max; i++)
            dstList.Add(f(i, srcList[i]));
        return ReadOnlyList.Create(dstList);
    }

    /// <summary>
    /// Applies a function to an input sequence to yield a transformed output sequence
    /// </summary>
    /// <typeparam name="TSource">The type of input element</typeparam>
    /// <typeparam name="TResult">The type of output element</typeparam>
    /// <param name="src">The source sequence</param>
    /// <param name="mapper">The mapping function</param>
    /// <param name="limit">The inclusive upper bound of the index</param>      
    public static ReadOnlyList<TResult> Mapi<TSource, TResult>(this IEnumerable<TSource> src, int limit,
        Func<int, TSource, TResult> mapper) => src.ApplyI(limit, mapper);

    /// <summary>
    /// Applies a function to an input sequence to yield a transformed output sequence
    /// </summary>
    /// <typeparam name="TSource">The type of input element</typeparam>
    /// <typeparam name="TResult">The type of output element</typeparam>
    /// <param name="src">The source sequence</param>
    /// <param name="mapper">The mapping function</param>
    public static ReadOnlyList<TResult> Mapi<TSource, TResult>(this IEnumerable<TSource> src, Func<int, TSource, TResult> mapper)
    {
        var dstList = MutableList.Create<TResult>();
        var srcList = src.ToList();
        for (int i = 0; i < srcList.Count; i++)
            dstList.Add(mapper(i, srcList[i]));
        return ReadOnlyList.Create(dstList);
    }

    /// <summary>
    /// Creates a read-only list from a source sequence
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <returns></returns>
    public static ReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> src)
        => ReadOnlyList.Create(src);

    /// <summary>
    /// Returnes the first element if any exist or the suppllied default if none do
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items to search</param>
    /// <param name="default">The replacement value if the sequence is empty</param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> items, T @default)
        => items.Any() ? items.First() : @default;

    /// <summary>
    /// Returns true if the predicate is satisfied by some item in the sequence
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items to search</param>
    /// <param name="f">The predicate to evaluate</param>
    /// <returns>True if the predicate is satisfied by some element in the supplied sequence</returns>
    public static bool Exists<T>(this IEnumerable<T> items, Predicate<T> f)
    {
        foreach (var item in items)
            if (f(item))
                return true;
        return false;
    }

    /// <summary>
    /// Splits the input into two parts according to a supplied predicate
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items to evaluate</param>
    /// <param name="predicate">The predicate used in the evaluation</param>
    /// <returns>A 2-tuple whose first member reflects the items that evaluated to false 
    /// and whose second member reflects the items that evaluated to true</returns>
    public static (IEnumerable<T> @false, IEnumerable<T> @true)
        Split<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        var f = MutableList.Create<T>();
        var t = MutableList.Create<T>();
        foreach (var item in items)
            if (predicate(item))
                t.Add(item);
            else
                f.Add(item);
        return (f, t);
    }

    /// <summary>
    /// Determines whether a collection contains any elements
    /// </summary>
    /// <typeparam name="T">The type of item contained by the collection</typeparam>
    /// <param name="collection">The collection to examine</param>
    /// <returns></returns>
    public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        => collection.Count == 0;

    /// <summary>
    /// Determines whether a collection contains at least one element
    /// </summary>
    /// <typeparam name="T">The type of item contained by the collection</typeparam>
    /// <param name="collection">The collection to examine</param>
    /// <returns></returns>
    public static bool IsNonEmpty<T>(this IReadOnlyCollection<T> collection)
        => collection.Count != 0;

    /// <summary>
    /// Runs through a <see cref="IEnumerable{T}"/> in batches
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="source">The item source</param>
    /// <param name="max">The maximum number of elements per batch</param>
    /// <returns></returns>
    /// <remarks>
    /// Implementation inspired from https://github.com/morelinq/MoreLINQ
    /// </remarks>
    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int max)
    {
        var buffer = default(T[]);
        var count = 0;
        var sw = default(Stopwatch);

        foreach (var item in source)
        {
            if (buffer == null)
            {
                sw = Stopwatch.StartNew();
                buffer = new T[max];
            }

            buffer[count++] = item;

            if (count != max)
                continue;
            var elapsed = sw.ElapsedMilliseconds;
            yield return buffer.ToList();

            buffer = null;
            count = 0;
        }

        if (buffer != null && count > 0)
            yield return buffer.Take(count);
    }

    /// <summary>
    /// Applies the supplied processor to blocks of at most <paramref name="batchSize"/> items at a time yielded from the enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items">The items to process</param>
    /// <param name="processor">The processor</param>
    /// <param name="batchSize">The block size</param>
    public static void ProcessBatches<T>(this IEnumerable<T> items, Action<IReadOnlyList<T>> processor, int batchSize, Action<int> processed)
    {
        var batch = MutableList.Create<T>(batchSize);
        foreach (var item in items)
        {
            batch.Add(item);
            if (batch.Count == batchSize)
            {
                processor(batch);
                processed(batch.Count);
                batch.Clear();
            }
        }

        if (batch.Count != 0)
        {
            processor(batch);
            processed(batch.Count);
        }

        batch.Clear();
    }

    /// <summary>
    /// Applies the supplied processor to blocks of at most <paramref name="batchSize"/> items at a time yielded from the enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items">The items to process</param>
    /// <param name="processor">The processor</param>
    /// <param name="batchSize">The block size</param>
    public static void ProcessBatches<T>(this IEnumerable<T> items, Action<IReadOnlyList<T>> processor, int batchSize)
        => items.ProcessBatches(processor, batchSize, (count) => { });


    /// <summary>
    /// Applies a function to the first item in the list that satisfies the predicate if such an item exists.
    /// If no such item exists, the function is applied to the default value of the item
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <typeparam name="R">The function result type</typeparam>
    /// <param name="items">The items to search</param>
    /// <param name="predicate">The predicate applied during the search</param>
    /// <param name="f">The function to apply to the identified item</param>
    /// <returns></returns>
    public static R OnFirstOrDefault<T, R>(this IEnumerable<T> items, Predicate<T> predicate, Func<T, R> f) =>
        f(items.FirstOrDefault(x => predicate(x)));

    //Prime numbers to use when generating a hash code. Taken from John Skeet's answer on SO:
    //http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
    const int P1 = 17;
    const int P2 = 23;

    /// <summary>
    /// Helper to compute hash code from a collection of items
    /// </summary>
    /// <typeparam name="S">The item type</typeparam>
    /// <param name="items">The items</param>
    /// <returns></returns>
    public static int GetHashCodeAggregate<S>(this IEnumerable<S> items)
    {
        if (items == null)
            return 0;

        unchecked
        {
            var hash = P1;
            foreach (var item in items)
                hash = hash * P2 + item.GetHashCode();
            return hash;
        }
    }

    /// <summary>
    /// Returns the second term of the sequence if it exists; otherwise raises an exception
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static T Second<T>(this IEnumerable<T> items)
        => items.Skip(1).Take(1).Single();

    /// <summary>
    /// Returns the third term of the sequence if it exists; otherwise raises an exception
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static T Third<T>(this IEnumerable<T> items)
        => items.Skip(2).Take(1).Single();

    /// <summary>
    /// Returns the second term of the sequence if it exists; otherwise returns the default value
    /// </summary>
    /// <typeparam name="T">The sequence item type</typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static T SecondOrDefault<T>(this IEnumerable<T> items)
        => items.Take(2).LastOrDefault();

    /// <summary>
    /// Retrieves the first value in the list, if any
    /// </summary>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="values">The values to search</param>
    /// <param name="ifNone">Invoked if no match was found</param>
    /// <returns></returns>
    public static Option<TValue> TryGetFirst<TValue>(this IEnumerable<TValue> values, Func<IAppMessage> ifNone = null)
        where TValue : class
    {
        var first = values.FirstOrDefault();
        if (first == null)
            return Option.None<TValue>(ifNone?.Invoke());
        else
            return Option.Some(first);
    }

    /// <summary>
    /// Retrieves the first value in the list satisfying a predicate, if found, otherwise None
    /// </summary>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="values">The values to search</param>
    /// <param name="ifNone">Invoked if no match was found</param>
    /// <param name="predicate">Adudicates whether there is a match</param>
    /// <returns></returns>
    public static Option<TValue> TryGetFirst<TValue>(this IEnumerable<TValue> values,
        Func<TValue, bool> predicate, Func<IAppMessage> ifNone = null)
            where TValue : class
    {
        foreach (var value in values)
        {
            if (predicate(value))
                return value;
        }
        return Option.None<TValue>(ifNone?.Invoke());
    }

    /// <summary>
    /// Logically equivalent to <see cref="Enumerable.Single{TSource}(IEnumerable{TSource})"/>, but returns None
    /// in lieu of throwing an exception if there is not exactly one item in the sequence
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static Option<TValue> TryGetSingle<TValue>(this IEnumerable<TValue> values)
        => values.Count() == 1
        ? values.Single()
        : (
                values.Count() == 0
             ? Option.None<TValue>(SequenceIsEmpty())
             : Option.None<TValue>(SequenceIsNotSingleton())
           );

    /// <summary>
    /// Logically equivalent to <see cref="Enumerable.Single{TSource}(IEnumerable{TSource})"/>, but returns None
    /// in lieu of throwing an exception if there is not exactly one item in the sequence
    /// </summary>
    /// <typeparam name="X">The stream item type</typeparam>
    /// <param name="stream">The stream to search</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns></returns>
    public static Option<X> TryGetSingle<X>(this IEnumerable<X> stream, Func<X, bool> predicate)
    {
        var satisfied = stream.Where(predicate).ToList();
        if (satisfied.Count == 0)
            return Option.None<X>(SequencePredicateUnsatisfied());
        else if (satisfied.Count > 1)
            return Option.None<X>(MoreThanOneSequencePredicate());
        else
            return Option.Some(satisfied[0]);
    }

    /// <summary>
    /// Searches for the first element in the stream that satisfies a predicate and returns the
    /// element if found; otherwise, returns None
    /// </summary>
    /// <typeparam name="X">The stream item type</typeparam>
    /// <param name="stream">The stream to search</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns></returns>
    public static Option<X> TryGetFirst<X>(this IEnumerable<X> stream, Func<X, bool> predicate)
        => stream.FirstOrDefault(predicate);

    /// <summary>
    /// Constructs a set from a sequence
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The item sequence</param>
    /// <returns></returns>
    public static ISet<T> ToSet<T>(this IEnumerable<T> items)
        => new HashSet<T>(items);

    /// <summary>
    /// Adds items to a list
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="list">The list to modify</param>
    /// <param name="items">The items to add</param>
    public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        => items.Iterate(item => list.Add(item));

    /// <summary>
    /// Constructs a set from a sequence projection
    /// </summary>
    /// <typeparam name="T">The source element type</typeparam>
    /// <typeparam name="U">The targert element type</typeparam>
    /// <param name="items">The item sequence</param>
    /// <returns></returns>
    public static ISet<U> ToSet<T, U>(this IEnumerable<T> items, Func<T, U> selector)
        => new HashSet<U>(items.Select(selector));

    /// <summary>
    /// Constructs a readonly set from a sequence
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static ReadOnlySet<T> ToReadOnlySet<T>(this IEnumerable<T> items)
        => new ReadOnlySet<T>(items);

    /// <summary>
    /// Adds a stream of items to a set
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="set">The set to which items will be added</param>
    /// <param name="items">The items to add</param>
    public static void AddRange<T>(this ISet<T> set, IEnumerable<T> items)
        => items.Iterate(item => set.Add(item));

    /// <summary>
    /// Determines whether a set is empty
    /// </summary>
    /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
    /// <param name="set">The set under examination</param>
    /// <returns></returns>
    public static bool IsEmpty<T>(this ISet<T> set)
        => set.Count == 0;

    /// <summary>
    /// Determines whether a set is nonempty
    /// </summary>
    /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
    /// <param name="set">The set under examination</param>
    /// <returns></returns>
    public static bool IsNonEmpty<T>(this ISet<T> set)
        => set.Count != 0;
    /// <summary>
    /// Produces a set that is formed from the union of the input set and sequenced items
    /// </summary>
    /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
    /// <param name="set">The set that will be joined with the sequence</param>
    /// <param name="items">The sequendce that will be joined with the set</param>
    /// <returns></returns>
    public static ISet<T> Union<T>(this ISet<T> set, IEnumerable<T> items)
        => new HashSet<T>(Enumerable.Union(set, items));

    /// <summary>
    /// Combines a stream with an exising set
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="set">The set that will be joined with the stream</param>
    /// <param name="stream">The stream that will be joined with the set</param>
    /// <returns></returns>
    public static ISet<T> Intersect<T>(this ISet<T> set, IEnumerable<T> stream)
        => new HashSet<T>(Enumerable.Intersect(set, stream));

    /// <summary>
    /// Enqueues a stream
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="queue">The destination queue</param>
    /// <param name="items">The items to enqueue</param>
    public static void Enqueue<T>(this Queue<T> queue, IEnumerable<T> items)
    {
        foreach (var item in items)
            queue.Enqueue(item);
    }

    /// <summary>
    /// Removes a specified number of items from a queue
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="queue">The queue from which items will be removed</param>
    /// <param name="count">The (maximum) number of items to remove</param>
    /// <returns></returns>
    public static IEnumerable<T> Dequeue<T>(this Queue<T> queue, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (queue.Count != 0)
                yield return queue.Dequeue();
        }
    }

    /// <summary>
    /// Pops all items off the queue
    /// </summary>
    /// <typeparam name="T">The type of value contained int he queue</typeparam>
    /// <param name="q">The queue to manipulate</param>
    /// <returns></returns>
    public static IEnumerable<T> Dequeue<T>(this ConcurrentQueue<T> q)
    {
        var item = default(T);
        var go = true;
        while (go)
        {
            if (q.TryDequeue(out item))
                yield return item;
            else
                go = false;
        }
    }

    /// <summary>
    /// Pushes a sequence of items into queue and returns the number of items enqueued
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="q">The queue to manipulate</param>
    /// <param name="items">The items to place on the qeeue</param>
    /// <returns></returns>
    public static int Enqueue<T>(this ConcurrentQueue<T> q, IEnumerable<T> items)
    {
        int count = 0;
        foreach (var item in items)
        {
            q.Enqueue(item);
            count++;
        }
        return count;
    }

    /// <summary>
    /// Pops a sequence of items off a queue
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="q">The queue to manipulate</param>
    /// <param name="max">The maximum number of items to remove</param>
    /// <returns></returns>
    public static IEnumerable<T> Dequeue<T>(this ConcurrentQueue<T> q, int max)
        => q.Dequeue().Take(max);

    /// <summary>
    /// Removes an element from the queue if one exists
    /// </summary>
    /// <typeparam name="Y">The element type</typeparam>
    /// <param name="q">the queue</param>
    /// <returns></returns>
    public static Option<Y> TryPop<Y>(this Queue<Y> q)
        => q.IsEmpty() ? Option.None<Y>() : Option.Some(q.Dequeue());

    /// <summary>
    /// Removes an element from the queue if one exists
    /// </summary>
    /// <typeparam name="Y">The element type</typeparam>
    /// <param name="q">the queue</param>
    /// <returns></returns>
    public static Option<Y> TryPop<Y>(this ConcurrentQueue<Y> q)
        => q.TryDequeue(out Y next) ? Option.Some(next) : Option.None<Y>();

    /// <summary>
    /// Creates a read-only list from an array
    /// </summary>
    /// <param name="src">The source array</param>
    /// <returns></returns>
    public static ReadOnlyList<T> ToReadOnlyList<T>(this T[] src)
        => ReadOnlyList.Create(src);

    /// <summary>
    /// Applies a function over designated items in an indexed sequence
    /// </summary>
    /// <typeparam name="TSource">The type of input element</typeparam>
    /// <typeparam name="TResult">The type of output element</typeparam>
    /// <param name="src"></param>
    /// <param name="minidx">The minimum index</param>
    /// <param name="maxidx">The maximum index</param>
    /// <param name="f">The mapping function</param>
    /// <returns></returns>
    public static IReadOnlyList<TResult> MapRange<TSource, TResult>(this IReadOnlyList<TSource> src, int minidx, int maxidx, Func<TSource, TResult> f)
    {
        var dst = MutableList.Create<TResult>();
        for (int i = minidx; i <= maxidx; i++)
            dst.Add(f(src[i]));
        return dst;
    }

    /// <summary>
    /// Determines whether to lists of value objects are equal
    /// </summary>
    /// <typeparam name="S">The type of value object</typeparam>
    /// <param name="x">The first list</param>
    /// <param name="y">The second list</param>
    /// <returns></returns>
    public static bool DeepEqualityWith<S>(this IReadOnlyList<S> x, IReadOnlyList<S> y)
    {
        if (x == null || y == null || x.Count != y.Count)
            return false;

        for (int i = 0; i < x.Count; i++)
        {
            //Yes, either x[i] or y[i} could be null but that would be a pretty
            //stupid list and we might as well blow up so we can fix whatever
            //mechanism is adding null items to the list
            if (!x[i].Equals(y[i]))
                return false;
        }
        return true;
    }

    /// <summary>
    /// A functional rendition of <see cref="ConcurrentBag{T}.TryTake(out T)"/> 
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="source">The collection to search</param>
    /// <returns></returns>
    public static Option<T> TryTake<T>(this ConcurrentBag<T> source)
        => (source.TryTake(out T element)) ? Option.Some(element) : Option.None<T>();


    /// <summary>
    /// Adds a collection of items to a bag
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="bag">The destination bag</param>
    /// <param name="items">The items to add</param>
    public static void AddRange<T>(this ConcurrentBag<T> bag, IEnumerable<T> items)
        => items.Iterate(item => bag.Add(item));
        //=> iter(items, bag.Add);

    /// <summary>
    /// Creates a read-only dictionary from the supplied enumerable and selector
    /// </summary>
    /// <typeparam name="TKey">The dictionary key type</typeparam>
    /// <typeparam name="TValue">The dictionary value type</typeparam>
    /// <param name="this">The extended type</param>
    /// <param name="keySelector"></param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IEnumerable<TValue> @this, 
        Func<TValue, TKey> keySelector) => @this.ToDictionary(keySelector);

    /// <summary>
    /// Creates a read-only dictionary from an existing mutable dictionary
    /// </summary>
    /// <typeparam name="TKey">The dictionary key type</typeparam>
    /// <typeparam name="TValue">The dictionary value type</typeparam>
    /// <param name="this">The extended type</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> @this)
        => new Dictionary<TKey, TValue>(@this);

    /// <summary>
    /// Creates a read-only dictionary from a stream of tuples
    /// </summary>
    /// <typeparam name="TKey">The dictionary key type</typeparam>
    /// <typeparam name="TValue">The dictionary value type</typeparam>
    /// <param name="this">The extended type</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IEnumerable<(TKey key, TValue value)> @this)
        => @this.ToDictionary(x => x.key, x => x.value);

    /// <summary>
    /// Creates a concurrent dictionary from the input sequence
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="values">The input sequence</param>
    /// <param name="keySelector"></param>
    /// <returns></returns>
    public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TKey, TValue>(this IEnumerable<TValue> values, Func<TValue, TKey> keySelector)
        => new ConcurrentDictionary<TKey, TValue>(
            from value in values select new KeyValuePair<TKey, TValue>(keySelector(value), value));

    /// <summary>
    /// Creates a concurrent dictionary from the input sequence
    /// </summary>
    /// <typeparam name="TSource">The input sequence type</typeparam>
    /// <typeparam name="TKey">The dictionary key type</typeparam>
    /// <typeparam name="TValue">The type of the indexed valuie</typeparam>
    /// <param name="sources">The input sequence</param>
    /// <param name="keySelector">Function that selects the key</param>
    /// <param name="valueSelector">Function that selects the value</param>
    /// <returns></returns>
    public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TSource, TKey, TValue>
        (this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
            => new ConcurrentDictionary<TKey, TValue>
                    (from item in sources select new KeyValuePair<TKey, TValue>(keySelector(item), valueSelector(item)));

    /// <summary>
    /// Addes the entries of the source dictionary to the destination dictionary
    /// </summary>
    /// <typeparam name="TKey">The common dictionary key type</typeparam>
    /// <typeparam name="TValue">The common dictionary value type</typeparam>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dst, IReadOnlyDictionary<TKey, TValue> src)
            => src.Iterate(s => dst.Add(s.Key, s.Value));


    /// <summary>
    /// Addes the key-value pairs to the extended dictionary
    /// </summary>
    /// <typeparam name="TKey">The dictionary key type</typeparam>
    /// <typeparam name="TValue">The dictionary value type</typeparam>
    /// <param name="dict">The extended dictionary</param>
    /// <param name="items">The items to add</param>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> items)
        => items.Iterate( item => dict.Add(item));

    /// <summary>
    /// Determines whether the dictionary has any the keys that are specified in a set
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="subject">The dictionary to evaluate</param>
    /// <param name="keys">The keys to check</param>
    /// <returns></returns>
    public static bool HasAnyKey<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> subject, IEnumerable<TKey> keys)
        => keys.Intersect(subject.Keys).Any();

    /// <summary>
    /// A <see cref="ConcurrentDictionary{TKey, TValue}"/> constructor function
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="d">The source dictionary</param>
    /// <returns></returns>
    public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TKey, TValue>(this IDictionary<TKey, TValue> d)
        => new ConcurrentDictionary<TKey, TValue>(d);

    /// <summary>
    /// Determines whether the dictionary has all of the keys that are specified in a set
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="subject">The dictionary to evaluate</param>
    /// <param name="keys">The keys to check</param>
    /// <returns></returns>
    public static bool HasAllKeys<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> subject, IEnumerable<TKey> keys)
        => keys.Count(k => subject.ContainsKey(k)) == keys.Count();

    /// <summary>
    /// Gets an item with the specified key from the dictionary if it exists or creates the item and adds it to the dictionary,
    /// returning the newly created item
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="dictionary">The dictionary to query and/or modify</param>
    /// <param name="key">The key</param>
    /// <param name="factory">Delegate that produces a value given a key</param>
    /// <returns></returns>
    /// <remarks>
    /// This is not thread-safe. If you need that, use the concurrent collections
    /// </remarks>
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
    {
        if (dictionary.ContainsKey(key))
            return dictionary[key];
        var value = factory(key);
        dictionary[key] = value;
        return value;
    }


    static Option<Y> guard<X, Y>(X x, Func<X, bool> predicate, Func<X, Option<Y>> f)
        => predicate(x) ? f(x) : Option.None<Y>();

    /// <summary>
    /// Retrieves the key-identified value if possible
    /// </summary>
    /// <typeparam name="TKey">The key</typeparam>
    /// <typeparam name="TValue">The type of value identified by the key</typeparam>
    /// <param name="subject">The collection to query</param>
    /// <param name="key">The key that identifies the value</param>
    /// <returns></returns>
    public static Option<TValue> TryFind<TKey, TValue>(this IDictionary<TKey, TValue> subject, TKey key)
        => guard(key,
            k => k != null,
            k => subject.TryGetValue(k, out TValue value)
                ? Option.Some(value)
                : Option.None<TValue>());

    /// <summary>
    /// Retrieves the key-identified value if possible
    /// </summary>
    /// <typeparam name="TKey">The key</typeparam>
    /// <typeparam name="TValue">The type of value identified by the key</typeparam>
    /// <param name="subject">The collection to query</param>
    /// <param name="key">The key that identifies the value</param>
    /// <returns></returns>
    public static Option<TValue> TryFind<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> subject,
        TKey key, Func<IAppMessage> ifNone = null)
            => key == null ? Option.None<TValue>()
              : (subject.TryGetValue(key, out TValue value)
              ? Option.Some(value)
              : Option.None<TValue>(ifNone?.Invoke()));

    /// <summary>
    /// Removes the key-identified value if possible
    /// </summary>
    /// <typeparam name="TKey">The key</typeparam>
    /// <typeparam name="TValue">The type of value identified by the key</typeparam>
    /// <param name="subject">The collection to query</param>
    /// <param name="key">The key that identifies the value</param>
    /// <returns></returns>
    public static Option<TValue> TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> subject, TKey key)
        => guard(key,
            k => k != null,
            k => subject.TryRemove(k, out TValue value)
                ? Option.Some(value)
                : Option.None<TValue>());

    /// <summary>
    /// Determines whether two lists have identitical content
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="l1">The first list</param>
    /// <param name="l2">The second list</param>
    /// <returns></returns>
    public static bool ContentEqualTo<X>(this IReadOnlyList<X> l1, IReadOnlyList<X> l2)
    {
        if (l1.Count != l2.Count)
            return false;

        for (var i = 0; i < l2.Count; i++)
        {
            var left = l1[i];
            var right = l2[i];
            var same = Equals(left, right);
            if (!same)
                return false;
        }
        return true;

    }

    /// <summary>
    /// Retrieves a range of elements of a specified length, starting with a specified index, if possible
    /// Otherwise; returns either an empty list or a maximal subset
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source items</param>
    /// <param name="startidx">The first index</param>
    /// <param name="length">The maximum number of elements to yield</param>
    /// <returns></returns>
    public static IEnumerable<T> GetRange<T>(this IReadOnlyList<T> source, int startidx, int length)
    {
        var current = 0;        
        for (var i = startidx; i < source.Count && current < length; i++)
        {
            yield return source[i];
            current++;
        }
    }
}
