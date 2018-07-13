//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System.Collections.Concurrent;

    
    
    /// <summary>
    /// A concurrently accessible set based
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    public sealed class ConcurrentSet<T> : IMutableSet<T>
    {
        ConcurrentDictionary<T, T> items { get; }

        public ConcurrentSet()
            => items = new ConcurrentDictionary<T, T>();

        public ConcurrentSet(IEqualityComparer<T> comparer)
            => items = new ConcurrentDictionary<T, T>(comparer);

        public ConcurrentSet(IEnumerable<T> items)
            : this()
                => items.Iterate(i => this.items.TryAdd(i, i));

        public ConcurrentSet(IEnumerable<T> items, IEqualityComparer<T> comparer)
            : this(comparer)
            => items.Iterate(i => this.items.TryAdd(i, i));


        public int Count
            => items.Count;

        public bool IsReadOnly
            => false;

        public bool Add(T item)
          => items.TryAdd(item, item);

        public void Clear()
            => items.Clear();

        public bool Contains(T item)
            => items.ContainsKey(item);

        public void CopyTo(T[] array, int arrayIndex)
            => items.Keys.CopyTo(array, arrayIndex);

        public void ExceptWith(IEnumerable<T> other)
            => other.Iterate(o => items.TryRemove(o));

        public IEnumerator<T> GetEnumerator()
            => items.Keys.GetEnumerator();

        public void IntersectWith(IEnumerable<T> other)
        {
            var x = new HashSet<T>(items.Keys);
            var y = new HashSet<T>(other);
            var intersection = x.Intersect(y);
            var removals = x.Except(intersection);
            removals.Iterate(removal => items.TryRemove(removal));
            foreach (var i in intersection)
                items.TryAdd(i, i);

        }
        public bool IsProperSubsetOf(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).IsSupersetOf(other);

        public bool Overlaps(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).Overlaps(other);

        public Option<T> Remove(T item)
            => items.TryRemove(item);

        public bool SetEquals(IEnumerable<T> other)
            => new HashSet<T>(items.Keys).SetEquals(other);

        public void SymmetricExceptWith(IEnumerable<T> other)        
            => throw new NotImplementedException();        

        public void UnionWith(IEnumerable<T> other)
            => other.Iterate( o => items.TryAdd(o, o));

        void ICollection<T>.Add(T item)
            => items.TryAdd(item, item);

        IEnumerator IEnumerable.GetEnumerator()
            => items.Keys.GetEnumerator();

        bool ICollection<T>.Remove(T item)
            => Remove(item).IsSome();
    }
}