//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using G = System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Meta.Core;


    public static class ReadOnlySet
    {
        public static ReadOnlySet<T> Create<T>(params G.IEnumerable<T>[] sequences)
        {
            var list = MutableList.Create<T>();
            sequences.Where(s => s != null).Iterate(s => list.AddRange(s));
            return new ReadOnlySet<T>(list);
        }

        public static ReadOnlySet<T> Create<T>(MutableList<T> items)
            => new ReadOnlySet<T>(items);

        public static ReadOnlySet<T> Create<T>(T[] items)
            => new ReadOnlySet<T>(items ?? new T[] { });
    }

    public class ReadOnlySet<T> : IReadOnlySet<T>
    {
        public static implicit operator ReadOnlySet<T>(T[] items)
            => new ReadOnlySet<T>(items);

        public static implicit operator ReadOnlySet<T>(G.List<T> items)
            => new ReadOnlySet<T>(items);

        public static implicit operator ReadOnlySet<T>(ReadOnlyList<T> items)
            => new ReadOnlySet<T>(items);

        public static readonly ReadOnlySet<T> Empty
            = new ReadOnlySet<T>(new T[] { });

        public ReadOnlySet(G.IEnumerable<T> items)
            => Data = items.ToImmutableHashSet();

        public ReadOnlySet(T[] items)
            => Data = items.ToImmutableHashSet();

        ImmutableHashSet<T> Data { get; }

        public int Count
            => Data.Count;

        public bool Contains(T item)
            => Data.Contains(item);

        public G.IEnumerator<T> GetEnumerator()
            => Data.GetEnumerator();

        public bool IsProperSubsetOf(G.IEnumerable<T> other)
            => Data.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(G.IEnumerable<T> other)
            => Data.IsProperSupersetOf(other);

        public bool IsSubsetOf(G.IEnumerable<T> other)
            => Data.IsSubsetOf(other);

        public bool IsSupersetOf(G.IEnumerable<T> other)
            => Data.IsSupersetOf(other);

        public bool Overlaps(G.IEnumerable<T> other)
            => Data.Overlaps(other);

        public bool SetEquals(G.IEnumerable<T> other)
            => Data.SetEquals(other);

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();

        public ReadOnlySet<T> Intersect(G.IEnumerable<T> other)
            => new ReadOnlySet<T>(Data.Intersect(other));

        public ReadOnlySet<T> Union(G.IEnumerable<T> other)
            => new ReadOnlySet<T>(Data.Union(other));
    }
}