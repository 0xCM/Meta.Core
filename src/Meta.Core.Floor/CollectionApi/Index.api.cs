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
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Constructs an index from a sequence
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="s">The sequence from which to construct the index</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<T> index<T>(Seq<T> s)
        => Index.make(s);

    /// <summary>
    /// Constructs an index from a stream
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the index</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<T> index<T>(IEnumerable<T> items)
        => Seq.make(items);

    /// <summary>
    /// Creates an array from the supplied items
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<T> index<T>(params T[] items)
        => Index.cons(items);



}