//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;

partial class metacore
{
    /// <summary>
    /// Evaluates to true if all input values are true and false otherwise
    /// </summary>
    /// <param name="values">The input values</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool all(params bool[] values)
        => values.All(x => x);

    /// <summary>
    /// Evaluates to true if any of the supplied values are true
    /// </summary>
    /// <param name="values">The values over which evaluation will occur</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool any(params bool[] values)
        => values.Any();

    /// <summary>
    /// Evaluates to false if input is true and false otherwise
    /// </summary>
    /// <param name="value">The value of the input</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool not(bool value)
        => !value;

    /// <summary>
    /// Determines whether a supplied object is null
    /// </summary>
    /// <param name="o">The object to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool isNull(object o)
        => o == null;

    /// <summary>
    /// Determines whether a supplied object is not null
    /// </summary>
    /// <param name="o">The object to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool isNotNull(object o)
        => o != null;

    /// <summary>
    /// Returns some(value) if the value satisfies the predicate; othwerwise, none
    /// </summary>
    /// <typeparam name="X">The type of value to evaluate</typeparam>
    /// <param name="x">The value to evaluate</param>
    /// <param name="criterion">The predicate used in the evauluation</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<X> check<X>(X x, Func<X, bool> criterion)
        => criterion(x) ? some(x) : none<X>(PredicateUnsatisfied());


}