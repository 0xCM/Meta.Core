//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Modules;

    using static metacore;

    /// <summary>
    /// A universal monad logically equivalent to a singleton sequence
    /// </summary>
    /// <typeparam name="X">The type of the lifted value</typeparam>
    public readonly struct Value<X> : IValue<X>
    {


        public static readonly Value<X> Empty = default;

        /// <summary>
        /// Extracts encapsualted content
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static X operator ~(Value<X> x)
            => x.Data;

        public static X operator +(Value<X> x1, Value<X> x2)
            => operators.add(x1.Data, x2.Data);

        public static X operator -(Value<X> x1, Value<X> x2)
            => operators.sub(x1.Data, x2.Data);

        public static X operator *(Value<X> x1, Value<X> x2)
            => operators.mul(x1.Data, x2.Data);

        /// <summary>
        /// Content-Value lift
        /// </summary>
        /// <param name="Content"></param>
        public static implicit operator Value<X>(X Content)
            => new Value<X>(Content);

        /// <summary>
        /// Value-Content descent
        /// </summary>
        /// <param name="Value"></param>
        public static implicit operator X(Value<X> Value)
            => Value.Data;

        /// <summary>
        /// Tests equality via encapsulated content equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Value<X> a, Value<X> b)
            => a.Data.Equals(b.Data);

        /// <summary>
        /// Tests inequality via encapsulated content equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Value<X> a, Value<X> b)
            => not(a.Data.Equals(b.Data));

        public Value(X Content)
            => this.Data = Content;

        /// <summary>
        /// The encapsulated value
        /// </summary>
        public X Data { get; }

        public Cardinality Cardinality
            => Cardinality.Finite;

        public ContainerFactory<X, Value<X>> Factory
            => stream => new Value<X>(stream.Single());

        public Seq<X> Contained()
            => Seq.cons(Data);

        IEnumerable<X> IStreamable<X>.Stream()
            => stream(Data);

        public bool Equals(Value<X> other)
            => Equals(Data, other.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object obj)
            => (obj is Value<X>) ? Equals((Value<X>)obj) : false;

        Value<X> IContainer<X, Value<X>>.Empty
           => Empty;

        IContainer<Y> IContainer<X>.GetEmpty<Y>()
                => Value<Y>.Empty;

        ContainerFactory<X> IContainer<X>.GetFactory()
           => x => new Value<X>(x.Single());

        IEnumerable IStreamable.Stream()
            => stream(Data);
    }


}