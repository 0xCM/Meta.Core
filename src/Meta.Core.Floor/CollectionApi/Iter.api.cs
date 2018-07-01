//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using Meta.Core;
using System.Collections.Generic;
using System.Linq;

partial class metacore
{
    /// <summary>
    /// Iterates over items sequentially or in parallel, invokes the supplied action for each one
    /// and then returns the unit value
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items</param>
    /// <param name="action">The action to apply</param>
    /// <param name="pll">Whether parallel iteration should be invoked</param>    
    public static Unit iter<T>(IEnumerable<T> items, Action<T> action, bool pll = false)
    {
        if (pll)
            items.AsParallel().ForAll(item => action(item));
        else
            foreach (var item in items)
                action(item);
        return Unit.Value;
    }

    /// <summary>
    /// Iterates over items sequentially in enumeration order and invokes the supplied action for each one
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items</param>
    /// <param name="action">The action to apply</param>
    public static Unit iteri<T>(IEnumerable<T> items, Action<int, T> action)
    {
        int i = 0;
        foreach (var item in items)
            action(i++, item);
        return Unit.Value;
    }

    /// <summary>
    /// Iterates over items sequentially in enumeration order and invokes the supplied action for each one up
    /// to the specified limit
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="items">The items</param>
    /// <param name="action">The action to apply</param>
    /// <param name="limit">The maximum value of the index</param>
    public static Unit iteri<T>(IEnumerable<T> items, int limit, Action<int, T> action)
    {
        int i = 0;
        foreach (var item in items)
        {
            if (i > limit)
                break;

            action(i++, item);
        }
        return Unit.Value;
    }
}