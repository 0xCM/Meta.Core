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

        public static Y operator <(X x, Function<X, Y> f)
            => f.Apply(x);

        public static Y operator >(X x, Function<X, Y> f)
            => f.Apply(x);

        public static Y operator <(Function<X, Y> f, X x)
            => f.Apply(x);

        public static Y operator >(Function<X, Y> f, X x)
            => f.Apply(x);

        /// <summary>
        /// Implicitly constructs a <see cref="Function{X,Y}"/> representation
        /// </summary>
        /// <param name="f">The function to represent</param>
        public static implicit operator Function<X, Y>(Func<X, Y> f)
            => Function.wrap(f);

        /// <summary>
        /// Implicitly deconstructs a <see cref="Function{X,Y}"/> representation
        /// </summary>
        /// <param name="f">The function to represent</param>
        public static implicit operator Func<X, Y>(Function<X, Y> f)
            => Function.unwrap(f);

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
        /// <param name="x">The value at which to evaluate the function</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Y Apply(X x) 
            => F(x);

        /// <summary>
        /// Lazily evaluate the function over a sequence
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public Seq<Y> this [Seq<X> values]
            => values.Select(F);

        /// <summary>
        /// Eagerly evaluate the function over a list
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <param name="values">The value over which evaluation will occur</param>
        /// <returns></returns>
        public Lst<Y> this[Lst<X> values]
            => values.Select(F);

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