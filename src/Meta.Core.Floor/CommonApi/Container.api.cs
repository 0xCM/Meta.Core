//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{
    /// <summary>
    /// Iterates over items sequentially or in parallel, invokes the supplied action for each one
    /// and then returns the unit value
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The item source</param>
    /// <param name="action">The action to apply</param>
    /// <param name="PLL">Whether parallel iteration should be invoked</param>    
    public static Unit iter<X>(IContainer<X> container, Action<X> action, bool PLL = false)
        => (Unit)(() => iter(container.Stream(), action, PLL));

    /// <summary>
    /// Iterates over items sequentially in enumeration order and invokes the supplied action for each one
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The item source</param>
    /// <param name="action">The action to apply</param>
    public static Unit iteri<X>(IContainer<X> container, Action<int, X> action)
        => Container.iteri(action, container);

    /// <summary>
    /// Defines iteration construct invokes an action for every integer
    /// contained in the half-open interval [lower, upper) and returns
    /// the unit value
    /// </summary>
    /// <param name="lower">The lower bound</param>
    /// <param name="upper">The upper bound</param>
    /// <param name="action">The action to invoke</param>
    public static Unit iter<T>(T lower, T upper, Action<T> action)
    {
        iter(range(lower, upper), i => action(i));
        return Unit.Value;
    }

    //public static Container<Y> map<X, Y>(Container<X> container, Func<X, Y> f)        
    //    => Container.make(Container.map(f, container));

    /// <summary>
    /// Constructs an array from a container
    /// </summary>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] array<T>(IContainer<T> items)
        => array(items.Stream());

    /// <summary>
    /// Returns true if a predicate is satisfied for all elements in a container; false otherwise
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="p">The predicate to evaluate</param>
    /// <param name="container">The container over which to evaluate the predicate</param>
    /// <returns></returns>
    public static bool all<X>(IContainer<X> container, Func<X, bool> p)
        => Container.all(p, container);
}