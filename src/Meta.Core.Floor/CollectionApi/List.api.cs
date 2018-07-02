﻿//-------------------------------------------------------------------------------------------
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
    /// Constructs a <see cref="List{X}"/> from an array of values
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="items">The items to include in the list</param>
    /// <returns></returns>
    public static List<X> list<X>(params X[] items)
        => items;

    /// <summary>
    /// Constructs a <see cref="List{X}"/> by concatenating a stream and optional array
    /// </summary>
    /// <typeparam name="X">The list item type</typeparam>
    /// <param name="items">The items to include in the list</param>
    /// <param name="more">Additional items to append</param>
    /// <returns></returns>
    public static List<X> list<X>(G.IEnumerable<X> items, params X[] more)
        => List.make(items.Concat(more));

    /// <summary>
    /// Applies a function to each element of a list and returns a
    /// new list containing the results
    /// </summary>
    /// <typeparam name="X">The input list item type</typeparam>
    /// <typeparam name="Y">The output list item type</typeparam>
    /// <param name="f">The function to apply</param>
    /// <param name="list">The input list</param>
    /// <returns></returns>
    public static List<Y> map<X, Y>(Func<X, Y> f, List<X> list)
        => list.Select(f);

    /// <summary>
    /// Defines a monadic transformation List[Option[X]] -> Option[List[X]]
    /// that returns the value of the list if all items are valued; otherwise,
    /// returns None
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="list">The list of options to transform</param>
    /// <returns></returns>
    public static Option<List<X>> flip<X>(List<Option<X>> list)
        => list.Any(item => item.IsNone()) 
        ? default  : list.Select(x => x.ValueOrDefault());

    /// <summary>
    /// Returns true if list is empty, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static bool empty<X>(List<X> list)
        => list.IsEmpty;

    /// <summary>
    /// Retrieves the last element if it exists; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static Option<X> last<X>(List<X> list)
        => list.Stream().LastOrDefault();

    /// <summary>
    /// Retrieves the first element; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="list">The list to examine</param>
    /// <returns></returns>
    public static Option<X> first<X>(List<X> list)
        => list.Stream().FirstOrDefault();

    /// <summary>
    /// Retrieves the length of the array
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static int len<X>(List<X> list)
        => list.Count;

}