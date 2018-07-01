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

    using static minicore;

    using Modules;

    /// <summary>
    /// Represents a possibly infinite sequence of items
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    public readonly struct Seq<X> : ISeq<X>, IEquatable<Seq<X>>, IEnumerable
    {

        /// <summary>
        /// The canonical factory
        /// </summary>
        public static SeqFactory<X> Factory
            => items => new Seq<X>(items);

        /// <summary>
        /// The canonical 0
        /// </summary>
        public static Seq<X> Empty 
            = new Seq<X>(stream<X>(), Cardinality.Zero);

        /// <summary>
        /// Implicitly constructs a sequence from an array
        /// </summary>
        /// <param name="Items"></param>
        public static implicit operator Seq<X>(X[] Items)
            => Seq.make(Items);

        /// <summary>
        /// Implicitly constructs an untyped sequence from a typed sequence
        /// </summary>
        /// <param name="index">The index to generalize</param>
        public static implicit operator Seq<object>(Seq<X> index)
            => Seq.make(index.Stream().Cast<object>());

        //public static List<X> operator !(Seq<X> input)
        //    => input;

        /// <summary>
        /// Concatenates the operands
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static Seq<X> operator +(Seq<X> s1, Seq<X> s2)
            => Seq.concat(s1, s2);

        /// <summary>
        /// Evaluates sequence equality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator ==(Seq<X> s1, Seq<X> s2)
            => Seq.eq(s1, s2);

        /// <summary>
        /// Evaluates sequence inequality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator !=(Seq<X> s1, Seq<X> s2)
            => Seq.neq(s1, s2);

        /// <summary>
        /// Defines the sequence implied by the stream
        /// </summary>
        /// <param name="Stream">The defining stream</param>
        /// <param name="Cardinality">The cardinality of the resulting sequence</param>
        public Seq(IEnumerable<X> Stream, Cardinality Cardinality = Cardinality.Finite)
        {
            this.Data = Stream;
            this.Cardinality = Cardinality;
        }

        /// <summary>
        /// Specifies 
        /// </summary>
        public Cardinality Cardinality { get; }

        /// <summary>
        /// The sequence data
        /// </summary>
        IEnumerable<X> Data { get; }

        /// <summary>
        /// Returns the underlying enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<X> Stream()
            => Data;

        /// <summary>
        /// True if the sequence is known to be bounded, false otherwise
        /// </summary>
        public bool IsBounded
            => Cardinality == Cardinality.Finite
            || Cardinality == Cardinality.Zero;

        /// <summary>
        /// True if the sequence is known to be empty, false otherwise
        /// </summary>
        /// <remarks>
        /// Note that the underlying eneumerable is not evaluated to adjudicate whether the
        /// sequence is emtpy
        /// </remarks>
        public bool IsEmpty
            => Cardinality == Cardinality.Zero;

        public override bool Equals(object obj)
            => obj is Seq<X> ? Seq.eq(this, (Seq<X>)obj) : false;

        public bool Equals(Seq<X> other)
            => Seq.eq(this, other);

        public override int GetHashCode()
            => Seq.hash(this);

        public override string ToString()
            => Seq.format(this);

        public Seq<X> Contained()
            => this;

        ContainerFactory<Y> IContainer<X>.Factory<Y>()
            => y => Seq.make(y);

        IEnumerator IEnumerable.GetEnumerator()
            => this.Data.GetEnumerator();
    }


 
}