//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
    using System;
    using System.Linq;

    using static minicore;

    using System.Collections;
    using G = System.Collections.Generic;

    using Meta.Core;
    using Meta.Core.Modules;



public static class LstX
{
    /// <summary>
    /// Lifts a filter to the Option monad
    /// </summary>
    /// <typeparam name="X">The optional item value type</typeparam>
    /// <param name="list">The potential list</param>
    /// <param name="predicate">The filter to apply to any elements that exist</param>
    /// <returns></returns>
    public static Option<Lst<X>> Where<X>(this Option<Lst<X>> list, Func<X, bool> predicate)
        => list.Map(x => x.Where(predicate));

    /// <summary>
    /// Applies a map to any items that exist in an optional Lst
    /// </summary>
    /// <typeparam name="TSrc">The source item type</typeparam>
    /// <typeparam name="TDst">The target item type</typeparam>
    /// <param name="src">The potential list</param>
    /// <param name="f">The map to apply</param>
    /// <returns></returns>
    public static Option<Lst<TDst>> Map<TSrc, TDst>(this Option<Lst<TSrc>> src, Func<TSrc, TDst> f)
        => from items in src select Lst.map(f, items);

    /// <summary>
    /// Evaluates to true if the option has a value and and the encapsulated list is nonempty
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static bool Any<P>(this Option<Lst<P>> src)
        => src.Map(x => x.Any()).ValueOrDefault();

    /// <summary>
    /// Evaluates to true if the option has a value and and any element in the list satisfies the predicate
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    public static bool Any<P>(this Option<Lst<P>> src, Func<P, bool> predicate)
        => src.Map(x => x.Any(predicate)).ValueOrDefault();

    /// <summary>
    /// Extracts valued options from the list and discards the remainder
    /// </summary>
    /// <typeparam name="T">The potential item type</typeparam>
    /// <param name="options">The options to evaluate</param>
    /// <returns></returns>
    public static Lst<T> Items<T>(this Lst<Option<T>> options)
        => from item in options
           where item.Exists
           select item.ValueOrDefault();

}