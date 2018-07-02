//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Identifies the Semigroup typeclass
    /// </summary>
    public interface ISemigroupoid : ITypeClass
    {

    }

    /// <summary>
    /// Defines contract for membership in the Semigroup typeclass
    /// </summary>
    /// <typeparam name="X">The semigroupoid element type</typeparam>
    public interface ISemigroupoid<X> : ISemigroupoid, ITypeClass<X>
    {

        /// <summary>
        /// Defines a function (x, y) => f(x, g(x, y)) via composition
        /// </summary>
        /// <typeparam name="X1">An arbitrary type</typeparam>
        /// <typeparam name="X2">Another arbitrary type</typeparam>
        /// <typeparam name="X3">The codomain of the resulting function</typeparam>
        /// <param name="f">A function over X</param>
        /// <param name="g">A function over X that is composition-compatible with f</param>
        /// <returns></returns>
        Func<X, X1, X3> compose<X1, X2, X3>(Func<X, X2, X3> f, Func<X, X1, X2> g);


        /// <summary>
        /// Defines a function (x, y) => g(x, f(x, y)) via reverse composition
        /// </summary>
        /// <typeparam name="X1">An arbitrary type</typeparam>
        /// <typeparam name="X2">Another arbitrary type</typeparam>
        /// <typeparam name="X3">The codomain of the resulting function</typeparam>
        /// <param name="f">A function over X</param>
        /// <param name="g">A function that is composition-compatible with f</param>
        /// <returns></returns>
        Func<X, X1, X3> rcompose<X1, X2, X3>(Func<X, X1, X2> f, Func<X, X2, X3> g);
    }

}