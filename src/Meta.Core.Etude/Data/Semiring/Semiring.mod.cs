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
    /// Constructs and manipulates <see cref="ISemiring{X}"/> types and values
    /// </summary>
    public class Semiring : ClassModule<Semiring, ISemiring>
        
    {
        public Semiring()
            : base(typeof(Semiring<>))
        {

        }

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
        public static ISemiring<X> @default<X>()
            => DefaultSemiring<X>.instance;

    }


}