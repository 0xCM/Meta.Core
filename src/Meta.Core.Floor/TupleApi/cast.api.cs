//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using System.Runtime.CompilerServices;

using Meta.Core;

public static partial class metacore
{
    /// <summary>
    /// Casts a 3-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2) cast<X1, X2>((object x1, object x2) x)
        => map(x, cast<X1>, cast<X2>);

    /// <summary>
    /// Casts a 3-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3) cast<X1, X2, X3>((object x1, object x2, object x3) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>);

    /// <summary>
    /// Casts a 4-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4) cast<X1, X2, X3, X4>((object x1, object x2, object x3, object x4) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>, cast<X4>);

    /// <summary>
    /// Casts a 5-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fifth coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) cast<X1, X2, X3, X4, X5>((object x1, object x2, object x3, object x4, object x5) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>, cast<X4>, cast<X5>);

    /// <summary>
    /// Casts a 6-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The target type of the sixth coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) cast<X1, X2, X3, X4, X5, X6>((object x1, object x2, object x3, object x4, object x5, object x6) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>, cast<X4>, cast<X5>, cast<X6>);

    /// <summary>
    /// Casts a 7-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The target type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The target type of the seventh coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) cast<X1, X2, X3, X4, X5, X6, X7>((object x1, object x2, object x3, object x4, object x5, object x6, object x7) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>, cast<X4>, cast<X5>, cast<X6>, cast<X7>);

    /// <summary>
    /// Casts an 8-tuple
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The target type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The target type of the seventh coordinate</typeparam>
    /// <param name="x">The source tuple</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7, X8 x8) cast<X1, X2, X3, X4, X5, X6, X7, X8>((object x1, object x2, object x3, object x4, object x5, object x6, object x7, object x8) x)
        => map(x, cast<X1>, cast<X2>, cast<X3>, cast<X4>, cast<X5>, cast<X6>, cast<X7>, cast<X8>);
}