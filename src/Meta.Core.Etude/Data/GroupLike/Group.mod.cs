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

    using static metacore;

    /// <summary>
    /// Constructs and manipulates <see cref="IGroup{X}"/> types and values
    /// </summary>
    public class Group : ClassModule<Group, IGroup>
    {
        public Group()
            : base(typeof(Group<>))
        {

        }

        /// <summary>
        /// Constructs a <see cref="IGroup"/> over <typeparamref name="X"/> using provided aspects
        /// </summary>
        /// <typeparam name="X">The group element type</typeparam>
        /// <param name="Equator">The equality adjudicator</param>
        /// <param name="Combiner">The group operation</param>
        /// <param name="Zero">The group identity</param>
        /// <param name="Inverter">The element inverter</param>
        /// <returns></returns>
        public static IGroup<X> make<X>(Equator<X> Equator, Combiner<X> Combiner, X Zero, Inverter<X> Inverter)
            => new Group<X>(Equator, Combiner, Zero, Inverter);

        /// <summary>
        /// Attempts to construct a <see cref="IGroup"/> over <typeparamref name="X"/> using derived aspects
        /// </summary>
        /// <typeparam name="X">The group element type</typeparam>
        /// <returns></returns>
        public static Option<IGroup<X>> make<X>()
            => Try(() => (IGroup<X>)Instances.GetOrAdd(typeof(X), t => Default<X>()));

        static ConcurrentDictionary<Type, object> Instances { get; }
            = new ConcurrentDictionary<Type, object>();

        static IGroup<X> Default<X>()
            => make(operators.eq, operators.add, operators.zero<X>(), operators.neg);

    }
}