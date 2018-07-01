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
    using System.Collections.Generic;
    using System.Collections.Immutable;

    using Modules;

    /// <summary>
    /// Defines an immutable set
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct Set<X> : ISet<X>, IEnumerable
    {
        /// <summary>
        /// Defines the canonical empty sequence
        /// </summary>
        public static Set<X> Empty = new Set<X>(ImmutableHashSet<X>.Empty);

        public static Func<Seq<X>, Set<X>> Factory
            => items => new Set<X>(ImmutableHashSet.CreateRange(items.Stream()));

        Set(ImmutableHashSet<X> Data)
        {
            this.Data = Data;
        }

        ImmutableHashSet<X> Data { get; }

        public Cardinality Cardinality
            => Data.IsEmpty ? Cardinality.Zero : Cardinality.Finite;

        public IEnumerable<X> Stream()
            => Data;

        public Seq<X> AsSequence()
            => Seq.make(Data);

        public Seq<X> Contained()
            => Seq.make(Data);

        public bool IsProperSubsetOf(ISet<X> other)
            => Data.IsProperSubsetOf(other.Stream());

        public bool IsProperSupersetOf(ISet<X> other)
            => Data.IsProperSupersetOf(other.Stream());

        public bool IsSubsetOf(ISet<X> other)
            => Data.IsSubsetOf(other.Stream());

        public bool IsSupersetOf(ISet<X> other)
            => Data.IsSupersetOf(other.Stream());

        public bool Overlaps(ISet<X> other)
            => Data.Overlaps(other.Stream());

        public bool SetEquals(ISet<X> other)
            => Data.SetEquals(other.Stream());

        public bool Contains(X item)
            => Data.Contains(item);

        ContainerFactory<Y> IContainer<X>.Factory<Y>()
            => y => Set.make(y);

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();
    }
}