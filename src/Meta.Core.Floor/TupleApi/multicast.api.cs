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
    /// Casts a 2-tuple array
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<(X1 x1, X2 x2)> multicast<X1, X2>(params (object x1, object x2)[] tuples)
        => map(tuples, t => cast<X1, X2>(t));

    /// <summary>
    /// Casts a 3-tuple array
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<(X1 x1, X2 x2, X3 x3)> multicast<X1, X2, X3>(params (object x1, object x2, object x3)[] tuples)
        => map(tuples, t => cast<X1, X2, X3>(t));

    /// <summary>
    /// Casts a 4-tuple array
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<(X1 x1, X2 x2, X3 x3, X4 x4)> multicast<X1, X2, X3, X4>(params (object x1, object x2, object x3, object x4)[] tuples)
        => map(tuples, t => cast<X1, X2, X3, X4>(t));

    /// <summary>
    /// Casts an array of 5-tuples
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fift coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)> multicast<X1, X2, X3, X4, X5>(params (object x1, object x2, object x3, object x4, object x5)[] tuples)
        => map(tuples, t => cast<X1,X2,X3,X4,X5>(t));

    /// <summary>
    /// Casts an array of 5-tuples
    /// </summary>
    /// <typeparam name="X1">The target type of the first coordinate</typeparam>
    /// <typeparam name="X2">The target type of the second coordinate</typeparam>
    /// <typeparam name="X3">The target type of the third coordinate</typeparam>
    /// <typeparam name="X4">The target type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The target type of the fift coordinate</typeparam>
    /// <param name="tuples">The tuples to cast</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6)> multicast<X1, X2, X3, X4, X5, X6>(params (object x1, object x2, object x3, object x4, object x5, object x6)[] tuples)
        => map(tuples, t => cast<X1, X2, X3, X4, X5, X6>(t));
}