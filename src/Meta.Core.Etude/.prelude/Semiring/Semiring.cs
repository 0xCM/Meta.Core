//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    /// <summary>
    /// Constructs and manipulates <see cref="ISemiring{X}"/> types and values
    /// </summary>
    public sealed class Semiring : ClassModule<Semiring, ISemiring>
    {
        /// <summary>
        /// Defines a semiring over <typeparamref name="X"/> aligning with the supplied values
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <returns></returns>
        public static ISemiring<X> make<X>(X zero, X one, Combiner<X> add, Combiner<X> mul)
            => new Semiring<X>(zero, one, add, mul);

        /// <summary>
        /// Defines the instrinsic semiring over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <returns></returns>
        public static ISemiring<X> define<X>()
            => IntrinsicSemiring<X>.Value;

        /// <summary>
        /// Predicates a <see cref="ISemiring{X}"/> instance on intrinsic <typeparamref name="X"/> features
        /// </summary>
        /// <typeparam name="X"></typeparam>
        class IntrinsicSemiring<X> : ClassInstance<IntrinsicSemiring<X>, ISemiring>, ISemiring<X>
        {

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


}