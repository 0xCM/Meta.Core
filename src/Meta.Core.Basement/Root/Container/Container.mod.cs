//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Linq;

    /// <summary>
    /// Defines <see cref="Container{X}"/> operations
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Creates a container from any streamable
        /// </summary>
        /// <typeparam name="X">The streamed item type</typeparam>
        /// <param name="s">The stream factory</param>
        /// <returns></returns>
        public static Container<X> make<X>(IStreamable<X> s)
            => new Container<X>(s);

        /// <summary>
        /// Returns the canonical 0 value for the container over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <returns></returns>
        public static Container<X> zero<X>()
            => Container<X>.Empty;

        /// <summary>
        /// Returns true if a predicate is satisfied for all elements in a container; false otherwise
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate to evaluate</param>
        /// <param name="container">The container over which to evaluate the predicate</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all<X>(Func<X, bool> p, IContainer<X> container)
            => container.Stream().All(p);

        /// <summary>
        /// Returns true if a predicate is satisfied for any elements in a container; false otherwise
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="p">The predicate to evaluate</param>
        /// <param name="container">The container over which to evaluate the predicate</param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any<X>(Func<X, bool> p, IContainer<X> container)
            => container.Stream().Any(p);

        /// <summary>
        /// Iterates over items sequentially in enumeration order and invokes the supplied action for each one
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="container">The item source</param>
        /// <param name="action">The action to apply</param>
        public static Unit iteri<X>(Action<int, X> action, IContainer<X> container)
            => iteri(action, container);

        /// <summary>
        /// Computes the (non-cryptographic) hash code of a sequence
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="s">The sequence</param>
        /// <returns></returns>
        public static int hash<X>(IContainer<X> s)
            => s.Stream().GetHashCodeAggregate();

        /// <summary>
        /// Appends one container to another
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="l1">The firt list</param>
        /// <param name="l2">The second list</param>
        /// <returns></returns>
        public static CX concat<X, CX>(CX cx1, CX cx2)
            where CX : IContainer<X,CX>, new()
                => cx1.Factory(cx1.Stream().Concat(cx2.Stream()));

        /// <summary>
        /// Sequentially concatenates an array of containers
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <typeparam name="CX">The container type</typeparam>
        /// <param name="containers">The containers to concatenate</param>
        /// <returns></returns>
        public static CX chain<X, CX>(params CX[] containers)
            where CX : IContainer<X, CX>, new()
        {
            if (containers.Length == 0)
                return new CX();
            else if (containers.Length == 1)
                return containers[0];
            else                
                return containers[0].Factory(containers.SelectMany(c => c.Stream()));                                              
        }           
    }
}