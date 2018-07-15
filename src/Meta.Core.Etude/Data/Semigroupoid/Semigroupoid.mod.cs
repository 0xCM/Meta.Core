//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;

    /// <summary>
    /// Constructs and manipulates <see cref="ISemigroupoid{X}"/> types and values
    /// </summary>
    public sealed class Semigroupoid : ClassModule<Semigroupoid, ISemigroupoid>
    {
        public Semigroupoid()
            : base(typeof(Semigroupoid<>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="ISemigroupoid"/> over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <returns></returns>
        public static ISemigroupoid<X> make<X>()
            => Semigroupoid<X>.instance;

        /// <summary>
        /// Defines a function (x, y) => f(x, g(x, y)) via forward composition
        /// </summary>
        /// <typeparam name="G">The semigroupoid element type</typeparam>
        /// <typeparam name="X1">An arbitrary type</typeparam>
        /// <typeparam name="X2">Another arbitrary type</typeparam>
        /// <typeparam name="X3">The codomain of the resulting function</typeparam>
        /// <param name="f">A function over X</param>
        /// <param name="g">A function over X that is composition-compatible with f</param>
        public static Func<G, X1, X3> compose<G, X1, X2, X3>(Func<G, X2, X3> f, Func<G, X1, X2> g)
            => make<G>().compose(f, g);

        /// <summary>
        /// Defines a function (x, y) => g(x, f(x, y)) via reverse composition
        /// </summary>
        /// <typeparam name="X">The semigroupoid element type</typeparam>
        /// <typeparam name="X1">An arbitrary type</typeparam>
        /// <typeparam name="X2">Another arbitrary type</typeparam>
        /// <typeparam name="X3">The codomain of the resulting function</typeparam>
        /// <param name="f">A function over X</param>
        /// <param name="g">A function that is composition-compatible with f</param>
        /// <returns></returns>
        public static Func<X, X1, X3> rcompose<X, X1, X2, X3>(Func<X, X1, X2> f, Func<X, X2, X3> g)
            => make<X>().rcompose(f, g);
    } 
}