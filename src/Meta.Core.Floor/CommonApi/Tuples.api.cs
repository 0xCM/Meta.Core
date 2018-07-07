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

public enum TupleFormatStyle
{
    /// <summary>
    /// Indicates a tuple text representation of the form "(x1,...xn)"
    /// </summary>
    Coordinate,

    /// <summary>
    /// Indicates a tuple text representation of the form "[x1,...xn]"
    /// </summary>
    List,

    /// <summary>
    /// Indicates a tuple text representation of the form "{x1,...xn}"
    /// </summary>
    Record
}

public static partial class metacore
{
                   
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
        static Option<TupleFormatStyle> isTuple(string text)
            => text.EnclosedBy(lparen(), rparen()) ? some(TupleFormatStyle.Coordinate)
            : text.EnclosedBy(lbracket(), rbracket()) ? some(TupleFormatStyle.List)
            : text.EnclosedBy(lbrace(), rbrace()) ? some(TupleFormatStyle.Record)
            : none<TupleFormatStyle>();

        static char leftBoundary(TupleFormatStyle style)
            => (style == TupleFormatStyle.Coordinate ? lparen()
            : style == TupleFormatStyle.List ? lbracket()
            : style == TupleFormatStyle.Record ? lbrace()
            : lparen())[0];

        static char rightBoundary(TupleFormatStyle style)
            => (style == TupleFormatStyle.Coordinate ? rparen()
            : style == TupleFormatStyle.List ? rbracket()
            : style == TupleFormatStyle.Record ? rbrace()
            : rparen())[0];

        static char[] bounds(TupleFormatStyle style)
            => array(leftBoundary(style), rightBoundary(style));

        internal static Func<string, string> boundaryFn(TupleFormatStyle style)
            => style == TupleFormatStyle.List ? new Func<string, string>(bracket)
            : style == TupleFormatStyle.Record ? new Func<string, string>(embrace)
            : new Func<string, string>(paren);


        /// <summary>
        /// Parses a tuple of the form (x1,x2)
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<(X1, X2)> parse<X1, X2>(string text)
        {
            var style = isTuple(text);

            if (!style)
                return none<(X1, X2)>(MalformedTuple());
            var trimChars = style.MapRequired(bounds);

            var expectedCount = 2;
            var components = text.Trim(trimChars).Split(',');
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
        /// Parses a tuple in when represented in canonical form (x1,x2,x3)
        /// </summary>
        /// <typeparam name="X1">The type of the first coordinate</typeparam>
        /// <typeparam name="X2">The type of the second coordinate</typeparam>
        /// <typeparam name="X3">The type of the third coordinate</typeparam>
        /// <param name="text">The text to parse</param>
        /// <returns></returns>
        public static Option<(X1, X2, X3)> parse<X1, X2, X3>(string text)
        {
            var style = isTuple(text);
            if (!style)
                return none<(X1, X2, X3)>(MalformedTuple());

            var expectedCount = 3;
            var trimChars = style.MapRequired(bounds);
            var components = text.Trim(trimChars).Split(',');
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
            var style = isTuple(text);

            if (!style)
                return none<(X1, X2, X3, X4)>(MalformedTuple());

            var expectedCount = 4;
            var trimChars = style.MapRequired(bounds);
            var components = text.Trim(trimChars).Split(',');
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
            var style = isTuple(text);

            if (!style)
                return none<(X1, X2, X3, X4, X5)>(MalformedTuple());

            var expectedCount = 5;
            var trimChars = style.MapRequired(bounds);
            var components = text.Trim(trimChars).Split(',');
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
    /// Applies two functions over respective coordinate values
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="Y1"></typeparam>
    /// <typeparam name="Y2"></typeparam>
    /// <param name="x"></param>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
    public static (Y1 y1, Y2 y2) map<X1, X2, Y1, Y2>((X1 x1, X2 x2) x, Func<X1, Y1> f1, Func<X2, Y2> f2)
        => x.Map(f1, f2);

    /// <summary>
    /// Applies a function to a 3-tuple
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X">The projected type</typeparam>
    /// <param name="x">The input value</param>
    /// <param name="f">The function to apply</param>
    /// <returns></returns>
    public static X map<X1, X2, X3, X>((X1 x1, X2 x2, X3 x3) x, Func<X1, X2,X3, X> f)
        => f(x.x1, x.x2, x.x3);

    /// <summary>
    /// Applies three functions over respective coordinate tuples
    /// </summary>
    /// <typeparam name="X1"></typeparam>
    /// <typeparam name="X2"></typeparam>
    /// <typeparam name="Y1"></typeparam>
    /// <typeparam name="Y2"></typeparam>
    /// <param name="x"></param>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
    public static (Y1 y1, Y2 y2, Y3 y3) map<X1, X2, X3, Y1, Y2, Y3>((X1 x1, X2 x2, X3 x3) x, Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
        => x.Map(f1, f2, f3);

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