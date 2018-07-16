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

    /// <summary>
    /// Constructs an array from a container
    /// </summary>
    /// <param name="items">The items from which to construct the array</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X[] array<X>(IContainer<X> items)
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

    /// <summary>
    /// Returns true if a predicate is satisfied for all elements in a container; false otherwise
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="p">The predicate to evaluate</param>
    /// <param name="container">The container over which to evaluate the predicate</param>
    /// <returns></returns>
    public static bool any<X>(IContainer<X> container, Func<X, bool> p)
        => Container.any(p, container);

    /// <summary>
    /// Folds the container into a single value using the (+) operator defined for the type <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The source container</param>
    /// <returns></returns>
    public static X sum<X>(IContainer<X> container)
            => container.Aggregate(operators.add);

    /// <summary>
    /// Concatenates two container
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <typeparam name="CX">The container type</typeparam>
    /// <param name="cx1">The first container</param>
    /// <param name="cx2">The second container</param>
    /// <returns></returns>
    public static CX concat<X, CX>(CX cx1, CX cx2)
        where CX : IContainer<X, CX>, new()
            => Container.concat<X,CX>(cx1, cx2);

    /// <summary>
    /// Sequentially concatenates an array of containers
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <typeparam name="CX">The container type</typeparam>
    /// <param name="containers">The containers to concatenate</param>
    /// <returns></returns>
    public static CX chain<X, CX>(params CX[] containers)
        where CX : IContainer<X, CX>, new()
            => Container.chain<X,CX>(containers);


 
}