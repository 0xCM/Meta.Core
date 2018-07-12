//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Concurrent;

    using System.Linq;    

    using static metacore;

    public class Eq : ClassModule<Eq, IEq>, IEq
    {
        public Eq()
            : base(typeof(Eq<>))
        {

        }
        static ConcurrentDictionary<Type, object> Instances { get; }
            = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Constructs a <see cref="IEq{X}"/> instance
        /// </summary>
        /// <typeparam name="X">The type of element over which the instance is constructed</typeparam>
        /// <returns></returns>
        public static IEq<X> make<X>()
            => Instances.TryFind(typeof(X)).MapValueOrDefault(instance => (IEq<X>)instance, Eq<X>.instance);

        /// <summary>
        /// Constructs a <see cref="IEq{X}"/> from a supplied <see cref="Equator{X}"/>
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="equator"></param>
        /// <returns></returns>
        public static IEq<X> make<X>(Equator<X> equator)
            => new Eq<X>(equator);


    }
}