//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <param name="declaringType">The type to search</param>
    /// <param name="name">The name of the method</param>
    /// <param name="argTypes">The method parameter types in ordinal position</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method(Type declaringType, string name, params Type[] argTypes)
        => declaringType.MatchMethod(name, argTypes).Map(x => ClrMethod.Get(x));


    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <param name="name">The name of the method</param>
    /// <param name="argTypes">The method parameter types in ordinal position</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T>(string name, params Type[] argTypes)
        => method(typeof(T), name, argTypes);

    /// <summary>
    /// Searches a type for a method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <param name="types">The argument types</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T>(string name, ClrType[] types)
        => method(typeof(T), name, array(types, t => t.ReflectedElement));

    /// <summary>
    /// Searches a type for a method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <typeparam name="X1">The first argument type</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T, X1>(string name)
        => method(typeof(T), name, typeof(X1));

    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <typeparam name="X1">The first argument type</typeparam>
    /// <typeparam name="X2">The second argument type</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T, X1, X2>(string name)
        => method<T>(name, types<X1, X2>());

    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <typeparam name="X1">The first argument type</typeparam>
    /// <typeparam name="X2">The second argument type</typeparam>
    /// <typeparam name="X3">The third argument type</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T, X1, X2, X3>(string name)
        => method<T>(name, types<X1, X2, X3>());

    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <typeparam name="X1">The first argument type</typeparam>
    /// <typeparam name="X2">The second argument type</typeparam>
    /// <typeparam name="X3">The third argument type</typeparam>
    /// <typeparam name="X4">The fourth argument type</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T, X1, X2, X3, X4>(string name)
        => method<T>(name, types<X1, X2, X3, X4>());

    /// <summary>
    /// Searches a type for any method that matches the supplied signature
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <typeparam name="X1">The first argument type</typeparam>
    /// <typeparam name="X2">The second argument type</typeparam>
    /// <typeparam name="X3">The third argument type</typeparam>
    /// <typeparam name="X4">The fourth argument type</typeparam>
    /// <param name="name">The name of the method</param>    
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<ClrMethod> method<T, X1, X2, X3, X4, X5>(string name)
        => method<T>(name, types<X1, X2, X3, X4, X5>());

    /// <summary>
    /// Searches for methods declared by a specified type that have a specific name
    /// </summary>
    /// <typeparam name="T">The type to search</typeparam>
    /// <param name="name">The name of the method</param>
    /// <returns></returns>
    public static Seq<ClrMethod> methods<T>(string name)
        => from m in ClrType.Get<T>().DeclaredMethods
           where m.Name == name
           select m;



}