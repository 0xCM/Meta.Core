//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Constructs a <see cref="Map{K,V}"/> from a list of key-value pairs
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="entries"></param>
    /// <returns></returns>
    public static Map<K, V> kvMap<K, V>(params (K key, V value)[] entries)
        => Map.make(seq(entries));

    /// <summary>
    /// Constructs a <see cref="Map{K,V}"/> from a sequence of key-value pairs
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="entries"></param>
    /// <returns></returns>
    public static Map<K, V> kvMap<K, V>(Seq<(K key, V value)> entries)
        => Map.make(entries);


}

