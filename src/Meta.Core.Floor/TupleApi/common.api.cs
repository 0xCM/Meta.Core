//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static partial class metacore
{
                   
    /// <summary>
    /// Gets the first element of a 2-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X first<X, Y>((X x, Y y) p) 
        => p.x;

    /// <summary>
    /// Gets the second element of a 2-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y second<X, Y>((X x, Y y) p) 
        => p.y;

    /// <summary>
    /// Gets the third element of a 3-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <typeparam name="Z">The third type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y second<X, Y, Z>((X x, Y y, Z z) p)
        => p.y;

    /// <summary>
    /// Canonical T => TxT expansion that lifts a scalar t to (t,t)
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="t">The value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T one, T two) two<T>(T t) 
        => (t, t);

    /// <summary>
    /// Canonical T => TxTxT expansion that lifts a scalar t to (t,t,t)
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="t">The value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T one, T two, T three) three<T>(T t) 
        => (t, t, t);

    /// <summary>
    /// Constructs an homogenous 2-tuple from the first two items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2) two<X>(IReadOnlyList<X> source)
        => (source[0], source[1]);

    /// <summary>
    /// Constructs an homogenous 3-tuple from the first three items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3) three<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2]);

    /// <summary>
    /// Constructs an homogenous 4-tuple from the first four items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3, X x4) four<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2], source[3]);

    /// <summary>
    /// Constructs an homogenous 5-tuple from the first 5 items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3, X x4, X x5) five<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2], source[3], source[4]);

    /// <summary>
    /// Constructs an homogenous 6-tuple from the first 6 items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3, X x4, X x5, X x6) six<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2], source[3], source[4], source[5]);

    /// <summary>
    /// Constructs an homogenous 7-tuple from the first 7 items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3, X x4, X x5, X x6, X x7) seven<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2], source[3], source[4], source[5], source[6]);

    /// <summary>
    /// Constructs an homogenous 8-tuple from the first 8 items in a list
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X x1, X x2, X x3, X x4, X x5, X x6, X x7, X x8) eight<X>(IReadOnlyList<X> source)
        => (source[0], source[1], source[2], source[3], source[4], source[5], source[6], source[7]);

    /// <summary>
    /// Constructs a heterogeneous 2-tuple from the first two items in a stream
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2) tupleOf<X1, X2>(IEnumerable<object> source)
        => cast<X1, X2>(two(source));

    /// <summary>
    /// Constructs a heterogenous 3-tuple from the first three items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3) tupleOf<X1, X2, X3>(IReadOnlyList<object> source)
        => cast<X1, X2, X3>(three(source));

    /// <summary>
    /// Constructs a heterogenous 4-tuple from the first four items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <typeparam name="X4">The fourth item type</typeparam>
    /// <param name="source">The source list</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4) tupleOf<X1, X2, X3, X4>(IReadOnlyList<object> source)
        => cast<X1, X2, X3, X4>(four(source));

    /// <summary>
    /// Constructs a heterogenous 5-tuple from the first five items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <typeparam name="X4">The fourth item type</typeparam>
    /// <typeparam name="X5">The fifth item type</typeparam>
    /// <param name="source">The source list</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) tupleOf<X1, X2, X3, X4, X5>(IReadOnlyList<object> source)
        => cast<X1, X2, X3, X4, X5>(five(source));

    /// <summary>
    /// Constructs a heterogenous 6-tuple from the first five items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <typeparam name="X4">The fourth item type</typeparam>
    /// <typeparam name="X5">The fifth item type</typeparam>
    /// <typeparam name="X6">The sixth item type</typeparam>
    /// <param name="source">The source list</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) tupleOf<X1, X2, X3, X4, X5, X6>(IReadOnlyList<object> source)
        => cast<X1, X2, X3, X4, X5, X6>(six(source));

    /// <summary>
    /// Constructs a heterogenous 7-tuple from the first 7 items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <typeparam name="X4">The fourth item type</typeparam>
    /// <typeparam name="X5">The fifth item type</typeparam>
    /// <typeparam name="X6">The sixth item type</typeparam>
    /// <typeparam name="X7">The seventh item type</typeparam>
    /// <param name="source">The source list</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) tupleOf<X1, X2, X3, X4, X5, X6, X7>(IReadOnlyList<object> source)
        => cast<X1, X2, X3, X4, X5, X6, X7>(seven(source));

    /// <summary>
    /// Constructs a heterogenous 8-tuple from the first 8 items in a list
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <typeparam name="X4">The fourth item type</typeparam>
    /// <typeparam name="X5">The fifth item type</typeparam>
    /// <typeparam name="X6">The sixth item type</typeparam>
    /// <typeparam name="X7">The seventh item type</typeparam>
    /// <param name="source">The source list</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7, X8 x8) tupleOf<X1, X2, X3, X4, X5, X6, X7, X8>(IReadOnlyList<object> source)
        => cast<X1, X2, X3, X4, X5, X6, X7, X8>(eight(source));

}