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
using static metacore;


public static partial class tuple
{
    /// <summary>
    /// Determines the tuple's style, if possible; otherwise, returns None
    /// </summary>
    /// <param name="text">The putative tuple representation</param>
    /// <returns></returns>
    static Option<TupleFormatStyle> style(string text)
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

    /// <summary>
    /// Gets the boundary production function as determined by a style
    /// </summary>
    /// <param name="style">The tuple representation style</param>
    /// <returns></returns>
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
    public static Option<(X1 x1, X2 x2)> parse<X1, X2>(string text)
        => from style in style(text)
           let components = text.Trim(bounds(style)).Split(',')
           where components.Length == 3
           from x1 in try_parse<X1>(components[0])
           from x2 in try_parse<X2>(components[1])
           select (x1, x2);

    /// <summary>
    /// Parses a tuple in when represented in canonical form (x1,x2,x3)
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <param name="text">The text to parse</param>
    /// <returns></returns>
    public static Option<(X1 x1, X2 x2, X3 x3)> parse<X1, X2, X3>(string text)
        => from style in style(text)
           let components = text.Trim(bounds(style)).Split(',')
           where components.Length == 3
           from x1 in try_parse<X1>(components[0])
           from x2 in try_parse<X2>(components[1])
           from x3 in try_parse<X3>(components[2])
           select (x1, x2, x3);

    /// <summary>
    /// Parses a tuple of the form (x1,x2,x3,x4)
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <typeparam name="X4">The type of the fourth coordinate</typeparam>
    /// <param name="text">The text to parse</param>
    /// <returns></returns>
    public static Option<(X1 x1, X2 x2, X3 x3, X4 x4)> parse<X1, X2, X3, X4>(string text)
        => from style in style(text)
           let components = text.Trim(bounds(style)).Split(',')
           where components.Length == 4
           from x1 in try_parse<X1>(components[0])
           from x2 in try_parse<X2>(components[1])
           from x3 in try_parse<X3>(components[2])
           from x4 in try_parse<X4>(components[3])
           select (x1, x2, x3, x4);

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
    public static Option<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)> parse<X1, X2, X3, X4, X5>(string text)
        => from style in style(text)
           let components = text.Trim(bounds(style)).Split(',')
           where components.Length == 5           
           from x1 in try_parse<X1>(components[0])
           from x2 in try_parse<X2>(components[1])
           from x3 in try_parse<X3>(components[2])
           from x4 in try_parse<X4>(components[3])
           from x5 in try_parse<X5>(components[4])
           select (x1, x2, x3, x4, x5);

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
    public static Option<(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)> parse<X1, X2, X3, X4, X5, X6>(string text)
        => from style in style(text)
           let components = text.Trim(bounds(style)).Split(',')
           where components.Length == 5
           from x1 in try_parse<X1>(components[0])
           from x2 in try_parse<X2>(components[1])
           from x3 in try_parse<X3>(components[2])
           from x4 in try_parse<X4>(components[3])
           from x5 in try_parse<X5>(components[4])
           from x6 in try_parse<X6>(components[5])
           select (x1, x2, x3, x4, x5, x6);
}
