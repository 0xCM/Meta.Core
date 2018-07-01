//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;



public static class OptionFilter
{
    /// <summary>
    /// Selects subsequence for which an encapsulated value exists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IEnumerable<Option<T>> WhereSome<T>(this IEnumerable<Option<T>> options)
        => from option in options where option.IsSome() select option;

    /// <summary>
    /// Filters encapsulated list according to the suppiled predicate
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static Option<ReadOnlyList<X>> Where<X>(this Option<ReadOnlyList<X>> x, Func<X, bool> predicate)
    {
        var items = MutableList.Create<X>();
        if (x)
        {
            foreach (var item in x.ValueOrDefault())
                if (predicate(item))
                    items.Add(item);

            return ReadOnlyList.Create(items);
        }
        else
            return x;
    }

    public static Option<IEnumerable<X>> Where<X>(this Option<IEnumerable<X>> x,
        Func<X, bool> predicate)
        => x ? Option.Some(from item in x.Items() where predicate(item) select item) : x;

    /// <summary>
    /// Selects subsequence for which no encapsulated value exists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IEnumerable<Option<T>> WhereNone<T>(this IEnumerable<Option<T>> options)
        => from option in options where option.IsNone() select option;

    public static Option<IReadOnlyList<X>> Where<X>(this Option<IReadOnlyList<X>> x, Func<X, bool> predicate)
    {
        var items = MutableList.Create<X>();
        if (x)
        {
            foreach (var item in x.ValueOrDefault())
                if (predicate(item))
                    items.Add(item);
            return items;
        }
        else
            return x;
    }


    /// <summary>
    /// Filters encapsulated list according to the suppiled predicate
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<X> Filter<X>(this Option<IEnumerable<X>> x, Func<X, bool> predicate)
    {
        foreach (var item in x.Items())
            if (predicate(item))
                yield return item;
    }

    public static Option<T> TryGetFirst<T>(params Option<T>[] possibilities)
    {
        foreach (var possibility in possibilities)
            if (possibility.IsSome())
                return possibility;
        return Option.None<T>();
    }

}