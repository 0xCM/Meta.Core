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
    /// Represents a function F:X->Y
    /// </summary>
    /// <typeparam name="X">The function domain</typeparam>
    /// <typeparam name="Y">The function codomain</typeparam>
    public readonly struct Function<X, Y> : IFunction<X,Y> 
    {
        /// <summary>
        /// Evaluates the function f at x
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="x">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Y operator *(Function<X, Y> f, X x)
            => f.Eval(x);

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public static Seq<Y> operator *(Function<X, Y> f, Seq<X> values)
            => Function.eval(f, values);

        /// <summary>
        /// Eagerly evaluates the function over a list
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The values over which evaluation will occur</param>
        /// <returns></returns>
        public static List<Y> operator *(Function<X, Y> f, List<X> values)
            => Function.eval(f, values);

        /// <summary>
        /// Implicitly constructs a <see cref="Function{X,Y}"/> representation
        /// </summary>
        /// <param name="f">The function to represent</param>
        public static implicit operator Function<X, Y>(Func<X, Y> f)
            => Function.make(f);

        /// <summary>
        /// Implicitly deconstructs a <see cref="Function{X,Y}"/> representation
        /// </summary>
        /// <param name="f">The function to represent</param>
        public static implicit operator Func<X, Y>(Function<X, Y> f)
            => Function.value(f);

        /// <summary>
        /// Initializes a representation with its subject
        /// </summary>
        /// <param name="f">The represented function</param>
        public Function(Func<X, Y> f)
            => F = f;
        
        /// <summary>
        /// The represented function
        /// </summary>
        public Func<X, Y> F { get; }

        /// <summary>
        /// Binds the represented function to a value
        /// </summary>
        /// <param name="input">The point at which to evaluate</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Y Eval(X input) 
            => F(input);

        /// <summary>
        /// Facilitates fluent workflow construction
        /// </summary>
        /// <param name="new"></param>
        /// <returns></returns>
        public Function<X, Y> Redefine(Func<X, Y> @new)
            => @new;

        /// <summary>
        /// Renders the function to its canonical display format
        /// </summary>
        public string Format()
            => Function.format(this);

        /// <summary>
        /// Renders the function to its canonical display format
        /// </summary>
        public override string ToString()
            => Format();
    }

}