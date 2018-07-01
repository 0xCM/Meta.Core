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

    public interface IMap : IContainer
    {

    }

    public interface IMap<K, V> : IMap, IFactoredContainer<K,V>
    {
        /// <summary>
        /// Looks up a value by key, returning the value if found; otherwise raises an exception
        /// </summary>
        /// <param name="key">The key to match</param>
        /// <returns></returns>
        V this[K key] { get; }


        /// <summary>
        /// Retrieves the value indexed by a specified key if it exists; otherwise, returns None
        /// </summary>
        /// <param name="key">The key to match</param>
        /// <returns></returns>
        Option<V> Value(K key);

        /// <summary>
        /// Specifies the item entry count
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Determines whether a specfied key has an entry
        /// </summary>
        /// <param name="key">The key to evaluate</param>
        /// <returns></returns>
        bool ContainsKey(K key);

        /// <summary>
        /// Determines whether a specified value is indexed
        /// </summary>
        /// <param name="value">The key to evaluate</param>
        /// <returns></returns>
        bool HasValue(V value);        

    }

}