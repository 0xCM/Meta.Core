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
    /// Maps a function over a 2-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X">The projected type</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The function to apply</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X map<X1, X2, X>((X1 x1, X2 x2) x, Func<X1, X2, X> f)
        => f(x.x1, x.x2);

    /// <summary>
    /// Maps two functions over respective over respective 2-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2) map<X1, X2, Y1, Y2>((X1 x1, X2 x2) x, Func<X1, Y1> f1, Func<X2, Y2> f2)
        => (f1(x.x1), f2(x.x2));

    /// <summary>
    /// Maps a function over a 3-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X">The projected type</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The function to apply</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X map<X1, X2, X3, X>((X1 x1, X2 x2, X3 x3) x, Func<X1, X2, X3, X> f)
        => f(x.x1, x.x2, x.x3);

    /// <summary>
    /// Maps three functions over respective over respective 3-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the second coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3) map<X1, X2, X3, Y1, Y2, Y3>((X1 x1, X2 x2, X3 x3) x, Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => (f1(x.x1), f2(x.x2), f3(x.x3));

    /// <summary>
    /// Maps four functions over respective over respective 4-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the second coordinate</typeparam>
    /// <typeparam name="X4">The type of the second coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <typeparam name="Y4">The return type of the third function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <param name="f4">The function applied to the fourth coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3, Y4 y4) map<X1, X2, X3, X4, Y1, Y2, Y3, Y4>((X1 x1, X2 x2, X3 x3, X4 x4) x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4)
            => (f1(x.x1), f2(x.x2), f3(x.x3), f4(x.x4));

    /// <summary>
    /// Maps five functions over respective over respective 5-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <typeparam name="Y4">The return type of the fourth function</typeparam>
    /// <typeparam name="Y5">The return type of the fifth function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <param name="f4">The function applied to the fourth coordinate</param>
    /// <param name="f5">The function applied to the fifth coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3, Y4 y4, Y5 y5) map<X1, X2, X3, X4, X5, Y1, Y2, Y3, Y4, Y5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4, Func<X5, Y5> f5)
            => (f1(x.x1), f2(x.x2), f3(x.x3), f4(x.x4), f5(x.x5));

    /// <summary>
    /// Maps six functions over respective over respective 6-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <typeparam name="Y4">The return type of the fourth function</typeparam>
    /// <typeparam name="Y5">The return type of the fifth function</typeparam>
    /// <typeparam name="Y6">The return type of the sixth function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <param name="f4">The function applied to the fourth coordinate</param>
    /// <param name="f5">The function applied to the fifth coordinate</param>
    /// <param name="f6">The function applied to the sixth coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3, Y4 y4, Y5 y5, Y6 y6) map<X1, X2, X3, X4, X5, X6, Y1, Y2, Y3, Y4, Y5, Y6>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4, Func<X5, Y5> f5, Func<X6, Y6> f6)
            => (f1(x.x1), f2(x.x2), f3(x.x3), f4(x.x4), f5(x.x5), f6(x.x6));

    /// <summary>
    /// Maps seven functions over respective over respective 7-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The type of the seventh coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <typeparam name="Y4">The return type of the fourth function</typeparam>
    /// <typeparam name="Y5">The return type of the fifth function</typeparam>
    /// <typeparam name="Y6">The return type of the sixth function</typeparam>
    /// <typeparam name="Y7">The return type of the seventh function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <param name="f4">The function applied to the fourth coordinate</param>
    /// <param name="f5">The function applied to the fifth coordinate</param>
    /// <param name="f6">The function applied to the sixth coordinate</param>
    /// <param name="f7">The function applied to the seventh coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3, Y4 y4, Y5 y5, Y6 y6, Y7 y7) map<X1, X2, X3, X4, X5, X6, X7, Y1, Y2, Y3, Y4, Y5, Y6, Y7>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7) x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4, Func<X5, Y5> f5, Func<X6, Y6> f6, Func<X7, Y7> f7)
            => (f1(x.x1), f2(x.x2), f3(x.x3), f4(x.x4), f5(x.x5), f6(x.x6), f7(x.x7));

    /// <summary>
    /// Maps seven functions over respective over respective 7-tuple coordinate values
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
    /// <typeparam name="X6">The type of the sixth coordinate</typeparam>
    /// <typeparam name="X7">The type of the seventh coordinate</typeparam>
    /// <typeparam name="X8">The type of the eighth coordinate</typeparam>
    /// <typeparam name="Y1">The return type of the first function</typeparam>
    /// <typeparam name="Y2">The return type of the second function</typeparam>
    /// <typeparam name="Y3">The return type of the third function</typeparam>
    /// <typeparam name="Y4">The return type of the fourth function</typeparam>
    /// <typeparam name="Y5">The return type of the fifth function</typeparam>
    /// <typeparam name="Y6">The return type of the sixth function</typeparam>
    /// <typeparam name="Y7">The return type of the seventh function</typeparam>
    /// <typeparam name="Y8">The return type of the eighth function</typeparam>
    /// <param name="x">The input tuple</param>
    /// <param name="f1">The function applied to the first coordinate</param>
    /// <param name="f2">The function applied to the second coordinate</param>
    /// <param name="f3">The function applied to the third coordinate</param>
    /// <param name="f4">The function applied to the fourth coordinate</param>
    /// <param name="f5">The function applied to the fifth coordinate</param>
    /// <param name="f6">The function applied to the sixth coordinate</param>
    /// <param name="f7">The function applied to the seventh coordinate</param>
    /// <param name="f8">The function applied to the eighth coordinate</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (Y1 y1, Y2 y2, Y3 y3, Y4 y4, Y5 y5, Y6 y6, Y7 y7, Y8 y8) map<X1, X2, X3, X4, X5, X6, X7, X8, Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7, X8 x8) x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4, Func<X5, Y5> f5, Func<X6, Y6> f6, Func<X7, Y7> f7, Func<X8,Y8> f8)
            => (f1(x.x1), f2(x.x2), f3(x.x3), f4(x.x4), f5(x.x5), f6(x.x6), f7(x.x7), f8(x.x8));

}