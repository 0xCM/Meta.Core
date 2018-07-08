//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Modules;

using G = System.Collections.Generic;

partial class metacore
{
    /// <summary>
    /// Constructs a <see cref="Lst{X}"/> from an array of values
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="items">The items to include in the list</param>
    /// <returns></returns>
    public static Lst<X> list<X>(params X[] items)
        => items;

    /// <summary>
    /// Constructs a <see cref="Lst{X}"/> by concatenating a stream and optional array
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="items">The items to include in the list</param>
    /// <param name="more">Additional items to append</param>
    /// <returns></returns>
    public static Lst<X> list<X>(G.IEnumerable<X> items, params X[] more)
        => Lst.make(items.Concat(more));

    /// <summary>
    /// Applies a function to each element of a list and returns a
    /// new list containing the results
    /// </summary>
    /// <typeparam name="X">The input list item type</typeparam>
    /// <typeparam name="Y">The output list item type</typeparam>
    /// <param name="f">The function to apply</param>
    /// <param name="list">The input list</param>
    /// <returns></returns>
    public static Lst<Y> map<X, Y>(Func<X, Y> f, Lst<X> list)
        => Lst.map(f, list);


    /// <summary>
    /// Applies a function to each element of a list and returns a
    /// new list containing the results
    /// </summary>
    /// <typeparam name="X">The input list item type</typeparam>
    /// <typeparam name="Y">The output list item type</typeparam>
    /// <param name="f">The function to apply</param>
    /// <param name="list">The input list</param>
    /// <returns></returns>
    public static Lst<Y> map<X, Y>(Lst<X> list, Func<X, Y> f)
        => Lst.map(f, list);

    /// <summary>
    /// Applies the supplied item-index function to each element in the input list to produce a new list
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="list">The list to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static Lst<S> mapi<T, S>(Lst<T> list, Func<int, T, S> f)
        => Seq.mapi(list, f);

    /// <summary>
    /// Defines a monadic transformation List[Option[X]] -> Option[List[X]]
    /// that returns the value of the list if all items are valued; otherwise,
    /// returns None
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="list">The list of options to transform</param>
    /// <returns></returns>
    public static Option<Lst<X>> flip<X>(Lst<Option<X>> list)
        => list.Any(item => item.IsNone()) 
        ? default  : list.Select(x => x.ValueOrDefault());

    /// <summary>
    /// Returns true if list is empty, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static bool empty<X>(Lst<X> list)
        => list.IsEmpty;

    /// <summary>
    /// Retrieves the last element if it exists; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static Option<X> last<X>(Lst<X> list)
        => list.Stream().LastOrDefault();

    /// <summary>
    /// Retrieves the first element; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static Option<X> first<X>(Lst<X> list)
        => list.Stream().FirstOrDefault();

    /// <summary>
    /// Retrieves the length of the array
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static int len<X>(Lst<X> list)
        => list.Count;

    /// <summary>
    /// Calculates the list of tails entailed (pun intended?) by 
    /// and input list
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="list">The list to process</param>
    /// <returns></returns>
    public static Lst<Lst<X>> tails<X>(Lst<X> list)
        => Lst.tails(list);

    /// <summary>
    /// Collapses a lists of item lists into a list of items
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="ss">The input sequence</param>
    /// <returns></returns>
    public static Seq<X> flatten<X>(Lst<Lst<X>> ss)
        => Lst.flatten(ss);

    public static Lst<X> flatten<X>(Lst<X> ss)
        where X : G.IReadOnlyList<X>
         => Lst.make(from a in ss.Stream()
                     from b in a
                     select b);

}