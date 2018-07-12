//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

using Meta.Core;

public static partial class metacore
{
    /// <summary>
    /// Creates a <see cref="Option{T}"/> with no value
    /// </summary>
    /// <typeparam name="T">The type of the optional value</typeparam>
    /// <returns></returns>
    public static Option<T> none<T>(IAppMessage message = null)
        => Option<T>.None(message ?? AppMessage.Empty);

    /// <summary>
    /// Creates a <see cref="Option{T}"/> with no value based on an exception
    /// </summary>
    /// <typeparam name="T">The type of the optional value</typeparam>
    /// <returns></returns>
    public static Option<T> none<T>(Exception e)
        => Option<T>.None(e);

    /// <summary>
    /// Creates a <see cref="Option{T}"/> with a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Option<T> some<T>(T value, IAppMessage message = null)
        => new Option<T>(value, message);

    /// <summary>
    /// Selects the first realized potential, if any; otherwise returns the default
    /// </summary>
    /// <typeparam name="X">The value type</typeparam>
    /// <param name="potentials">The optional values</param>
    /// <returns></returns>
    public static X first<X>(params Option<X>[] potentials)
        => potentials.First(p => p.IsSome()).ValueOrDefault();    

    /// <summary>
    /// Unwraps the option and may consequently return NULL
    /// </summary>
    /// <typeparam name="T">The enclosed type</typeparam>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T unwrap<T>(Option<T> option)
        => option.ValueOrDefault();

    /// <summary>
    /// Unwraps a nullable value, providing the default value when no value is wrapped
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nullable"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T unwrap<T>(T? nullable) where T : struct
        => nullable.HasValue
        ? nullable.Value
        : default;
}