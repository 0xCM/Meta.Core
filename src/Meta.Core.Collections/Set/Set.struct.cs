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

    using static minicore;

    /// <summary>
    /// Defines an immutable set
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct Set<X> : ISet<X>, IEnumerable
    {
        /// <summary>
        /// Defines the canonical empty sequence
        /// </summary>
        public static Set<X> Empty 
            = new Set<X>(ImmutableHashSet<X>.Empty);

        public static Func<Seq<X>, Set<X>> Factory
            => items => new Set<X>(ImmutableHashSet.CreateRange(items.Stream()));


        /// <summary>
        /// Implicitly transforms a set into a sequence
        /// </summary>
        /// <param name="set">The input set</param>
        public static implicit operator Seq<X>(Set<X> set)
            => new Seq<X>(set.Stream());

        /// <summary>
        /// Evaluates sequence equality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator ==(Set<X> s1, Set<X> s2)
            => s1.Equals(s2);

        /// <summary>
        /// Evaluates sequence inequality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator !=(Set<X> s1, Set<X> s2)
            => !s1.Equals(s2);

        /// <summary>
        /// Combines the operands
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static Set<X> operator +(Set<X> s1, Set<X> s2)
            => new Set<X>(s1.Stream().Concat(s2.Stream()).Distinct().ToImmutableHashSet());

        Set(ImmutableHashSet<X> Data)
            => this.Data = Data;

        /// <summary>
        /// The encapsulated data
        /// </summary>
        ImmutableHashSet<X> Data { get; }

        public Cardinality Cardinality
            => Data.IsEmpty ? Cardinality.Zero 
            : Cardinality.Finite;

        public IEnumerable<X> Stream()
            => Data;

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

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();

        public override int GetHashCode()
            => Data.GetHashCodeAggregate();

        public override bool Equals(object obj)
            => obj is Set<X> ? Equals((Set<X>)obj) : false;

        ContainerFactory<X, Set<X>> IContainer<X, Set<X>>.Factory
            => x => new Set<X>(x.ToImmutableHashSet());

        ContainerFactory<X> IContainer<X>.GetFactory()
            => stream => new Set<X>(stream.ToImmutableHashSet());

        public bool Equals(Set<X> other)
            => Data.IsSubsetOf(other.Data) 
            && other.Data.IsSubsetOf(Data);

        /// <summary>
        /// Specifies whether the set is empty
        /// </summary>
        public bool IsEmpty
            => Data.IsEmpty;

        /// <summary>
        /// Presents the data as a <see cref="IImmutableSet{T}"/>
        /// </summary>
        /// <returns></returns>
        public IImmutableSet<X> AsImmutableSet()
            => Data;

        Set<X> IContainer<X, Set<X>>.Empty
           => Empty;

        IContainer<Y> IContainer<X>.GetEmpty<Y>()
            => Set<Y>.Empty;

        IEnumerable IStreamable.Stream()
            => Stream();
    }
}