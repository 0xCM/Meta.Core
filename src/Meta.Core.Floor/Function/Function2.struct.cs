//-------------------------------------------------------------------------------------------
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
    /// Represents a function F:X1->X2->Y
    /// </summary>
    /// <typeparam name="X1">The domain of the first function argument</typeparam>
    /// <typeparam name="X2">The domain of the second function argument</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Function<X1, X2, Y> : IFunction<(X1 x1, X2 x2), Y>
    {
        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator <((X1 x1, X2 x2) x, Function<X1, X2, Y> f)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator >((X1 x1, X2 x2) x, Function<X1, X2, Y> f)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator <(Function<X1, X2, Y> f, (X1 x1, X2 x2) x)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator >(Function<X1, X2, Y> f, (X1 x1, X2 x2) x)
            => f.Apply(x);

        /// <summary>
        /// Implicitly lifts a delegate to a Function
        /// </summary>
        /// <param name="f">The delegate to lift</param>
        public static implicit operator Function<X1, X2, Y>(Func<X1, X2, Y> f)
            => Function.wrap(f);

        /// <summary>
        /// Implicitly drops a function to a delegate
        /// </summary>
        /// <param name="f"></param>
        public static implicit operator Func<X1, X2, Y>(Function<X1, X2, Y> f)
            => Function.unwrap(f);

        public Function(Func<X1, X2, Y> f)
            => this.F = f;

        /// <summary>
        /// The represented function
        /// </summary>
        public Func<X1, X2, Y> F { get; }

        /// <summary>
        /// Value-wise evaulation
        /// </summary>
        /// <param name="x1">The first coordinate value</param>
        /// <param name="x2">The second coordinate value</param>
        /// <returns></returns>
        public Y Eval(X1 x1, X2 x2)
            => F(x1, x2);

        /// <summary>
        /// Binds the represented function to a value
        /// </summary>
        /// <param name="input">The point at which to evaluate</param>
        /// <returns></returns>
        public Y Apply((X1 x1, X2 x2) input)
            => F(input.x1, input.x2);

        public string Format()
            => Function.format(this);

        public override string ToString()
            => Format();
    }
}