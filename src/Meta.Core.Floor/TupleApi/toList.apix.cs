//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Runtime.CompilerServices;

using Meta.Core;

using static metacore;

/// <summary>
/// Defines tuple utility extensions
/// </summary>
public static partial class TupleExtensions
{
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
    /// <param name="x">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5) x)
        => list(x.x1, x.x2, x.x3, x.x4, x.x5);

    /// <summary>
    /// Transforms an homogenous 6-tuple into a 6-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="x">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6) x)
        => list(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);

    /// <summary>
    /// Transforms an homogenous 7-tuple into a 7-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="x">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7) x)
        => list(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);

    /// <summary>
    /// Transforms an homogenous 8-tuple into a 8-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="x">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8);

    /// <summary>
    /// Transforms an homogenous 9-tuple into a 9-element list
    /// </summary>
    /// <typeparam name="X">The tuple coordinate type</typeparam>
    /// <param name="x">The value to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lst<X> ToList<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8, X x9) point)
        => list(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8, point.x9);
}