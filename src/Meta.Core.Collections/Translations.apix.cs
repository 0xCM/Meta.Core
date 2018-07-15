//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static minicore;
      
    using Modules;

    /// <summary>
    /// Defines collection conversion operations/reinterpreters
    /// </summary>
    public static class TranslationsX
    {
        /// <summary>
        /// Creates a list from a stream
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="source">The source stream</param>
        /// <returns></returns>
        public static Lst<X> AsList<X>(this IEnumerable<X> source)
            => Lst.make(source);

        /// <summary>
        /// Creates a list via sequence evaluation
        /// </summary>
        /// <typeparam name="X">The sequence item type</typeparam>
        /// <param name="s">The input sequence</param>
        /// <returns></returns>
        public static Lst<X> AsList<X>(this Seq<X> s)
            => s;

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
        public static Map<K, X> AsMap<X, K>(this Lst<X> s, Func<X, K> keySelector)
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
        public static Seq<Y> Upcast<X, Y>(this Seq<X> s)
            where Y : class
            where X : Y
                => Seq.weaken<X, Y>(s);

        /// <summary>
        /// Presents a container of elements as a Seq
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="source">The data source</param>
        /// <returns></returns>
        public static Seq<X> AsSeq<X>(this IContainer<X> source)
            => Seq.make(source.Stream());

        /// <summary>
        /// Presents a container of elements as a Seq
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="source">The data source</param>
        /// <returns></returns>
        public static Lst<X> AsList<X>(this IContainer<X> source)
            => Lst.make(source.Stream());

        /// <summary>
        /// Presents a container of elements as an Index
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="source">The data source</param>
        /// <returns></returns>
        public static Index<X> AsIndex<X>(this IContainer<X> source)
            => Index.make(source.Stream());

        /// <summary>
        /// Presents a container of elements as an array
        /// </summary>
        /// <typeparam name="X">The element type</typeparam>
        /// <param name="source">The data source</param>
        /// <returns></returns>
        public static X[] AsArray<X>(this IContainer<X> source)
            => source.Stream().ToArray();

        /// <summary>
        /// Converts a map to a readonly dictionary
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<K, V>(this Map<K, V> map)
            => dict(map.Stream().Select(x => (x.Item1, x.Item2)));

        /// <summary>
        /// Converts a map to a readonly dictionary
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public static IReadOnlyDictionary<K, V> ToReadOnlyDictionary<K, V>(this Seq<(K key, V value)> map)
            => dict(map.Stream().Select(x => (x.key, x.value)));

        /// <summary>
        /// Determines whether a specified type is a closed Lst type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static bool IsLst(this Type t)
            => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Lst<>);

        /// <summary>
        /// Determines whether a specified type is a closed Index type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static bool IsIndex(this Type t)
            => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Index<>);

        /// <summary>
        /// Determines whether a specified type is a closed Seq type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static bool IsSeq(this Type t)
            => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Seq<>);

        /// <summary>
        /// Determines whether a specified type is a closed Map type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static bool IsMap(this Type t)
            => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Map<,>);

        /// <summary>
        /// Determines whether a specified type is a closed Set type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <returns></returns>
        public static bool IsSet(this Type t)
            => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(Set<>);

    }

}