﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    using Meta.Core.Modules;

    /// <summary>
    /// An immutable array
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    public readonly struct Index<X> : IIndex<X> 
    {
        /// <summary>
        /// Constructs a <see cref="Index{X}"/> from a native array
        /// </summary>
        /// <param name="items"></param>
        public static implicit operator Index<X>(X[] items)
            => FromArray(items);

        /// <summary>
        /// Constructs a <see cref="Seq{X}"/> from an index
        /// </summary>
        /// <param name="index"></param>
        public static implicit operator Seq<X>(Index<X> index)
            => Seq.make(index.Stream());

        /// <summary>
        /// Constructs a <see cref="Index{X}"/> from a <see cref="List{X}"/>
        /// </summary>
        /// <param name="list"></param>
        public static implicit operator Index<X>(List<X> list)
            => new Index<X>(list.Stream().ToImmutableArray());

        /// <summary>
        /// Constructs an untyped index from a typed index
        /// </summary>
        /// <param name="index">The index to generalize</param>
        public static implicit operator Index<object>(Index<X> index)
            => Seq.make(index.Stream().Cast<object>());

        /// <summary>
        /// Creates an index from an array
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Index<X> FromArray(X[] items)
            => new Index<X>(ImmutableArray.Create(items));
        
        /// <summary>
        /// Defines the canonical empty sequence
        /// </summary>
        public static Index<X> Empty = 
            new Index<X>(ImmutableArray<X>.Empty);

        /// <summary>
        /// Returns the canonical index factory
        /// </summary>
        public static Func<Seq<X>, Index<X>> Factory
            => items => new Index<X>(ImmutableArray.CreateRange(items.Stream()));

        /// <summary>
        /// Implicitly converts an item sequence to an indexed sequence
        /// </summary>
        /// <param name="s">the sequence to convert</param>
        public static implicit operator Index<X>(Seq<X> s)
            => Index.make(s);

        /// <summary>
        /// Concatenates the operands to create a new index
        /// </summary>
        /// <param name="s1">The first index</param>
        /// <param name="s2">The second index</param>
        /// <returns></returns>
        public static Index<X> operator +(Index<X> s1, Index<X> s2)
            => Index.chain(s1, s2);

        Index(ImmutableArray<X> Data)
            => this.Data = Data;            

        /// <summary>
        /// The backing store
        /// </summary>
        ImmutableArray<X> Data { get; }

        public Cardinality Cardinality
            => Data.IsEmpty ? Cardinality.Zero : Cardinality.Finite;

        /// <summary>
        /// Retrieves the value stored at a specified index position
        /// </summary>
        /// <param name="idx">The zero-based position</param>
        /// <exception cref="IndexOutOfRangeException"/>
        /// <returns></returns>
        public X this[int idx]
            => Data[idx];

        /// <summary>
        /// Presents the contained data as a stream
        /// </summary>
        /// <returns></returns>
        public IEnumerable<X> Stream()
            => Data;

        /// <summary>
        /// Presents the contained data as a sequence
        /// </summary>
        /// <returns></returns>
        public Seq<X> Contained()
            => Seq.make(Data);
        
        /// <summary>
        /// Specifies the number of indexed elements
        /// </summary>
        public int Count
            => Data.Length;

        /// <summary>
        /// Determines whether the item exists in the index
        /// </summary>
        /// <param name="item">The item to match</param>
        /// <returns></returns>
        public bool Contains(X item)
            => Data.Contains(item);

        /// <summary>
        /// Presents the index as a tuple-stream
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(int i, X item)> TupleStream()
        {
            for (var k = 0; k < Count; k++)
                yield return (k, Data[k]);
        }

        ContainerFactory<Y> IContainer<X>.Factory<Y>()
            => y => Index.make(Seq.make(y));
    }
}