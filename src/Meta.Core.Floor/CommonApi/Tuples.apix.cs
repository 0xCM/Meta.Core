//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

using static metacore;

using Meta.Core;
using Meta.Core.Modules;


/// <summary>
/// Defines tuple utility extensions
/// </summary>
public static class TupleExtensions
{    
    /// <summary>
    /// Emits the canonical 2-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2>(this (X1 x1, X2 x2) x)
        => $"({x.x1},{x.x2})";

    /// <summary>
    /// Emits the canonical 3-tuple display format
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <param name="x">The tuple to format</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3>(this (X1 x1, X2 x2, X3 x3) x)
        => $"({x.x1},{x.x2},{x.x3})";

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
    public static string Format<X1, X2, X3, X4>(this (X1 x1, X2 x2, X3 x3, X4 x4) x)
        => $"({x.x1},{x.x2},{x.x3},{x.x4})";

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
    public static string Format<X1, X2, X3, X4, X5>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
        => $"({x.x1},{x.x2},{x.x3},{x.x4},{x.x5})";

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
    public static string Format<X1, X2, X3, X4, X5, X6>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
        => $"({x.x1},{x.x2},{x.x3},{x.x4},{x.x5},{x.x6})";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format<X1, X2, X3, X4, X5, X6, X7>(this (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) x)
        => $"({x.x1},{x.x2},{x.x3},{x.x4},{x.x5},{x.x6},{x.x7})";

    /// <summary>
    /// Transforms an homogenous 2-tuple into a 2-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="point">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2) point)
        => list(point.x1, point.x2);

    /// <summary>
    /// Transforms an homogenous 3-tuple into a 3-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="point">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3) point)
        => list(point.x1, point.x2, point.x3);

    /// <summary>
    /// Transforms an homogenous 4-tuple into a 4-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="point">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4) point)
        => list(point.x1, point.x2, point.x3, point.x4);

    /// <summary>
    /// Transforms an homogenous 5-tuple into a 5-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="point">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8, X x9) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8, point.x9);

    /// <summary>
    /// Transforms a dictionary into sequence of (key,value) tuples
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="d"></param>
    /// <returns></returns>
    public static Seq<(K key, V value)> Tupelize<K, V>(this IDictionary d)
        => Seq.make(from k in d.Keys.Cast<K>() let v = (V)d[k] select (k, v));

    public static Map<X, (Y, Z)> ToDictionary<X, Y, Z>(this Seq<(X, Y, Z)> items)
        => Meta.Core.Modules.Map.make(
            from point in items
            select (point.Item1, (point.Item2, point.Item3))
            );

    public static Map<X1, (X2, X3, X4)> ToMap<X1, X2, X3, X4>(this Seq<(X1, X2, X3, X4)> items)
        => Meta.Core.Modules.Map.make(from point in items
                                select (point.Item1, (point.Item2, point.Item3, point.Item4)));


    /// <summary>
    /// Converts an homogeneous tuple of one type to another
    /// </summary>
    /// <typeparam name="TSrc">The source item type</typeparam>
    /// <typeparam name="TDst">The target item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (TDst y1, TDst y2) Convert<TDst, TSrc>(this (TSrc x1, TSrc x2) source)
        => (convert<TDst>(source.x1), convert<TDst>(source.x2));

    /// <summary>
    /// Converts an homogeneous tuple of one type to another
    /// </summary>
    /// <typeparam name="TSrc">The source item type</typeparam>
    /// <typeparam name="TDst">The target item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (TDst y1, TDst y2, TDst y3) Convert<TDst, TSrc>(this (TSrc x1, TSrc x2, TSrc x3) source)
        => (convert<TDst>(source.x1), convert<TDst>(source.x2), convert<TDst>(source.x3));

    /// <summary>
    /// Maps two functions over respective coordinate tuples
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="Y1"></typeparam>
    /// <typeparam name="Y2"></typeparam>
    /// <param name="x"></param>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
    public static (Y1 y1, Y2 y2) Map<X1, X2, Y1, Y2>(this (X1 x1, X2 x2) x, Func<X1, Y1> f1, Func<X2, Y2> f2)
        => (f1(x.x1), f2(x.x2));
}