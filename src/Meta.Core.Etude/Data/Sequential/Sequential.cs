//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;


    public interface ISequential : IOrdered
    {

    }

    public interface ISequential<X> : ISequential, IOrdered<X>
    {
        /// <summary>
        /// Produces the successor of a value if it exists
        /// </summary>
        /// <param name="x">The value for which a successor should be computed</param>
        /// <returns></returns>
        Option<X> succ(X x);

        /// <summary>
        /// Produces the prececessor of a value if it exists
        /// </summary>
        /// <param name="x">The value for which a predecessor should be computed</param>
        /// <returns></returns>
        Option<X> pred(X x);
    }

    public class Sequential : ClassModule<Sequential, ISequential>
    {
        public Sequential()
            : base(typeof(Sequential<>))
        { }
    }

    readonly struct Sequential<X> : ISequential<X>
    {
        static readonly Option<IBounded<X>> _Bounded = DefaultBounded<X>.Default;
        static readonly Option<IOrdered<X>> _Order = DefaultOrder<X>.instance;
        static readonly Option<ISequential<X>> _Sequential = from b in _Bounded
                                                             from o in _Order
                                                             select new Sequential<X>(b, o) 
                                                                as ISequential<X>;

        IBounded<X> Bounded { get; }

        IOrdered<X> Ordered { get; }
    
        
        public Sequential(IBounded<X> Bounded, IOrdered<X> Ordered)
        {
            this.Bounded = Bounded;
            this.Ordered = Ordered;
        }


        public Ordering compare(X x1, X x2)
            => Ordered.compare(x1, x2);

        public bool eq(X x1, X x2)
            => Ordered.eq(x1, x2);

        /// <summary>
        /// Produces the prececessor of a value if it exists
        /// </summary>
        /// <param name="x">The value for which a predecessor should be computed</param>
        /// <remarks>If a bounded[x] instance exists, an attempt to compute the predecessor will only
        /// be made if the supplied value is greater than the minimum bound. If bounded[x] is 
        /// undefined, an attempt will be made</remarks>
        public Option<X> pred(X x)
            => compare(x, Bounded.minval) == Ordering.GT
                ? some(operators.decrement(x))
                : none<X>();

        /// <summary>
        /// Produces the sucessor of a value if it exists
        /// </summary>
        /// <param name="x">The value for which a predecessor should be computed</param>
        /// <remarks>If a bounded[x] instance exists, an attempt to compute the predecessor will only
        /// be made if the supplied value is greater than the minimum bound. If bounded[x] is 
        /// undefined, an attempt will be made</remarks>
        public Option<X> succ(X x)
            => compare(x, Bounded.minval) == Ordering.LT
                ? some(operators.increment(x))
                : none<X>();
    }


}