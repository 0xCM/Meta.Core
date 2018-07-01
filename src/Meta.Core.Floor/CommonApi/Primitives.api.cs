//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class metacore
{
    /// <summary>
    /// Converts any instance to an object
    /// </summary>
    /// <param name="o">The object to convert</param>
    /// <returns></returns>
    /// <remarks>
    /// This may initially appear useless; however it is used a shortcut whenever 
    /// the actual <see cref="object"/> type is required, e.g., when constructing a list 
    /// of objects from heterogeneous instances. Otherwise, you would have to write
    /// (object)x which is not as nice as box(x)
    /// </remarks>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object box(object o) 
        => o;

    /// <summary>
    /// Creates a new <see cref="Guid"/> value
    /// </summary>
    /// <returns></returns>
    public static Guid guid()
        => Guid.NewGuid();

    /// <summary>
    /// Returns the first item from a sequence that is not null
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The sequence to examine</param>
    /// <returns></returns>
    public static T coalesce<T>(params T[] items) where T : class
    {
        foreach (var item in items)
        {
            if (item != null)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// Creates a deferred (lazy) value
    /// </summary>
    /// <param name="factory">A function that creates an instance of the lazy object</param>
    /// <returns></returns>
    public static Lazy<T> defer<T>(Func<T> factory)
        => new Lazy<T>(factory);

    /// <summary>
    /// Evaluates a deferred computation
    /// </summary>
    /// <typeparam name="T">The result type</typeparam>
    /// <param name="deferred">The deferred computation</param>
    /// <returns></returns>
    public static T force<T>(Lazy<T> deferred)
        => deferred.Value;

    /// <summary>
    /// Consumes any value and returns the unit value
    /// </summary>
    /// <typeparam name="T">The type of value to consume</typeparam>
    /// <param name="value">The value to consume</param>
    /// <returns></returns>
    public static Unit unit<T>(T value)
        => Unit.Value;

    /// <summary>
    /// Returns the name of the caller
    /// </summary>
    /// <param name="name">The name of the caller to return</param>
    /// <returns></returns>
    public static string caller([CallerMemberName] string name = null)
        => name;

}