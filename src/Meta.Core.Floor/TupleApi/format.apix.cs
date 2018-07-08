//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Modules;

using static tuple;

/// <summary>
/// Defines tuple utility extensions
/// </summary>
public static partial class TupleExtensions
{
    static string coord<T>(T val)
        => val == null ? "null" : val.ToString();

    /// <summary>
    /// Emits the canonical 2-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2>(this (X1 x1, X2 x2) x,
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2)));

    /// <summary>
    /// Emits the canonical 3-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3>(this (X1 x1, X2 x2, X3 x3) x,
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2), coord(x.x3)));

    /// <summary>
    /// Emits the canonical 4-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4>(this (X1 x1, X2 x2, X3 x3, X4 x4) x,
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2), coord(x.x3), coord(x.x4)));

    /// <summary>
    /// Emits the canonical 5-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4, X5>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x, 
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2), coord(x.x3), coord(x.x4), coord(x.x5)));

    /// <summary>
    /// Emits the canonical 6-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4, X5, X6>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x, 
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2), coord(x.x3), coord(x.x4), coord(x.x5), coord(x.x6)));

    /// <summary>
    /// Emits the canonical 7-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The type of the seventh coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4, X5, X6, X7>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) x, 
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", coord(x.x1), coord(x.x2), coord(x.x3), coord(x.x4), coord(x.x5), coord(x.x6), coord(x.x7)));

    /// <summary>
    /// Emits the canonical 8-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The type of the seventh coordinate</typeparam>
    /// <typeparam name="X8">The type of the eighth coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4, X5, X6, X7, X8>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7, X8 x8) x,
        TupleFormatStyle style = TupleFormatStyle.Coordinate)
            => boundaryFn(style)(string.Join(", ", 
                coord(x.x1), coord(x.x2), coord(x.x3), coord(x.x4), coord(x.x5), coord(x.x6), coord(x.x7), coord(x.x8)));

    /// <summary>
    /// Transforms a dictionary into sequence of (key,value) tuples
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="d"></param>
    /// <returns></returns>
    public static Seq<(K key, V value)> Tupelize<K, V>(this IDictionary d)
        => Seq.make(from k in d.Keys.Cast<K>() let v = (V)d[k] select (k, v));

    public static Map<X, (Y, Z)> ToMap<X, Y, Z>(this Seq<(X, Y, Z)> items)
        => Meta.Core.Modules.Map.make(
            from point in items
            select (point.Item1, (point.Item2, point.Item3))
            );

    public static Map<X1, (X2, X3, X4)> ToMap<X1, X2, X3, X4>(this Seq<(X1, X2, X3, X4)> items)
        => Meta.Core.Modules.Map.make(from point in items
                                select (point.Item1, (point.Item2, point.Item3, point.Item4)));
}