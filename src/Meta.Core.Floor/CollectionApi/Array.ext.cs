//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using static metacore;

using Meta.Core;

public static class ArrayX
{
    /// <summary>
    /// Transforms an homogenous 2-tuple to a 2-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2) point)
        => array(point.x1, point.x2);

    /// <summary>
    /// Transforms an homogenous 3-tuple to a 3-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3) point)
        => array(point.x1, point.x2, point.x3);

    /// <summary>
    /// Transforms an homogenous 4-tuple to a 4-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4) point)
        => array(point.x1, point.x2, point.x3, point.x4);

    /// <summary>
    /// Transforms an homogenous 5-tuple to a 5-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4, X x5) point)
       => array(point.x1, point.x2, point.x3, point.x4, point.x5);

    /// <summary>
    /// Transforms an homogenous 6-tuple to a 6-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4, X x5, X x6) point)
        => array(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6);

    /// <summary>
    /// Transforms an homogenous 7-tuple to a 7-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7) point)
        => array(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7);

    /// <summary>
    /// Transforms an homogenous 8-tuple to a 8-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8) point)
        => array(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8);

    /// <summary>
    /// Transforms an homogenous 9-tuple to a 9-element array
    /// </summary>
    /// <typeparam name="X">The coordinate type</typeparam>
    /// <param name="point">The tuple to transform</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] ToArray<X>(this (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8, X x9) point)
        => array(point.x1, point.x2, point.x3, point.x4, point.x5, point.x6, point.x7, point.x8, point.x9);

}
