﻿//-------------------------------------------------------------------------------------------
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

public static class minicore
{
    /// <summary>
    /// Creates a stream from an arbitrary number of items
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="items">The items included in the stream</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> stream<T>(params T[] items)
        => items;

    /// <summary>
    /// Iterates over items sequentially or in parallel, invokes the supplied action for each one
    /// and then returns the unit value
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items</param>
    /// <param name="action">The action to apply</param>
    /// <param name="pll">Whether parallel iteration should be invoked</param>    
    public static Unit iter<T>(IEnumerable<T> items, Action<T> action, bool pll = false)
    {
        if (pll)
            items.AsParallel().ForAll(item => action(item));
        else
            foreach (var item in items)
                action(item);
        return Unit.Value;
    }

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
    /// Shorthand for the <see cref="string.IsNullOrEmpty(string)"/> method
    /// </summary>
    /// <param name="subject">The string to evaluate</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool isBlank(string subject)
        => String.IsNullOrWhiteSpace(subject);

    /// <summary>
    /// Creates a <see cref="Option{T}"/> with no value
    /// </summary>
    /// <typeparam name="T">The type of the optional value</typeparam>
    /// <returns></returns>
    public static Option<T> none<T>(IApplicationMessage message = null)
        => Option<T>.None(message ?? ApplicationMessage.Empty);

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
    public static Option<T> some<T>(T value, IApplicationMessage message = null)
        => new Option<T>(value, message);

    /// <summary>
    /// A string-specific coalescing operation
    /// </summary>
    /// <param name="subject">The subject string</param>
    /// <param name="replace">The replacement value if blank</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ifBlank(string subject, string replace)
        => isBlank(subject) ? replace : subject;

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
    /// Converts a sequence of 2-tuples to a <see cref="IReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IReadOnlyDictionary<TKey, TValue> dict<TKey, TValue>(IEnumerable<(TKey Key, TValue Value)> items)
            => items.ToDictionary(x => x.Key, x => x.Value);

    /// <summary>
    /// Concatenates the supplied strings
    /// </summary>
    /// <param name="strings">The strings to concatenate</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string concat(params string[] strings)
        => string.Join(String.Empty, strings);

    /// <summary>
    /// Creates an array from the supplied items
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(params T[] items)
        => items?.ToArray() ?? new T[] { };

    /// <summary>
    /// Parse an enum or returns a default value if parsing fails
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="text"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static T parseEnum<T>(string text, T @default)
        where T : struct
    {
        var result = @default;
        Enum.TryParse(text, true, out result);
        return result;
    }

    /// <summary>
    /// Parses an enumeration
    /// </summary>
    /// <typeparam name="T">The enumeration type</typeparam>
    /// <param name="value">The value of the enumeration</param>
    /// <returns></returns>
    [DebuggerStepperBoundary]
    public static T parseEnum<T>(string value)
        => (T)Enum.Parse(typeof(T), value, true);

    public static Link<X, Y> link<X, Y>(X x, Y y)
        => new Link<X, Y>(x, y);

    /// <summary>
    /// Produces a left-brace character as a string
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string lbrace() => "{";

    /// <summary>
    /// Produces a right-brace character as a string
    /// </summary>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string rbrace() => "}";

    /// <summary>
    /// If subject is not null, invokes its ToString() method; otherwise, returns an empty string or a supplied marker
    /// </summary>
    /// <typeparam name="T">The subject type</typeparam>
    /// <param name="subject">The subject</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string toString<T>(T subject, string ifMissing = null)
        => (subject is string)
            ? toString(subject as string, ifMissing)
            : (subject != null ? subject.ToString() : ifMissing ?? String.Empty);

    /// <summary>
    /// Encloses content within specified boundaries
    /// </summary>
    /// <param name="content">The fenced contant</param>
    /// <param name="left">The text on the left</param>
    /// <param name="right">The text on the right</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string wrap(object left, object content, object right)
        => $"{toString(left)}{toString(content)}{toString(right)}";

    /// <summary>
    /// Encloses text between '{' and '}' characters
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string embrace(string content)
        => wrap(lbrace(), content, rbrace());

    /// <summary>
    /// Logical negation
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool not(bool condition)
        => !condition;

    /// <summary>
    /// Creates a <see cref="lazy{T}(Func{T})"/>.
    /// </summary>
    /// <param name="factory">A function that creates an instance of the lazy object</param>
    /// <returns></returns>
    public static Lazy<T> lazy<T>(Func<T> factory)
        => new Lazy<T>(factory);

    /// <summary>
    /// Casts a value if possible, otherwise returns failure
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="item">The object to cast</param>
    /// <returns></returns>
    public static Option<T> tryCast<T>(object item)
        => item is T ? some((T)item) : none<T>();

    /// <summary>
    /// Evaluates a function within a try block and returns the value of the computation if 
    /// successful; otherwise, returns None together with the reported exceptions
    /// </summary>
    /// <typeparam name="T">The result type</typeparam>
    /// <param name="f">The function to evaluate</param>
    /// <returns></returns>
    public static Option<T> Try<T>(Func<T> f)
    {
        try
        {
            return f();
        }
        catch (Exception e)
        {
            return none<T>(ApplicationMessage.Error(e));
        }
    }

}