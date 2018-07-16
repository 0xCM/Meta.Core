//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

using Meta.Core;
using Meta.Core.Modules;

public static class SeqX
{
    /// <summary>
    /// Lifts a filter to the Option monad
    /// </summary>
    /// <typeparam name="X">The optional item value type</typeparam>
    /// <param name="seq">The potential sequence</param>
    /// <param name="predicate">The filter to apply to any elements that exist</param>
    /// <returns></returns>
    public static Option<Seq<X>> Where<X>(this Option<Seq<X>> seq, Func<X, bool> predicate)
        => seq.Map(x => x.Where(predicate));


    /// <summary>
    /// Applies a map to any items that exist in an optional Lst
    /// </summary>
    /// <typeparam name="TSrc">The source item type</typeparam>
    /// <typeparam name="TDst">The target item type</typeparam>
    /// <param name="src">The potential list</param>
    /// <param name="f">The map to apply</param>
    /// <returns></returns>
    public static Option<Seq<TDst>> Map<TSrc, TDst>(this Option<Seq<TSrc>> src, Func<TSrc, TDst> f)
        => from items in src select Seq.map(f, items);

    /// <summary>
    /// Evaluates to true if the option has a value and and the encapsulated list is nonempty
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public static bool Any<P>(this Option<Seq<P>> src)
        => src.Map(x => x.Any()).ValueOrDefault();

    /// <summary>
    /// Evaluates to true if the option has a value and and any element in the list satisfies the predicate
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public static bool Any<P>(this Option<Seq<P>> src, Func<P, bool> predicate)
        => src.Map(x => x.Any(predicate)).ValueOrDefault();


    /// <summary>
    /// Extracts valued options from the list and discards the remainder
    /// </summary>
    /// <typeparam name="T">The potential item type</typeparam>
    /// <param name="options">The options to evaluate</param>
    /// <returns></returns>
    public static Seq<T> Items<T>(this Seq<Option<T>> options)
        => from item in options
           where item.Exists
           select item.ValueOrDefault();

    /// <summary>
    /// Extracts the encapsulated Seq if it exists; otherwise, returns the empty Seq
    /// </summary>
    /// <typeparam name="T">The potential item type</typeparam>
    /// <param name="options">The options to evaluate</param>
    /// <returns></returns>
    public static Seq<T> Items<T>(this Option<Seq<T>> oseq)
        => oseq.ValueOrDefault(Seq<T>.Empty);

    /// <summary>
    /// Standard LINQ Take operator for a list
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="source">The source list</param>
    /// <param name="count">The number of items to take</param>
    /// <returns></returns>
    public static Seq<T> Take<T>(this Seq<T> s, int count)
        => Seq.make(s.Stream().Take(count));

    /// <summary>
    /// Standard LINQ Skip operator for a sequence
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="source">The source sequence</param>
    /// <param name="count">The number of items to skip</param>
    /// <returns></returns>
    public static Seq<T> Skip<T>(this Seq<T> source, int count)
        => Seq.make(source.Stream().Skip(count));

}