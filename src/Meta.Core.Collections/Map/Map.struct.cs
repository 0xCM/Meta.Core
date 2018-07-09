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
    /// Defines an immutable assoiciative array
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public readonly struct Map<K, V> : IMap<K, V>, IEquatable<Map<K, V>>
    {
        /// <summary>
        /// The empty map over K,V
        /// </summary>
        public static readonly Map<K, V> Empty
            = Factory(Seq.empty<(K, V)>());

        /// <summary>
        /// Implicitly constructs a map from a sequence of keyed values
        /// </summary>
        /// <param name="items"></param>
        public static implicit operator Map<K, V>(Seq<(K, V)> items)
            => Factory(items);

        /// <summary>
        /// A factory that constructs a <see cref="Map{K, V}"/> instance from
        /// a sequence of key-value pairs
        /// </summary>
        public static Func<Seq<(K, V)>, Map<K, V>> Factory
            => items => new Map<K, V>(items);

        Map(Seq<(K, V)> Pairs)
        {
            var init = ImmutableDictionary<K, V>.Empty;            
            iter(Pairs.Stream(), p => init.Add(p.Item1, p.Item2));
            Data = init;
        }

        /// <summary>
        /// The encapsulated associative array
        /// </summary>
        ImmutableDictionary<K, V> Data { get; }


        /// <summary>
        /// Retrieves the value indexed by a specified key if it exists; otherwise, returns None
        /// </summary>
        /// <param name="key">The key to match</param>
        /// <returns></returns>
        public Option<V> Value(K key)
            => Data.TryGetValue(key, out V value) ?
                    some(value) : none<V>();

        /// <summary>
        /// Retrieves the value indexed by a specified key if it exists; otherwise, raises and error
        /// </summary>
        /// <param name="key">The key to match</param>
        /// <returns></returns>
        public V this[K key]
            => Data[key];

        public bool Equals(Map<K, V> other)
            => throw new NotImplementedException();

        /// <summary>
        /// Specifies the item entry count
        /// </summary>
        public int Count
            => Data.Count;

        /// <summary>
        /// Determines whether a specfied key has an entry
        /// </summary>
        /// <param name="key">The key to evaluate</param>
        /// <returns></returns>
        public bool ContainsKey(K key)
            => Data.ContainsKey(key);

        /// <summary>
        /// Determines whether a specified value is indexed
        /// </summary>
        /// <param name="value">The key to evaluate</param>
        /// <returns></returns>
        public bool HasValue(V value)
            => Data.ContainsValue(value);

        public Cardinality Cardinality
            => Data.Keys.Count() == 0 
            ? Cardinality.Zero : Cardinality.Finite;

        /// <summary>
        /// Populates the output value and returns true if found; otherwise, 
        /// sets teh output value to the default and returns false
        /// </summary>
        /// <param name="key">The search key</param>
        /// <param name="value">The value, if found</param>
        /// <returns></returns>
        public bool TryGetValue(K key, out V value)
        {
            value = default;
            return Data.TryGetValue(key, out value);                
        }


        /// <summary>
        /// Presents the contained data as a tuplestream (TM)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(K, V)> Stream()
            => Data.Select(x => (x.Key, x.Value));

        public SortedMap<K, V> Sort(IComparer<K> comparer)
            => new SortedMap<K, V>(Data.ToImmutableSortedDictionary(comparer));

        public IFactoredContainer<Y1, Y2> Recontain<Y1, Y2>(Func<(K, V), (Y1, Y2)> f)
            => Map.map(f, this);

        IEnumerable IStreamable.Stream()
            => Stream();
    }

}