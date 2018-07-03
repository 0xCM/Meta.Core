//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

public static class BranchX
{
    /// <summary>
    /// Extracts the chosen values from the sequence
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <param name="choices">The value source</param>
    /// <returns></returns>
    public static Seq<V> Chosen<V>(this Seq<Choice<V>> choices)
        => choices.Select(c => c.Value);
}


