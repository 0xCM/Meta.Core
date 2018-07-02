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

    public readonly struct List<X> : IList<X>
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
            => l1.Equals(l2);

        public static bool operator !=(List<X> l1, List<X> l2)
            => not(l1.Equals(l2));

        public static ListFactory<X> Factory
            => items => new List<X>(items.ToImmutableList());

        internal List(ImmutableList<X> Value)
            => this.Data = Value;

        ImmutableList<X> Data { get; }

        public X this[int index]
            => Data[index];

        /// <summary>
        /// Retrieves an inclusive slice
        /// </summary>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        /// <returns></returns>
        public List<X> this[int minIdx, int maxIdx]            
            => minIdx >= maxIdx 
            ? Empty : new List<X>(Data.GetRange(minIdx, maxIdx - minIdx + 1));

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

        public G.IReadOnlyList<X> AsReadOnlyList()
            => Data;

        public override int GetHashCode()
            => Container.hash(this);

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
            => ListFormatter<X>.instance.Format(this);

        public Cardinality Cardinality
            => IsEmpty ? Cardinality.Zero : Cardinality.Finite;

        G.IEnumerable<X> IStreamable<X>.Stream()
            => Data;

        ContainerFactory<X, List<X>> IContainer<X, List<X>>.Factory
            => stream => new List<X>(stream.ToImmutableList());
        
            
    }
}