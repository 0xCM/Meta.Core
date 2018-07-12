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

    /// <summary>
    /// Constructs and manipulates <see cref="IOrdered{X}"/> types and values
    /// </summary>
    public class Ordered : ClassModule<Ordered, IOrdered>
    {        
        public Ordered()
            : base(typeof(Ordered<>))
        { }
        
        public static Option<IOrdered<X>> make<X>()
            => Try(() => Instances.TryFind(typeof(X)).MapValueOrDefault(o
                    => cast<IOrdered<X>>(o), DefaultOrder<X>.Default));

        /// <summary>
        /// Constructs a <see cref="IMonoid"/> over <typeparamref name="X"/> if possible
        /// </summary>
        /// <typeparam name="X">The monoid element type</typeparam>
        public static Option<IOrderOperators<X>> orderops<X>()
            => Try(() => Instances.TryFind(typeof(X)).MapValueOrDefault(o 
                    => cast<IOrderOperators<X>>(o), DefaultOrder<X>.Default));

        /// <summary>
        /// Canonical evolver that lifts a function delegate to a <see cref="Orderer{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f">The function to lift</param>
        /// <returns></returns>
        public static Orderer<X> orderer<X>(Func<X, X, Ordering> f)
            => new Orderer<X>(f);

        /// <summary>
        /// Constucts a <see cref="Komparer{X}"/> from a provided <see cref="Orderer{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Komparer<X> comparer<X>(Orderer<X> f)
            => new Komparer<X>(f);

        /// <summary>
        /// Constucts a <see cref="Komparer{X}"/> from a provided <see cref="IOrdered{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="ordered">An ordered typeclass instance</param>
        /// <returns></returns>
        public static Komparer<X> comparer<X>(IOrdered<X> ordered)
        {
            Orderer<X> orderer = (x, y) => ordered.compare(x, y);
            return comparer(orderer);
        }

        static ConcurrentDictionary<Type, object> Instances { get; }
            = new ConcurrentDictionary<Type, object>();
     }
}