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
    public readonly struct Seq<X> : ISeq<X>, IEnumerable
    {
        /// <summary>
        /// The canonical 0
        /// </summary>
        public static Seq<X> Empty
            = new Seq<X>(stream<X>(), Cardinality.Zero);

        /// <summary>
        /// The canonical factory
        /// </summary>
        public static SeqFactory<X> Factory
            => items => new Seq<X>(items);

        /// <summary>
        /// Implicitly constructs a sequence from an array
        /// </summary>
        /// <param name="Items"></param>
        public static implicit operator Seq<X>(X[] Items)
            => new Seq<X>(Items);

        /// <summary>
        /// Implicitly constructs an untyped sequence from a typed sequence
        /// </summary>
        /// <param name="index">The index to generalize</param>
        public static implicit operator Seq<object>(Seq<X> index)
            => Seq.make(index.Stream().Cast<object>());

        /// <summary>
        /// Implicitly constructs a an array from a sequence
        /// </summary>
        /// <param name="Items"></param>
        public static implicit operator X[](Seq<X> s)
            => s.Stream().ToArray();

        /// <summary>
        /// Implicitly constructs a an readonly list from a sequence
        /// </summary>
        /// <param name="Items"></param>
        public static implicit operator ReadOnlyList<X> (Seq<X> s)
            => new ReadOnlyList<X>(s.Stream());

        /// <summary>
        /// Evaluates sequence equality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator ==(Seq<X> s1, Seq<X> s2)
            => s1.Equals(s2);

        /// <summary>
        /// Evaluates sequence inequality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator !=(Seq<X> s1, Seq<X> s2)
            => not(s1.Equals(s2));

        /// <summary>
        /// Concatenates the operands
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static Seq<X> operator +(Seq<X> s1, Seq<X> s2)
            => new Seq<X>(s1.Stream().Concat(s2.Stream()));

        /// <summary>
        /// Defines the sequence implied by the stream
        /// </summary>
        /// <param name="Stream">The defining stream</param>
        /// <param name="Cardinality">The cardinality of the resulting sequence</param>
        public Seq(IEnumerable<X> Stream, Cardinality Cardinality = Cardinality.Unknown)
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
        /// True if the sequence is known to be unbounded, false otherwise
        /// </summary>
        public bool IsUnbounded
            => Cardinality == Cardinality.Infinite;

        /// <summary>
        /// True if the sequence is known to be empty, false otherwise
        /// </summary>
        /// <remarks>
        /// Note that the underlying eneumerable is not evaluated to adjudicate whether the
        /// sequence is emtpy
        /// </remarks>
        public bool IsEmpty
            => Cardinality == Cardinality.Zero;

        ContainerFactory<X, Seq<X>> IContainer<X, Seq<X>>.Factory
             => source => new Seq<X>(source);

        ContainerFactory<X> IContainer<X>.GetFactory()
             => stream => new Seq<X>(stream);

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();

        Seq<X> IContainer<X, Seq<X>>.Empty
            => Empty;

        IContainer<Y> IContainer<X>.GetEmpty<Y>()
            => Seq<Y>.Empty;

        public override bool Equals(object obj)
            => obj is Seq<X> ? Seq.eq(this, (Seq<X>)obj) : false;

        public bool Equals(Seq<X> other)
            => SeqEquator<X>.instance(this, other);

        public override int GetHashCode()
        {
            if (IsEmpty)
                return 0;

            if (IsUnbounded)
                return -1;

            return Container.hash(this);
        }

        public override string ToString()
            => SeqFormatter<X>.instance.Format(this);

        IEnumerable IStreamable.Stream()
            => Stream();

        public Seq<Y> Cast<Y>()
            => from item in this
               select cast<Y>(item);

        public Option<TypeConstruction> ConstructType(params Type[] args)
            => new TypeConstructor(typeof(Seq<>)).Construct(args);

    }

}