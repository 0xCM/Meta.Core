//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
    /// Defines an immutable key-sorted assoiciative array
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public readonly struct SortedMap<K, V> : IMap<K,V>, IEnumerable
    {
        /// <summary>
        /// A factory that constructs a <see cref="Map{K, V}"/> instance from
        /// a sequence of key-value pairs
        /// </summary>
        public static Func<IEnumerable<(K, V)>, IComparer<K>, SortedMap<K, V>> Factory
            => (items, comparer) => new SortedMap<K, V>(items, comparer);

        /// <summary>
        /// The encapsulated associative array
        /// </summary>
        ImmutableSortedDictionary<K, V> Data { get; }

        public Cardinality Cardinality
            => Data.Keys.Count() == 0
            ? Cardinality.Zero : Cardinality.Finite;

        internal SortedMap(ImmutableSortedDictionary<K, V> Data)
            => this.Data = Data;

        SortedMap(IEnumerable<(K, V)> Pairs, IComparer<K> Comparer)
            => Data = Pairs.ToDictionary(x => x.Item1, x => x.Item2).ToImmutableSortedDictionary(Comparer);

        public bool ContainsKey(K Key)
            => Data.ContainsKey(Key);

        public bool HasValue(V Value)            
            => Data.ContainsValue(Value);

        public Option<V> Value(K Key)
            => Data.TryGetValue(Key, out V value) ?
                    some(value) : none<V>();

        /// <summary>
        /// Retrieves the value indexed by a specified key if it exists; otherwise, returns none
        /// </summary>
        /// <param name="key">The key to match</param>
        /// <returns></returns>
        public V this[K key]
            => Data[key];

        public bool Equals(Map<K, V> other)
            => throw new NotImplementedException();

        public int Count
            => Data.Count;

        /// <summary>
        /// Presents the contained data as a sequence
        /// </summary>
        /// <returns></returns>
        public Seq<(K, V)> Contained()
            => Seq.make(Stream());

        public IEnumerable<(K, V)> Stream()
            => Data.Select(x => (x.Key, x.Value));

        public IFactoredContainer<Y1, Y2> Recontain<Y1, Y2>(Func<(K, V), (Y1, Y2)> map)
            => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator()
            => Stream().GetEnumerator();

        IEnumerable IStreamable.Stream()
            => Stream();
    }

}