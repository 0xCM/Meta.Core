//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Operators;
using Meta.Core.Modules;

public static class operators
{
    /// <summary>
    /// Adjudicates whether <typeparamref name="T"/> values can be ordered 
    /// according to the existence of less than and greater than operators
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool orderable<T>()
        => LessThan<T>.Exists && GreaterThan<T>.Exists;

    /// <summary>
    /// Adjudicates whether precedessors and successors are computable
    /// for <typeparamref name="T"/> values according to the existence of
    /// the decrement and increment operators
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool sequential<T>()
        => Increment<T>.Exists && Decrement<T>.Exists;

    /// <summary>
    /// Invokes (+)(x,y) for a type <typeparamref name="T"/> that implements the addition operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T add<T>(T x, T y) 
        => Add<T>.Apply(x, y);

    /// <summary>
    /// Computes the aggregated sum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="terms"></param>
    /// <returns></returns>
    public static T addAll<T>(params T[] terms)
        => terms.Aggregate(add);

    /// <summary>
    /// Applies (+) by coordinate
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <param name="a">The first tuple</param>
    /// <param name="b">The second tuple</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2) add<X1, X2>((X1 x1, X2 x2) a, (X1 x1, X2 x2) b)
        => (add(a.x1, b.x1), add(a.x2, b.x2));

    /// <summary>
    /// Applies (+) by coordinate
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <param name="a">The first tuple</param>
    /// <param name="b">The second tuple</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3) add<X1, X2, X3>((X1 x1, X2 x2, X3 x3) a, (X1 x1, X2 x2, X3 x3) b)
        => (add(a.x1, b.x1), add(a.x2, b.x2), add(a.x3,b.x3));

    /// <summary>
    /// Unary addition over a tuple
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X add<X>((X x1, X x2) x)
        => add(x.x1, x.x2);

    /// <summary>
    /// Invokes checked (+)(x,y) for a type <typeparamref name="T"/> that implements the addition operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T addCk<T>(T x, T y) 
        => AddChecked<T>.Apply(x, y);

    /// <summary>
    /// Invokes (-)(x,y) for a type <typeparamref name="T"/> that implements the subtraction operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T sub<T>(T x, T y) 
        => Subtract<T>.Apply(x, y);

    /// <summary>
    /// Applies (-) by coordinate
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <param name="a">The first tuple</param>
    /// <param name="b">The second tuple</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2) sub<X1, X2>((X1 x1, X2 x2) a, (X1 x1, X2 x2) b)
        => (sub(a.x1, b.x1), sub(a.x2, b.x2));

    /// <summary>
    /// Applies (-) by coordinate
    /// </summary>
    /// <typeparam name="X1">The type of the first coordinate</typeparam>
    /// <typeparam name="X2">The type of the second coordinate</typeparam>
    /// <typeparam name="X3">The type of the third coordinate</typeparam>
    /// <param name="a">The first tuple</param>
    /// <param name="b">The second tuple</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (X1 x1, X2 x2, X3 x3) sub<X1, X2, X3>((X1 x1, X2 x2, X3 x3) a, (X1 x1, X2 x2, X3 x3) b)
        => (sub(a.x1, b.x1), sub(a.x2, b.x2), sub(a.x3, b.x3));

    /// <summary>
    /// Invokes checked (-)(x,y) for a type <typeparamref name="T"/> that implements the subraction operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T subCk<T>(T x, T y) 
        => SubtractChecked<T>.Apply(x, y);

    /// <summary>
    /// Invokes (-)(x) for a type <typeparamref name="T"/> that implements the negation
    /// </summary>
    /// <typeparam name="T">A type that implements the - operator</typeparam>
    /// <param name="x">The value to negate</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T neg<T>(T x)
        => Negate<T>.Apply(x);

    /// <summary>
    /// Invokes checked (-)(x) for a type <typeparamref name="T"/> that implements the negation
    /// </summary>
    /// <typeparam name="T">A type that implements the - operator</typeparam>
    /// <param name="x">The value to negate</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T negCk<T>(T x)
        => NegateChecked<T>.Apply(x);

