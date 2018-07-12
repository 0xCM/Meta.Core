//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;

partial class metacore
{
    /// <summary>
    /// Raises an exception populated with what happened and where it happened
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="member"></param>
    /// <param name="path"></param>
    /// <param name="line"></param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T shame<T>([CallerMemberName] string member = null,
        [CallerFilePath] string path = null, [CallerLineNumber] int line = 0)
            => throw new Exception<int>("You referenced a NULL value!", member, path, line);

    /// <summary>
    /// Raises an exception populated with what happened and where it happened
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="member"></param>
    /// <param name="path"></param>
    /// <param name="line"></param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unit fail(string reason, [CallerMemberName] string member = null,
        [CallerFilePath] string path = null, [CallerLineNumber] int line = 0)
            => throw new Exception<int>(reason, member, path, line);

    /// <summary>
    /// Raises an exception populated with what happened and where it happened
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="member"></param>
    /// <param name="path"></param>
    /// <param name="line"></param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T fail<T>(IAppMessage reason, [CallerMemberName] string member = null,
        [CallerFilePath] string path = null, [CallerLineNumber] int line = 0)
            => throw new Exception<int>(reason.Format(false), member, path, line);

    /// <summary>
    /// Raises an exception indicating a feature is not implemented
    /// </summary>
    /// <param name="member"></param>
    /// <param name="path"></param>
    /// <param name="line"></param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T noimpl<T>([CallerMemberName] string member = null,
        [CallerFilePath] string path = null, [CallerLineNumber] int line = 0)
            => throw new Exception<int>("Not implemented", member, path, line);

    /// <summary>
    /// Throws a <see cref="ArgumentNullException"/> if the argument is null
    /// </summary>
    /// <typeparam name="T">The argument type</typeparam>
    /// <param name="x">The value of the argument</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T require<T>(T x, [CallerMemberName] string caller = null) where T : class
    {
        if (x == null)
            throw new ArgumentNullException("x", $"Parameter supplied to {caller} was null");
        else
            return x;
    }

    /// <summary>
    /// Verifies that the argument value is not null (or if is a string it is nonempty) and, if so, throws a <see cref="ArgumentException"/>
    /// </summary>
    /// <typeparam name="T">The argument type</typeparam>
    /// <param name="argName">The name of the argument</param>
    /// <param name="argValue">The value of the argument</param>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T require_arg<T>(string argName, T argValue, [CallerMemberName] string caller = null) where T : class
    {
        if (argValue == null)
            throw new ArgumentNullException(argName, $"An argument supplied to {caller} was null");
        else if (argValue.GetType() == typeof(string) && isBlank(cast<string>(argValue)))
            throw new ArgumentException($"A nonempty string is required", argName);
        return argValue;
    }

    /// <summary>
    /// Throws a <see cref="ArgumentException"/> if the argument is null, empty or contains only whitespace
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string require(string x, [CallerMemberName] string caller = null)
    {
        if (isBlank(x))
            throw new ArgumentNullException($"Parameter supplied to {caller} was unspecified");
        return x;
    }

    /// <summary>
    /// Returns the value if it satisfies the predicate; oterwise, throws an exception
    /// </summary>
    /// <typeparam name="X">The type of value to evaluate</typeparam>
    /// <param name="x">The value to evaluate</param>
    /// <param name="criterion">The predicate used in the evauluation</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X require<X>(X x, Func<X, bool> criterion)
        => criterion(x) ? x : throw new ArgumentException($"Required predicate failed");


    /// <summary>
    /// Defines, but does not throw, a <see cref="ArgumentException"/>
    /// </summary>
    /// <typeparam name="T">The argument type</typeparam>
    /// <param name="argval"></param>
    /// <returns></returns>
    public static ArgumentException badarg<T>(string argval)
        => new ArgumentException(Failure<T>(argval).Format());

    /// <summary>
    /// Demands that the option have a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="option"></param>
    /// <returns></returns>
    public static T require<T>(Option<T> option)
        => option.Require();

}



