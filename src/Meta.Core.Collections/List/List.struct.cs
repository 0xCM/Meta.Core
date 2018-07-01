//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;    
    using System.Collections;
    using System.Collections.Immutable;

    using G = System.Collections.Generic;

    using static minicore;

    using Modules;

    public readonly struct List<X> : IList<X>, IEquatable<List<X>>
    {        
        /// <summary>
        /// The canonical 0
        /// </summary>
        public static readonly List<X> Empty
            = new List<X>(ImmutableList<X>.Empty);

        public static implicit operator Seq<X>(List<X> list)
            => list.Contained();

        public static implicit operator List<X>(Seq<X> s)
            => Factory(s.Stream());

        public static implicit operator Streamable<X>(List<X> list)
            => list.AsStreamable();

        public static implicit operator List<X>(X[] items)
            => Factory(items);

        public static implicit operator X[](List<X> list)
            => list.Data.ToArray();

        public static List<X> operator +(List<X> l1, List<X> l2)
            => Factory(l1.Stream().Concat(l2.Stream()));

        public static bool operator ==(List<X> l1, List<X> l2)
            => List.eq(l1, l2);

        public static bool operator !=(List<X> l1, List<X> l2)
            => List.neq(l1, l2);

        public static ListFactory<X> Factory
            => items => new List<X>(items.ToImmutableList());

        internal List(ImmutableList<X> Value)
            => this.Data = Value;

        ImmutableList<X> Data { get; }


        public X this[int index]
            => Data[index];

        public int Count
            => Data.Count;

        public G.IEnumerable<X> Stream()
            => Data;

        public bool IsEmpty
            => this.Count == 0;

        /// <summary>
        /// Presents the contained data as a sequence
        /// </summary>
        /// <returns></returns>
        public Seq<X> Contained()
            => Seq.make(Data);

        public override int GetHashCode()
            => List.hash(this);

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case List<X> other:
                    return List.eq(this, other);
                default:
                    return false;
            }
        }

        public bool Equals(List<X> other)
            => ListEquator<X>.instance(this, other);

        public override string ToString()
            => List.format(this);

        ContainerFactory<Y> IContainer<X>.Factory<Y>()
            => source => List.make(source);

        public Cardinality Cardinality
            => IsEmpty ? Cardinality.Zero : Cardinality.Finite;

        Seq<X> IContainer<X>.Contained()
            => Seq.make(Data);

        G.IEnumerable<X> IStreamable<X>.Stream()
            => Data;

    }
}