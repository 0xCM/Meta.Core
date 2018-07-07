//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using System.Diagnostics;
using System.Runtime.CompilerServices;

/// <summary>
/// Defines a slot in the type system for an "empty" type
/// In this way, void functions can be considered
/// to yield a value and participate in functional/monadic expressions
/// </summary>
public readonly struct Unit
{
    public static readonly Unit Value = new Unit();
    public static readonly Type Type = typeof(Unit);
    
    /// <summary>
    /// Executes the action and returns the unit value
    /// </summary>
    /// <param name="a">The action to execute</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Unit(Action a)
    {
        a();
        return Value;
    }
    
}
