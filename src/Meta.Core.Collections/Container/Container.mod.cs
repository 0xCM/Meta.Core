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
        /// Transforms the content of an existing container to create a new container
        /// </summary>
        /// <typeparam name="X">The type of element in the source container</typeparam>
        /// <typeparam name="Y">The type of element in the target container</typeparam>
        /// <param name="f">The transformer</param>
        /// <param name="container">The source container</param>
        /// <returns></returns>
        public static IContainer<Y> recontain<X, Y>(Func<X, Y> f, IContainer<X> container)
            => container.Factory<Y>()(container.Contained().Stream().Select(f));

        /// <summary>
        /// Applies a function to each contained item returns a list of results
        /// </summary>
        /// <typeparam name="X">The input item type</typeparam>
        /// <typeparam name="Y">The output item type</typeparam>
        /// <param name="container"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IContainer<Y> map<X, Y>(Func<X, Y> f, IContainer<X> container)
              => recontain(f, container);
            
        /// <summary>
        /// Iterates over items sequentially in enumeration order and invokes the supplied action for each one
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="container">The item source</param>
        /// <param name="action">The action to apply</param>
        public static Unit iteri<X>(Action<int, X> action, IContainer<X> container)
            => iteri(action, container);
    }

}