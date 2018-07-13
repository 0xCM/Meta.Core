//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;                

    using static minicore;

    /// <summary>
    /// Defines operations and structures over a <see cref="Map{K,V}"/>
    /// </summary>
    /// <remarks>
    /// The exposed API is somewhat consistent with http://hackage.haskell.org/package/containers-0.5.11.0/docs/Data-Map-Strict.html
    /// </remarks>
    public class Map : FactoredDataModule<Map, IMap>
    {

        public Map()
            : base(typeof(Map<,>))
        { }

        /// <summary>
        /// Constructs a map from a sequence of key-value pairs
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="entries">The keyed values</param>
        /// <returns></returns>
        public static Map<K, V> make<K, V>(Seq<(K, V)> entries)
            => Map<K, V>.Factory(entries);

        /// <summary>
        /// Constructs a map from an array of key-value pairs
        /// </summary>
        public static Map<K, V> cons<K, V>(params (K key, V value)[] kv)
            => make(Seq.make(kv));

        /// <summary>
        /// Returns the canonical 0
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <returns></returns>
        public static Map<K, V> zero<K, V>()
            => Map<K, V>.Empty;

        /// <summary>
        /// The canonical deconstructor
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="map">The map to deconstruct</param>
        /// <returns></returns>
        public static Seq<(K, V)> devolve<K, V>(Map<K, V> map)
            => Seq.make(map.Stream());        

        /// <summary>
        /// Searches for a value by its key, returning it if found; 
        /// otherwise, returns None
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="key">The key value</param>
        /// <param name="map">The map to search</param>
        /// <returns></returns>
        public static Option<V> lookup<K, V>(K key, Map<K, V> map)
            => map[key];

        /// <summary>
        /// Searches for a value by its key, returning it if found; 
        /// otherwise, returns a default value
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="key">The key value</param>
        /// <param name="map">The map to search</param>
        /// <returns></returns>
        public static V find<K, V>(K key, Map<K, V> map, V @default)
            => map.Value(key).ValueOrDefault(@default);

        /// <summary>
        /// Searches for a value by its key, returning it if found; 
        /// otherwise, raises an exception
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="key">The key value</param>
        /// <param name="map">The map to search</param>
        /// <returns></returns>
        public static V require<K, V>(K key, Map<K, V> map)
            => map[key];

        /// <summary>
        /// Returns the number of assoicated pairs
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="map">The map to analyze</param>
        /// <returns></returns>
        public static int size<K, V>(Map<K, V> map)
            => map.Count;

        /// <summary>
        /// Returns true if the map is empty, false otherwise
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="map">The map to analyze</param>
        /// <returns></returns>
        public static bool empty<K, V>(Map<K, V> map)
            => size(map) == 0;

        /// <summary>
        /// Returns true if the map contains a specified key, false otherwise
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="key">The key on which the search is predicated</param>
        /// <param name="map">The map to search</param>
        /// <returns></returns>
        public static bool hasKey<K, V>(K key, Map<K, V> map)
           => map.ContainsKey(key);

        /// <summary>
        /// Returns true if the map contains a specified value, false otherwise
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="value">The value on which the search is predicated</param>
        /// <param name="map">The map to search</param>
        /// <returns></returns>
        public static bool hasValue<K, V>(V value, Map<K, V> map)
           => map.HasValue(value);
       
        /// <summary>
        /// Applies a function to a map
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="f"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Map<S,T> map<K,V,S,T>(Func<(K,V),(S,T)> f, Map<K,V> data)
            => make(Seq.make(from x in data.Stream() select f(x)));

        /// <summary>
        /// Successively concatenates an arbitrary number of maps and will
        /// fail if there are duplicate keys among the supplied maps
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="maps">The maps to combine</param>
        /// <returns></returns>
        public static Map<K, V> chain<K, V>(params Map<K, V>[] maps)
            => Seq.make(from m in maps
                          from kv in m.Stream()
                          select kv);

        /// <summary>
        /// Concatenates two maps to produce another
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="m1">A map</param>
        /// <param name="m2">Another map</param>
        /// <returns></returns>
        public static Map<K, V> concat<K, V>(Map<K, V> m1, Map<K, V> m2)
            => chain(m1, m2);
    }
}