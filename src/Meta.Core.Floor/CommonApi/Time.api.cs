//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class metacore
{
    /// <summary>
    /// Gets the current system time
    /// </summary>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static DateTime now()
        => DateTime.Now;

    /// <summary>
    /// Gets the current system time
    /// </summary>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static Date today()
        => Date.Today;

    /// <summary>
    /// Obtains the maximum of two values
    /// </summary>
    /// <param name="t1">The first value</param>
    /// <param name="t2">The second value</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime max(DateTime t1, DateTime t2)
        => t1 <= t2 ? t2 : t1;

    /// <summary>
    /// Creates and starts a <see cref="Stopwatch"/>
    /// </summary>
    /// <returns></returns>
    public static Stopwatch stopwatch()
        => Stopwatch.StartNew();

    /// <summary>
    /// Gets the number of milliseconds elapsed since the stopwatch was started
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int duration(Stopwatch x)
        => (int)x.ElapsedMilliseconds;

}