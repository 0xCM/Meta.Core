//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Creates an array from the supplied items
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(IEnumerable<T> items)
        => items?.ToArray() ?? new T[] { };

    /// <summary>
    /// Creates an array from the supplied items
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(params T[] items)
        => items?.ToArray() ?? new T[] { };

    /// <summary>
    /// Creates an array by applying a transformation to an input sequence
    /// </summary>
    /// <typeparam name="X">The source item type</typeparam>
    /// <typeparam name="Y">The target item type</typeparam>
    /// <param name="items">The items to be transformed</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static Y[] array<X, Y>(IEnumerable<X> items, Func<X, Y> f)
    {
        var all = items.ToList();
        var dst = new Y[all.Count];
        for (var i = 0; i < all.Count; i++)
            dst[i] = f(all[i]);
        return dst;
    }

    /// <summary>
    /// Creates an empty of a specified length where each element has the 
    /// default default value for that type or a specified default value
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="length">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(int length, T init = default(T))
    {
        var a = new T[length];
        if (!object.Equals(init, default(T)))
            for (var i = 0; i < length; i++)
                a[i] = init;
        return a;
    }

    /// <summary>
    /// Creates an array by combining items in the supplied order
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the start of the array</param>
    /// <param name="more">The items from which to construct the end of the array</param>
    /// <returns></returns>
    public static T[] array<T>(IEnumerable<T> items, params T[] more)
    {
        var list = MutableList.FromItems(items);
        list.AddRange(more);
        return list.ToArray();
    }

    /// <summary>
    /// Creates an array from the supplied items
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(T item, T[] items)
    {
        var list = MutableList.Create<T>();
        list.Add(item);
        list.AddRange(items);
        return list.ToArray();
    }

    /// <summary>
    /// Creates an array by concatenating supplied sequences
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(IEnumerable<T> x, IEnumerable<T> y)
        => array(x.Concat(y));

    /// <summary>
    /// Applies the supplied function to each element in the input sequence to produce an array
    /// </summary>
    /// <typeparam name="T">The input sequence item type</typeparam>
    /// <typeparam name="S">The output sequence item type</typeparam>
    /// <param name="seq">The sequence to transform</param>
    /// <param name="f">The transformation function</param>
    /// <returns></returns>
    public static S[] arrayi<T, S>(IEnumerable<T> seq, Func<int, T, S> f)
        => mapi(seq, f).ToArray();


    /// <summary>
    /// Returns true if array is empty, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static bool empty<X>(X[] a)
        => a.Length == 0;

    /// <summary>
    /// Retrieves the last element if it exists; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static Option<X> last<X>(X[] a)
        => a.LastOrDefault();

    /// <summary>
    /// Retrieves the first element; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static Option<X> first<X>(X[] a)
        => a.FirstOrDefault();

    /// <summary>
    /// Retrieves the length of the array
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="a">The array to examine</param>
    /// <returns></returns>
    public static int len<X>(X[] a)
        => a.Length;


}