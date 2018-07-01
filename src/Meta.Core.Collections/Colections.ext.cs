//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;

    using System.Collections;
    using G = System.Collections.Generic;

    using Modules;

    public static class CollectionX
    {
        /// <summary>
        /// Creates a list from a stream
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="source">The source stream</param>
        /// <returns></returns>
        public static List<X> AsList<X>(this G.IEnumerable<X> source)
            => List.make(source);

        /// <summary>
        /// Creates a list via sequence evaluation
        /// </summary>
        /// <typeparam name="X">The sequence item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static List<X> AsList<X>(this Seq<X> s)
            => s;

        /// <summary>
        /// Creates a sequence from a list
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Seq<X> AsSeq<X>(this List<X> l)
            => l;

        /// <summary>
        /// Creates an index from a list
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l">The input list</param>
        /// <returns></returns>
        public static Index<X> AsIndex<X>(this Seq<X> l)
            => l;

        /// <summary>
        /// Creates an index from a list
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l">The input list</param>
        /// <returns></returns>
        public static Index<X> AsIndex<X>(this List<X> l)
            => l; //Index.make(l.Contained());

        /// <summary>
        /// Presents the list as a streamable
        /// </summary>
        /// <returns></returns>
        public static Streamable<X> AsStreamable<X>(this List<X> list)
            => List.Streamable(list);

        /// <summary>
        /// Constructs a map from a sequence of 2-tuples
        /// </summary>
        /// <typeparam name="X">The type of the first coordinate</typeparam>
        /// <typeparam name="Y">The type of the second coordinate</typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Map<X, Y> AsMap<X, Y>(this Seq<(X, Y)> items)
            => Map.make(items);

        /// <summary>
        /// Creates a map from a list and key selection function
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="K">The key type</typeparam>
        /// <param name="s"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static Map<K, X> AsMap<X, K>(this List<X> s, Func<X, K> keySelector)
            => Map.make<K, X>(from item in s select (keySelector(item), item));

        /// <summary>
        /// Creates a map given a sequence and key selection function
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="s"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static Map<K, X> AsMap<X, K>(this Seq<X> s, Func<X, K> keySelector)
            => Map.make(from item in s select (keySelector(item), item));

        /// <summary>
        /// Returns the keyed value, if found; otherwise, None
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="map">The map to search</param>
        /// <param name="key">The search key</param>
        /// <returns></returns>
        public static Option<V> TryFind<K, V>(this Map<K, V> map, K key)
            => map.TryGetValue(key, out V value) ?
                    value : none<V>();

        /// <summary>
        /// Generalizes the input sequence
        /// </summary>
        /// <typeparam name="X">The input item type</typeparam>
        /// <typeparam name="Y">The output item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Seq<Y> Weaken<X, Y>(this Seq<X> s)
            where Y : class
            where X : Y
                => Seq.weaken<X, Y>(s);

    }

}