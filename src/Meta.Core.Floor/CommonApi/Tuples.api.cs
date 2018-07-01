//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;

public static partial class metacore
{
    static bool isTuple(string text)
        => text.EnclosedBy(lparen(), rparen());

    /// <summary>
    /// Gets the first element of a 2-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X first<X, Y>((X x, Y y) p) 
        => p.x;

    /// <summary>
    /// Gets the second element of a 2-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y second<X, Y>((X x, Y y) p) 
        => p.y;

    /// <summary>
    /// Gets the third element of a 3-tuple
    /// </summary>
    /// <typeparam name="X">The first type</typeparam>
    /// <typeparam name="Y">The second type</typeparam>
    /// <typeparam name="Z">The third type</typeparam>
    /// <param name="p">The tuple from which the element will be extracted</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y second<X, Y, Z>((X x, Y y, Z z) p)
        => p.y;

    /// <summary>
    /// Canonical T => TxT expansion that lifts a scalar t to (t,t)
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="t">The value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T one, T two) two<T>(T t) 
        => (t, t);

    /// <summary>
    /// Canonical T => TxTxT expansion that lifts a scalar t to (t,t,t)
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="t">The value</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T one, T two, T three) three<T>(T t) 
        => (t, t, t);

    public static class tuple
    {

        /// <summary>
        /// Creates a canonical string representation of a 2-tuple
        /// </summary>
        /// <typeparam name="x1">The type of the first coordinate</typeparam>
        /// <typeparam name="x2">The type of the second coordinate</typeparam>
        /// <param name="tuple">The tuple value</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining), Formatter]
       
        public static string format<x1, x2>((x1, x2) tuple)
            => paren(string.Join(", ", tuple.Item1, tuple.Item2));

        /// <summary>
        /// Parses a tuple of the form (x1,x2)
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<(X1, X2)> parse<X1, X2>(string text)
        {
            if (!isTuple(text))
                return none<(X1, X2)>(MalformedTuple());

            var expectedCount = 2;
            var components = text.Split(',');
            var actualCount = components.Length;
            if (expectedCount != actualCount)
                return none<(X1, X2)>(CoordinateMismatch(expectedCount, actualCount));

            int idx = 0;
            return
                from x1 in try_parse<X1>(components[idx++])
                from x2 in try_parse<X2>(components[idx++])
                select (x1, x2);

        }

        /// <summary>
        /// Creates a canonical string representation of a 3-tuple
        /// </summary>
        /// <typeparam name="x1">The type of the first coordinate</typeparam>
        /// <typeparam name="x2">The type of the second coordinate</typeparam>
        /// <typeparam name="x3">The type of the third coordinate</typeparam>
        /// <param name="tuple">The tuple value</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining), Formatter]
        public static string format<x1, x2, x3>((x1, x2, x3) tuple)
            => paren(string.Join(", ", tuple.Item1, tuple.Item2, tuple.Item3));

        /// <summary>
        /// Parses a tuple in when represented in canonical form (x1,x2,x3)
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <typeparam name="X3">The type of the third coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<(X1, X2, X3)> parse<X1, X2, X3>(string text)
        {
            if (!isTuple(text))
                return none<(X1, X2, X3)>(MalformedTuple());

            var expectedCount = 3;
            var components = text.Split(',');
            var actualCount = components.Length;
            if (expectedCount != actualCount)
                return none<(X1, X2, X3)>(CoordinateMismatch(expectedCount, actualCount));

            int idx = 0;
            return
                from x1 in try_parse<X1>(components[idx++])
                from x2 in try_parse<X2>(components[idx++])
                from x3 in try_parse<X3>(components[idx++])
                select (x1, x2, x3);
        }

        /// <summary>
        /// Creates a canonical string representation of a 4-tuple
        /// </summary>
        /// <typeparam name="x1">The type of the first coordinate</typeparam>
        /// <typeparam name="x2">The type of the second coordinate</typeparam>
        /// <typeparam name="x3">The type of the third coordinate</typeparam>
        /// <typeparam name="x4">The type of the fourth coordinate</typeparam>
        /// <param name="tuple">The tuple value</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining),Formatter]
        public static string format<x1, x2, x3, x4>((x1, x2, x3, x4) tuple)
            => paren(string.Join(", ", tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));

        /// <summary>
        /// Parses a tuple of the form (x1,x2,x3,x4)
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <typeparam name="X3">The type of the third coordinate</typeparam>
        /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<(X1, X2, X3, X4)> parse<X1, X2, X3, X4>(string text)
        {
            if (!isTuple(text))
                return none<(X1, X2, X3, X4)>(MalformedTuple());

            var expectedCount = 4;
            var components = text.Split(',');
            if (components.Length != expectedCount)
                return none<(X1, X2, X3, X4)>(CoordinateMismatch(expectedCount, components.Length));

            int idx = 0;
            return
                from x1 in try_parse<X1>(components[idx++])
                from x2 in try_parse<X2>(components[idx++])
                from x3 in try_parse<X3>(components[idx++])
                from x4 in try_parse<X4>(components[idx++])
                select (x1, x2, x3, x4);
        }

        /// <summary>
        /// Creates a canonical string representation of a 5-tuple
        /// </summary>
        /// <typeparam name="x1">The type of the first coordinate</typeparam>
        /// <typeparam name="x2">The type of the second coordinate</typeparam>
        /// <typeparam name="x3">The type of the third coordinate</typeparam>
        /// <typeparam name="x4">The type of the fourth coordinate</typeparam>
        /// <typeparam name="x5">The type of the fifth coordinate</typeparam>
        /// <param name="tuple">The tuple value</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining),Formatter]
        public static string format<x1, x2, x3, x4, x5>((x1, x2, x3, x4, x5) tuple)
            => paren(string.Join(", ", tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5));

        /// <summary>
        /// Parses a tuple in when represented in canonical form
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <typeparam name="X3">The type of the third coordinate</typeparam>
        /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
        /// <typeparam name="X5">The type of the fifth coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>

        public static Option<(X1, X2, X3, X4, X5)> parse<X1, X2, X3, X4, X5>(string text)
        {
            if (!isTuple(text))
                return none<(X1, X2, X3, X4, X5)>(MalformedTuple());

            var expectedCount = 5;
            var components = text.Split(',');
            var actualCount = components.Length;
            if (actualCount != expectedCount)
                return none<(X1, X2, X3, X4, X5)>(CoordinateMismatch(expectedCount, actualCount));

            int idx = 0;
            return
                from x1 in try_parse<X1>(components[idx++])
                from x2 in try_parse<X2>(components[idx++])
                from x3 in try_parse<X3>(components[idx++])
                from x4 in try_parse<X4>(components[idx++])
                from x5 in try_parse<X5>(components[idx++])
                select (x1, x2, x3, x4, x5);
        }

    }

    /// <summary>
    /// Applies a function to a 2-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X">The projected type</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The function to apply</param>
    /// <returns></returns>
    public static X map<X1, X2, X>((X1 x1, X2 x2) x, Func<X1, X2, X> f)
        => f(x.x1, x.x2);

    /// <summary>
    /// Constructs an homogenous 2-tuple from the first two items in a stream
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    public static (X x1, X x2) two<X>(IEnumerable<X> source)
        => (source.First(), source.Second());

    /// <summary>
    /// Constructs a heterogeneous 2-tuple from the first two items in a stream
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (X1 x1, X2 x2) two<X1, X2>(IEnumerable<object> source)
        => (cast<X1>(source.First()), cast<X2>(source.Second()));

    /// <summary>
    /// Constructs an homogenous 3-tuple from the first three items in a stream
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="source">The value source</param>
    /// <returns></returns>
    public static (X x1, X x2, X x3) three<X>(IEnumerable<X> source)
        => (source.First(), source.Second(), source.Third());

    /// <summary>
    /// Constructs a heterogenous 3-tuple from the first three items in a stream
    /// </summary>
    /// <typeparam name="X1">The first item type</typeparam>
    /// <typeparam name="X2">The second item type</typeparam>
    /// <typeparam name="X3">The third item type</typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (X1 x1, X2 x2, X3 x3) three<X1, X2, X3>(IEnumerable<object> source)
        => (    cast<X1>(source.First()),  
                cast<X2>(source.Second()),  
                cast<X3>(source.Second())
            );

}