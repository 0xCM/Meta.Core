//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Identifies the Semiring typeclass
    /// </summary>
    public interface ISemiring : ITypeClass
    {

    }

    /// <summary>
    /// Defines Semiring membership criteria
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public interface ISemiring<X> :  ISemiring, ITypeClass<X>
    {
        /// <summary>
        /// Specifies the semiring's additive identity
        /// </summary>
        X zero { get; }

        /// <summary>
        /// Specifies the semiring's multiplicative identity
        /// </summary>
        X one { get; }

        /// <summary>
        /// Applies the semirings's addition operation to a pair of elements
        /// </summary>
        /// <param name="x1">The first element</param>
        /// <param name="x2">The second element</param>
        /// <returns></returns>
        X combine(X x1, X x2);

        /// <summary>
        /// Applies the semirings's multiplication operation to a pair of elements
        /// </summary>
        /// <param name="x1">The first element</param>
        /// <param name="x2">The second element</param>
        /// <returns></returns>
        X mul(X x1, X x2);
    }
}