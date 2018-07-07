//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Defines a <see cref="ISemigroup"/> instance predicated on a supplied equator and combier
    /// </summary>
    /// <typeparam name="X">The semigroup element type</typeparam>
    public readonly struct Semigroup<X> : ISemigroup<X>
    {

        public Semigroup(Equator<X> Equator, Combiner<X> Combiner)
        {
            this.Equator = Equator;
            this.Combiner = Combiner;
        }


        Equator<X> Equator { get; }

        Combiner<X> Combiner { get; }

        public X combine(X a1, X a2)
            => Combiner(a1, a2);


        public bool eq(X x1, X x2)
            => Equator(x1, x2);


        public bool neq(X x1, X x2)
            => !Equator(x1, x2);


        public override string ToString()
            => $"Semigroup<{typeof(X).Name}>";
    }

    partial class classops
    {

        /// <summary>
        /// Associative binary operation over a <see cref="ISemigroup"/> 
        /// </summary>
        public readonly struct plus : IClassOp<plus>
        {
            public static readonly plus op = default;
            public const string S = "<>";
        }
    }

}