    /// <summary>
    /// Invokes  (*)(x,y) for a type <typeparamref name="T"/> that implements the multiplication operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T mul<T>(T x, T y) 
        => Multiply<T>.Apply(x, y);

    /// <summary>
    /// Invokes  checked (*)(x,y) for a type <typeparamref name="T"/> that implements the multiplication operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T mulCk<T>(T x, T y) 
        => MultiplyChecked<T>.Apply(x, y);

    /// <summary>
    /// Invokes  (\)(x,y) for a type <typeparamref name="T"/> that implements the division operator
    /// </summary>
    /// <typeparam name="T">A type that implements the + operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T div<T>(T x, T y) 
        => Ops.Divide<T>.Apply(x, y);

    /// <summary>
    /// Invokes %(x,y) for a type <typeparamref name="T"/> that implements the modulus operator
    /// </summary>
    /// <typeparam name="T">A type that implements the % operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T mod<T>(T x, T y) 
        => Modulo<T>.Apply(x, y);

    /// <summary>
    /// Invokes ==(x,y) for a type <typeparamref name="T"/> that implements the equality operator
    /// </summary>
    /// <typeparam name="T">A type that implements the == operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool eq<T>(T x, T y) 
        => Equal<T>.Apply(x, y);

    /// <summary>
    /// Invokes !=(x,y) for a type <typeparamref name="T"/> that implements the not-equal operator
    /// </summary>
    /// <typeparam name="T">A type that implements the != operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool neq<T>(T x, T y) 
        => NotEqual<T>.Apply(x, y);

    /// <summary>
    /// Invokes >(x,y) for a type <typeparamref name="T"/> that implements the greater than operator
    /// </summary>
    /// <typeparam name="T">A type that implements the > operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool gt<T>(T x, T y) 
        => GreaterThan<T>.Apply(x, y);

    /// <summary>
    /// Invokes >=(x,y) for a type <typeparamref name="T"/> that implements the greater than or equqal operator
    /// </summary>
    /// <typeparam name="T">A type that implements the > operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool gteq<T>(T x, T y) 
        => GreaterThanOrEqual<T>.Apply(x, y);

    /// <summary>
    /// Invokes lt(x,y) for a type <typeparamref name="T"/> that implements the less than operator
    /// </summary>
    /// <typeparam name="T">A type that implements the > operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool lt<T>(T x, T y) 
        => LessThan<T>.Apply(x, y);

    /// <summary>
    /// Invokes lteq(x,y) for a type <typeparamref name="T"/> that implements the less than or equal operator
    /// </summary>
    /// <typeparam name="T">A type that implements the less than or equal operator</typeparam>
    /// <param name="x">The first argument</param>
    /// <param name="y">The second argument</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool lteq<T>(T x, T y) 
        => LessThanOrEqual<T>.Apply(x, y);

    /// <summary>
    /// Invokes ++x for a type <typeparamref name="T"/> that implements the increment operator
    /// </summary>
    /// <typeparam name="T">A type that implements the ++ operator</typeparam>
    /// <param name="x">The value to increment</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T increment<T>(T x) 
        => Increment<T>.Apply(x);

    /// <summary>
    /// Invokes ++x for a type <typeparamref name="T"/> that implements the decrement operator
    /// </summary>
    /// <typeparam name="T">A type that implements the ++ operator</typeparam>
    /// <param name="x">The value to decrement</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T decrement<T>(T x) 
        => Decrement<T>.Apply(x);

    /// <summary>
    /// Specifies the additive identity of a type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T zero<T>() 
        => Zero<T>.Value;

    /// <summary>
    /// Specifies the multiplicative identity of a type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T one<T>() 
        => One<T>.Value;

    /// <summary>
    /// Invokes the logical and operator for the supplied operands
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool and<T>(T x, T y) 
        => AndAlso<T>.Apply(x, y);

    /// <summary>
    /// Invokes the logical or operator for the supplied operands
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool or<T>(T x, T y) 
        => OrElse<T>.Apply(x, y);

    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Y convert<X, Y>(X x)
        => Convert<X, Y>.Apply(x);
}
