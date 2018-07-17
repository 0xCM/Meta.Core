//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;

    using ListModule = Lst;
    using SeqModule = Seq;

    /// <summary>
    /// Constructs and manipulates <see cref="IMonoid{X}"/> types and values
    /// </summary>
    public class Monoid : ClassModule<Monoid, IMonoid>, IMonoid
    {
        public Monoid()
            : base(typeof(Monoid<>))
        {
        }
        
        /// <summary>
        /// Constructs a <see cref="IMonoid"/> over <typeparamref name="X"/> using supplied aspects
        /// </summary>
        /// <typeparam name="X">The monoid element type</typeparam>
        /// <param name="Comparer"></param>
        /// <param name="Combiner"></param>
        /// <param name="Zero"></param>
        /// <returns></returns>
        public static IMonoid<X> make<X>(Equator<X> Comparer, Combiner<X> Combiner, X Zero)
            => new Monoid<X>(Comparer, Combiner, Zero);

        /// <summary>
        /// Attempts to construct a <see cref="IMonoid"/> over <typeparamref name="X"/> using derived aspects
        /// </summary>
        /// <typeparam name="X">The monoid element type</typeparam>
        public static Option<IMonoid<X>> make<X>()
            => Try(() => Instances.TryFind(typeof(X))
                        .MapValueOrDefault(instance => cast<IMonoid<X>>(instance), DefaultMonoid<X>.instance));

        static ConcurrentDictionary<Type, object> Instances { get; }
            = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Determines whether a value is equal to the additive identity
        /// </summary>
        /// <param name="a">The value to test</param>
        /// <returns></returns>
        public static bool isZero<X>(X a, IMonoid<X> monoid)
            => monoid.eq(a, monoid.zero);

        /// <summary>
        /// Combines a sequence of elements via the monoid's additive operator
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static X combine<X>(Seq<X> values, IMonoid<X> monoid)
            => SeqModule.foldl(monoid.combine, monoid.zero, values);
    }
}