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

partial class metacore
{
    /// <summary>
    /// Cuonstructs a <see cref="byte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte uint8(byte value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="sbyte"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte int8(sbyte value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="ushort"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort uint16(ushort value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="short"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short int16(short value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="uint"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint uint32(uint value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="int"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int int32(int value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="Number{UInt64}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong uint64(ulong value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="Number{Int64}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long int64(long value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="Number{Decimal}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Number<decimal> @decimal(decimal value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="Number{Single}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float float32(float value)
        => value;

    /// <summary>
    /// Cuonstructs a <see cref="Number{Double}"/> value
    /// </summary>
    /// <param name="value">The primitive value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double float64(double value)
        => value;


    /// <summary>
    /// Implements the canonical lift operation
    /// </summary>
    /// <typeparam name="X">The type of value to lift</typeparam>
    /// <param name="x">The value to lift</param>
    /// <returns></returns>
    public static Number<X> number<X>(X x)
        where X : struct
            => new Number<X>(x);
}