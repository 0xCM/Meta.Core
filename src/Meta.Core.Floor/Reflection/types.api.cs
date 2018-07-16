//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class metacore
{
    /// <summary>
    /// Gets the type adapter for <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType type<T>()
        => ClrType.Get<T>();

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2>()
        => array(ClrType.Get<X1>(), ClrType.Get<X2>());

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3>()
        => array(ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>());

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4>()
        => array(ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>());

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5>()
        => array(ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>());

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <typeparam name="X8">The eigth type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7, X8>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>(), ClrType.Get<X8>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <typeparam name="X8">The eigth type</typeparam>
    /// <typeparam name="X9">The ninth type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7, X8, X9>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>(), ClrType.Get<X8>(), ClrType.Get<X9>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <typeparam name="X8">The eigth type</typeparam>
    /// <typeparam name="X9">The ninth type</typeparam>
    /// <typeparam name="X10">The 10th type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7, X8, X9, X10>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>(), ClrType.Get<X8>(), ClrType.Get<X9>(),
            ClrType.Get<X10>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <typeparam name="X8">The eigth type</typeparam>
    /// <typeparam name="X9">The ninth type</typeparam>
    /// <typeparam name="X10">The 10th type</typeparam>
    /// <typeparam name="X11">The 11th type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>(), ClrType.Get<X8>(), ClrType.Get<X9>(),
            ClrType.Get<X10>(), ClrType.Get<X11>()
            );

    /// <summary>
    /// Gets an array of type adapters
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <typeparam name="X3">The third type</typeparam>
    /// <typeparam name="X4">The fourth type</typeparam>
    /// <typeparam name="X5">The fifth type</typeparam>
    /// <typeparam name="X6">The sixth type</typeparam>
    /// <typeparam name="X7">The seventh type</typeparam>
    /// <typeparam name="X8">The eigth type</typeparam>
    /// <typeparam name="X9">The ninth type</typeparam>
    /// <typeparam name="X10">The 10th type</typeparam>
    /// <typeparam name="X11">The 11th type</typeparam>
    /// <typeparam name="X12">The 12th type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClrType[] types<X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12>()
        => array(
            ClrType.Get<X1>(), ClrType.Get<X2>(), ClrType.Get<X3>(),
            ClrType.Get<X4>(), ClrType.Get<X5>(), ClrType.Get<X6>(),
            ClrType.Get<X7>(), ClrType.Get<X8>(), ClrType.Get<X9>(),
            ClrType.Get<X10>(), ClrType.Get<X11>(), ClrType.Get<X12>()
            );

    /// <summary>
    /// Determines whether two specified types are the same
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool same<X1, X2>()
        => typeof(X1) == typeof(X2);
}
