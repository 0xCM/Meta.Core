//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Concurrent;

    using static minicore;

    /// <summary>
    /// Thread-safe typeclass lookup
    /// </summary>
    /// <typeparam name="I">The type of the indexed typeclass</typeparam>
    public class ClassInstanceIndex<I>
    {
        ConcurrentDictionary<Type, object> IndexData { get; }
            = new ConcurrentDictionary<Type, object>();

        public Option<X> Lookup<X>()
            => from instance in IndexData.TryFind(typeof(X))
               from typed in tryCast<X>(instance)
               select typed;

        /// <summary>
        /// Registers a class instance
        /// </summary>
        /// <typeparam name="Subject">The instance subject type</typeparam>
        /// <param name="instance">The instance to register</param>
        public bool Register<Subject>(I instance)
            =>  IndexData.TryAdd(typeof(Subject), instance);

        /// <summary>
        /// Registers a class instance
        /// </summary>
        public bool Register(Type subject, I instance)
            => IndexData.TryAdd(subject, instance);

        public Option<Contract> Acquire<Subject, Contract>(Func<Type, I> Factory)
            => Try(() => cast<Contract>(IndexData.GetOrAdd(typeof(Subject), Factory)));

        /// <summary>
        /// Searches for a class instance given a subject
        /// </summary>
        /// <typeparam name="Contract"></typeparam>
        /// <param name="subject"></param>
        /// <returns></returns>
        public Option<Contract> TryFind<Contract>(Type subject)
            => from x in IndexData.TryFind(subject)
               from y in tryCast<Contract>(x)
               select y;
    }


}