//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Meta.Core;


/// <summary>
/// Defines container-related extensions, primarily to facilitate LINQ integration
/// </summary>
public static class ContainerX
{
    /// <summary>
    /// Returns true if the container is nonempty, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container to examine</param>
    /// <returns></returns>
    public static bool Any<X>(this IContainer<X> container)
        => container.Stream().Any();

    /// <summary>
    /// Returns true if any element in a container satisfies a predicate, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container over which to apply the predicate</param>
    /// <param name="predicate">The predicate to evaluate</param>
    /// <returns></returns>
    public static bool Any<X>(this IContainer<X> container, Func<X, bool> predicate)
        => container.Stream().Any(predicate);

    /// <summary>
    /// Returns true if all elements in a container satisfies a predicate, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container over which to apply the predicate</param>
    /// <param name="predicate">The predicate to evaluate</param>
    /// <returns></returns>
    public static bool All<X>(this IContainer<X> container, Func<X, bool> predicate)
        => container.Stream().All(predicate);

    /// <summary>
    /// Retrieves the last element if it exists; oterwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container to examine</param>
    /// <returns></returns>
    public static Option<X> Last<X>(this IContainer<X> container)
        => container.Stream().LastOrDefault();

    /// <summary>
    /// Retrieves the first element; otherwise, None
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The array to examine</param>
    /// <returns></returns>
    public static Option<X> First<X>(this IContainer<X> container)
        => container.Stream().FirstOrDefault();

    /// <summary>
    /// Returns the first item in the container that satisfies the predicate, if any. Otherwise
    /// returns None
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="predicate">the predicate to check</param>
    /// <returns></returns>
    public static Option<X> First<X>(this IContainer<X> container, Func<X, bool> predicate)
        => container.Stream().FirstOrDefault(predicate);

    /// <summary>
    /// For a singleton container, returns the single element; otherwise returns none
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="element">The element to match</param>
    /// <returns></returns>
    public static Option<X> Single<X>(this IContainer<X> container)
        => container.Stream().SingleOrDefault();

    /// <summary>
    /// If exactly one item in the container satisfies teh predicate, returns that item;
    /// otherwise, returns None
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="predicate">the predicate to check</param>
    /// <returns></returns>
    public static Option<X> Single<X>(this IContainer<X> container, Func<X, bool> predicate)
        => container.Stream().SingleOrDefault(predicate);

    /// <summary>
    /// Returns the first item in the container if any. Otherwise
    /// returns the default value for <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="default">The value returned when predicate is unsatisfied</param>
    /// <returns></returns>
    public static X FirstOrDefault<X>(this IContainer<X> container, X @default = default)
        => container.First().ValueOrDefault(@default);

    /// <summary>
    /// Returns the first item in the container that satisfies the predicate, if any. Otherwise
    /// returns the default value for <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="predicate">the predicate to check</param>
    /// <param name="default">The value returned when predicate is unsatisfied</param>
    /// <returns></returns>
    public static X FirstOrDefault<X>(this IContainer<X> container, Func<X, bool> predicate, X @default = default)
        => container.First(predicate).ValueOrDefault(@default);

    /// <summary>
    /// Folds the values encapsulated by the container into a single value
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container to search</param>
    /// <returns></returns>
    public static X Aggregate<X>(this IContainer<X> container, Func<X, X, X> combiner)
        => container.Stream().Aggregate((x,y) => combiner(x,y));

    /// <summary>
    /// Returns true if a specified element is held by a container, false otherwise
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <param name="container">The container to search</param>
    /// <param name="element">The element to match</param>
    /// <returns></returns>
    public static bool Contains<X>(this IContainer<X> container, X element)
        => container.Stream().Contains(element);


    /// <summary>
    /// Returns any elements in the container of type <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The element type to match</typeparam>
    /// <param name="c"></param>
    /// <returns></returns>
    public static IEnumerable<X> OfType<X>(this IContainer c)
        => c.Stream().OfType<X>();

    /// <summary>
    /// Constructs a dictionary from a container
    /// </summary>
    /// <typeparam name="K">The dictionary key type</typeparam>
    /// <typeparam name="V">The element type</typeparam>
    /// <param name="container">The input container</param>
    /// <param name="keySelector">The selector</param>
    /// <returns></returns>
    public static IReadOnlyDictionary<K, V> ToDictionary<K, V>(this IContainer<V> container, Func<V, K> keySelector)
        => container.Stream().ToDictionary(keySelector);
}

