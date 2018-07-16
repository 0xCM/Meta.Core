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
            => DefaultOrder<X>.instance;


        /// <summary>
        /// Constructs a <see cref="IMonoid"/> over <typeparamref name="X"/> if possible
        /// </summary>
        /// <typeparam name="X">The monoid element type</typeparam>
        public static Option<IOrderOperators<X>> orderops<X>()
            => DefaultOrder<X>.orderops;

        /// <summary>
        /// Canonical evolver that lifts a function delegate to a <see cref="Orderer{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f">The function to lift</param>
        /// <returns></returns>
        public static Orderer<X> orderer<X>(Func<X, X, Ordering> f)
            => new Orderer<X>(f);

        /// <summary>
        /// Constucts a <see cref="OrderComparer{X}"/> from a provided <see cref="Orderer{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public static OrderComparer<X> comparer<X>(Orderer<X> f)
            => new OrderComparer<X>(f);

        /// <summary>
        /// Constucts a <see cref="OrderComparer{X}"/> from a provided <see cref="IOrdered{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="ordered">An ordered typeclass instance</param>
        /// <returns></returns>
        public static OrderComparer<X> comparer<X>(IOrdered<X> ordered)
        {
            Orderer<X> orderer = (x, y) => ordered.compare(x, y);
            return comparer(orderer);
        }

        /// <summary>
        /// Reflects the ordering classification about the (stable) equality axis
        /// </summary>
        /// <param name="o">The ordering to evert</param>
        /// <returns></returns>
        public static Ordering invert(Ordering o)
            => o == Ordering.GT ? Ordering.LT :
               o == Ordering.LT ? Ordering.GT :
                Ordering.EQ;
     }
}