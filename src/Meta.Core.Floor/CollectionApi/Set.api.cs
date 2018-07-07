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
    /// Constructs a set from an array of items
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static Set<X> set<X>(params X[] values)
        => Set.make(values);

    /// <summary>
    /// Constructs a set from a sequence
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="s">The soruce sequence</param>
    /// <returns></returns>
    public static Set<X> set<X>(Seq<X> s)
        => Set.make(s);

    /// <summary>
    /// Constructs a set from a stream
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="stream">The source stream</param>
    /// <returns></returns>
    public static Set<X> set<X>(IEnumerable<X> stream)
        => Set.make(stream);

}