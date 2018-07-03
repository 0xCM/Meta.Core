//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Creates a conversion suite from a type that defines a set of conforming methods
    /// </summary>
    /// <typeparam name="T">The defining type</typeparam>
    /// <returns></returns>
    public static IConversionSuite conversions<T>()
        => ConversionSuite.FromType<T>();


    /// <summary>
    /// Creates a conversion suite from an array of static methods
    /// </summary>
    /// <param name="methods">The conversion methods</param>
    /// <returns></returns>
    public static IConversionSuite conversions(params MethodInfo[] methods)
        => ConversionSuite.FromMethods(methods);

    /// <summary>
    /// Casts the object to the specified type
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="value">The source value</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T cast<T>(object value)
        => (T)value;

    /// <summary>
    /// Converts an input value to a value of a specified type via the 
    /// framwor'k <see cref="IConvertible"/> mechanism
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="value">The source Value</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T convert<T>(object value)
        => cast<T>(Convert.ChangeType(value, typeof(T)));


    /// <summary>
    /// Converts items of an input sequence to an output sequence of the specified type
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static IEnumerable<T> convert<T>(IEnumerable items)
    {
        foreach (object item in items)
            yield return convert<T>(item);
    }

    /// <summary>
    /// Casts the sequence items to the specified type
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The sequence of items to cast</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static IEnumerable<T> cast<T>(IEnumerable items)
        => items.Cast<T>();

    /// <summary>
    /// Casts a value if possible, otherwise returns failure
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="item">The object to cast</param>
    /// <returns></returns>
    public static Option<T> tryCast<T>(object item)
        => item is T ? some((T)item) : none<T>();

    /// <summary>
    /// Casts the object to the specified type; needed when overload resolution
    /// is not sufficient to select between <see cref="cast{T}(IEnumerable)"/> 
    /// and <see cref="cast{T}(object)"/>
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="o">The source object</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T castItem<T>(object o)
        => (T)o;


}