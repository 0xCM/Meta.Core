﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Modules;

    /// <summary>
    /// Represents a function F:X1->X2->X3->X4->Y
    /// </summary>
    /// <typeparam name="X1">The domain of the first function argument</typeparam>
    /// <typeparam name="X2">The domain of the second function argument</typeparam>
    /// <typeparam name="X3">The domain of the third function argument</typeparam>
    /// <typeparam name="X4">The domain of the fourth function argument</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Function<X1, X2, X3, X4, Y> : IFunction<(X1 x1, X2 x2, X3 x3, X4 x4), Y>
    {
        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator *(Function<X1, X2, X3, X4, Y> f, (X1 x1, X2 x2, X3 x3, X4 x4) x)
            => f.Eval(x);

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Seq<Y> operator *(Function<X1, X2, X3, X4, Y> f, Seq<(X1,X2,X3,X4)> values)
            => Seq.make(from v in values.Stream()
                          select f.Eval(v));

        /// <summary>
        /// Eagerly evaluates the function over a list
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The values over which evaluation will occur</param>
        /// <returns></returns>
        public static List<Y> operator *(Function<X1, X2, X3, X4, Y> f, List<(X1, X2, X3, X4)> values)
            => List.make(from v in values.Stream()
                          select f.Eval(v));

        /// <summary>
        /// Implicitly lifts a delegate to a Function
        /// </summary>
        /// <param name="f">The delegate to lift</param>
        public static implicit operator Function<X1, X2, X3,X4, Y>(Func<X1, X2, X3, X4,Y> f)
            => Function.make(f);

        /// <summary>
        /// Implicitly drops a function to a delegate
        /// </summary>
        /// <param name="f"></param>
        public static implicit operator Func<X1, X2, X3, X4, Y>(Function<X1, X2, X3, X4, Y> f)
            => Function.value(f);

        /// <summary>
        /// Constructs the function
        /// </summary>
        /// <param name="f"></param>
        public Function(Func<X1, X2, X3, X4, Y> f)
            => this.F = f;

        /// <summary>
        /// The represented function
        /// </summary>
        public Func<X1, X2, X3, X4, Y> F { get; }

        /// <summary>
        /// Binds the respresented function to a coordinate value
        /// </summary>
        /// <param name="x1">The value of the first coordinate</param>
        /// <param name="x2">The value of the second coordinate</param>
        /// <param name="x3">The value of the third coordinate</param>
        /// <returns></returns>
        public Y Eval(X1 x1, X2 x2, X3 x3, X4 x4)
            => F(x1, x2, x3, x4);

        /// <summary>
        /// Binds the represented function to a coordinate value
        /// </summary>
        /// <param name="input">The point at which to evaluate</param>
        /// <returns></returns>
        public Y Eval((X1 x1, X2 x2, X3 x3, X4 x4) input)
            => F(input.x1, input.x2, input.x3, input.x4);

        public string Format()
            => Function.format(this);

        public override string ToString()
            => Format();

    }

}