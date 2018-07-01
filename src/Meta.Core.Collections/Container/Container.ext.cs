//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;


    /// <summary>
    /// Defines container-related extensions, primarily to facilitate LINQ integration
    /// </summary>
    public static class ContainerX
    {
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

    }

}