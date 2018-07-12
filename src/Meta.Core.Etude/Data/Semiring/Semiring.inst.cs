//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;



    /// <summary>
    /// Predicates a <see cref="ISemiring{X}"/> instance on intrinsic <typeparamref name="X"/> features
    /// </summary>
    /// <typeparam name="X"></typeparam>
    readonly struct DefaultSemiring<X> : ISemiring<X>
    {
        public static readonly DefaultSemiring<X> instance = default;

        /// <summary>
        /// Specifies the semiring's additive identity
        /// </summary>
        public X zero
            => operators.zero<X>();

        /// <summary>
        /// Specifies the semiring's multiplicative identity
        /// </summary>
        public X one
            => operators.one<X>();

        /// <summary>
        /// Applies the semirings's addition operation to a pair of elements
        /// </summary>
        /// <param name="x1">The first element</param>
        /// <param name="x2">The second element</param>
        /// <returns></returns>
        public X combine(X x1, X x2)
            => operators.add(x1, x2);

        /// <summary>
        /// Applies the semirings's multiplication operation to a pair of elements
        /// </summary>
        /// <param name="x1">The first element</param>
        /// <param name="x2">The second element</param>
        /// <returns></returns>
        public X mul(X x1, X x2)
            => operators.mul(x1, x2);
    }


}