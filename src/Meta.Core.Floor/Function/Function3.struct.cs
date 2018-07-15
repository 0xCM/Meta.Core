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
    /// Represents a function F:X1->X2->X3->Y
    /// </summary>
    /// <typeparam name="X1">The domain of the first function argument</typeparam>
    /// <typeparam name="X2">The domain of the second function argument</typeparam>
    /// <typeparam name="X3">The domain of the third function argument</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Function<X1, X2, X3, Y> : IFunction<(X1 x1, X2 x2, X3 x3), Y>
    {

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator <((X1 x1, X2 x2, X3 x3) x, Function<X1, X2, X3, Y> f)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator >((X1 x1, X2 x2, X3 x3) x, Function<X1, X2, X3, Y> f)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator <(Function<X1, X2, X3, Y> f, (X1 x1, X2 x2, X3 x3) x)
            => f.Apply(x);

        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator >(Function<X1, X2, X3, Y> f, (X1 x1, X2 x2, X3 x3) x)
            => f.Apply(x);

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Seq<Y> operator *(Function<X1, X2, X3, Y> f, Seq<(X1, X2, X3)> values)
            => Seq.make(from v in values.Stream()
                        select f.Apply(v));

        /// <summary>
        /// Eagerly evaluates the function over a list
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The values over which evaluation will occur</param>
        /// <returns></returns>
        public static Lst<Y> operator *(Function<X1, X2, X3, Y> f, Lst<(X1, X2, X3)> values)
            => Lst.make(from v in values.Stream()
                        select f.Apply(v));

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public Seq<Y> this[Seq<(X1 x1, X2 x2, X3 x3)> values]
        {
            get
            {
                var _f = F;
                return Seq.make((from v in values.Stream()
                       select _f(v.x1, v.x2, v.x3)));
            }
        }

        /// <summary>
        /// Eagerly evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public Lst<Y> this[Lst<(X1 x1, X2 x2, X3 x3)> values]
        {
            get
            {
                var _f = F;
                return Lst.make((from v in values.Stream()
                    select _f(v.x1, v.x2, v.x3)));
            }
        }

        /// <summary>
        /// Implicitly lifts a delegate to a Function
        /// </summary>
        /// <param name="f">The delegate to lift</param>
        public static implicit operator Function<X1, X2, X3, Y>(Func<X1, X2, X3, Y> f)
            => Function.wrap(f);

        /// <summary>
        /// Implicitly drops a function to a delegate
        /// </summary>
        /// <param name="f"></param>
        public static implicit operator Func<X1, X2, X3, Y>(Function<X1, X2, X3, Y> f)
            => Function.unwrap(f);


        public Function(Func<X1, X2, X3, Y> f)
            => this.F = f;

        /// <summary>
        /// The represented function
        /// </summary>
        public Func<X1, X2, X3, Y> F { get; }

        /// <summary>
        /// Binds the respresented function to a coordinate value
        /// </summary>
        /// <param name="x1">The value of the first coordinate</param>
        /// <param name="x2">The value of the second coordinate</param>
        /// <param name="x3">The value of the third coordinate</param>
        /// <returns></returns>
        public Y Eval(X1 x1, X2 x2, X3 x3)
            => F(x1, x2, x3);

        /// <summary>
        /// Binds the represented function to a coordinate value
        /// </summary>
        /// <param name="input">The point at which to evaluate</param>
        /// <returns></returns>
        public Y Apply((X1 x1, X2 x2, X3 x3) input)
            => F(input.x1, input.x2, input.x3);

        public string Format()
            => Function.format(this);

        public override string ToString()
            => Format();

    }

}