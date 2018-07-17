//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;

partial class etude
{
    /// <summary>
    /// Constructs a <see cref="byte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte uint8(byte value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="byte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<byte> uint8G(byte value)
        => value;

    /// <summary>
    /// Constructs a <see cref="sbyte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte int8(sbyte value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="sbyte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<sbyte> int8G(sbyte value)
        => value;


    /// <summary>
    /// Constructs a <see cref="ushort"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort uint16(ushort value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="ushort"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<ushort> uint16G(ushort value)
        => value;

    /// <summary>
    /// Constructs a <see cref="short"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short int16(short value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="short"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<short> int16G(short value)
        => value;

    /// <summary>
    /// Constructs a <see cref="int"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int int32(int value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="int"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<int> int32G(int value)
        => value;

    /// <summary>
    /// Constructs a <see cref="uint"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint uint32(uint value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="uint"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<uint> uint32G(uint value)
        => value;

    /// <summary>
    /// Constructs a <see cref="long"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long int64(long value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="long"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<long> int64G(long value)
        => value;

    /// <summary>
    /// Constructs a <see cref="Number{UInt64}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong uint64(ulong value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="ulong"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<ulong> uint64G(ulong value)
        => value;

    /// <summary>
    /// Constructs a <see cref="decimal"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal @decimal(decimal value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="decimal"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<decimal> decimalG(decimal value)
        => value;

    /// <summary>
    /// Constructs a <see cref="float"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float float32(float value)
        => value;

    /// <summary>
    /// Constructs a genric <see cref="float"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<float> float32G(float value)
        => value;

    /// <summary>
    /// Constructs a <see cref="double"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double float64(double value)
        => value;

    /// <summary>
    /// Constructs a generic <see cref="double"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<double> float64G(double value)
        => value;

   
    /// <summary>
    /// Constructs a generic number based a specified type
    /// </summary>
    /// <typeparam name="X">The underlying type</typeparam>
    /// <param name="x">The underlying value</param>
    /// <returns></returns>
    public static Number<X> number<X>(X x)
        where X : struct
            => new Number<X>(x);


    
}
