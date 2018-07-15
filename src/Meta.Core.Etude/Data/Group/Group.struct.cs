//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines a group predicated on constructor-injected functions
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct Group<X> : IGroup<X>
    {

        public Group(Equator<X> Equator, Combiner<X> Combiner, X Zero, Inverter<X> Inverter)
        {
            this.Equator = Equator;
            this.Combiner = Combiner;
            this.zero = Zero;
            this.Inverter = Inverter;            
        }

        /// <summary>
        /// Equality adjudicator
        /// </summary>
        Equator<X> Equator { get; }

        /// <summary>
        /// Associative group operation
        /// </summary>
        Combiner<X> Combiner { get; }

        /// <summary>
        /// Produces each element's inverse
        /// </summary>
        Inverter<X> Inverter { get; }

        /// <summary>
        /// The additive identity
        /// </summary>
        public X zero { get; }        

        public X combine(Seq<X> elements)
            => Seq.foldl(combine, elements);

        public X combine(params X[] values)
            => combine(Seq.make(values));

        public X combine(X x1, X x2)
           => Combiner(x1, x2);

        public bool eq(X x1, X x2)
            => Equator(x1, x2);

        public bool neq(X x1, X x2)
            => not(eq(x1, x2));

        /// <summary>
        /// Inverts a value
        /// </summary>
        /// <param name="x">The value to invert</param>
        /// <returns></returns>
        public X Invert(X x)
            => Inverter(x);

        /// <summary>
        /// Determines whether a value is the group identity
        /// </summary>
        /// <param name="x">The value to test</param>
        /// <returns></returns>
        public bool isZero(X x)
           => object.ReferenceEquals(x, zero);


        public override string ToString()
            => "Group" + embrace(typeof(X).Name);

    }
}