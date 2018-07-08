//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Reflection;

    using Meta.Core.Modules;

    using static minicore;
    

    public class Synthetic
    {
        internal static Synthetic Create(ValueSourceConfig settings, IReadOnlyDictionary<Type,MethodInfo> factories)
            => new Synthetic(settings.Seed, settings.Facets);

        public static Synthetic Create(ValueSourceConfig settings)
            => new Synthetic(settings.Seed, settings.Facets);

        public static Synthetic Create(int? seed, params IFacet[] facets)
            => new Synthetic(seed, facets);

        public static Synthetic Create(int? seed = null)
            => new Synthetic(seed);

        public static implicit operator decimal(Synthetic vv)
            => vv.Next<decimal>();

        public static implicit operator Date(Synthetic vv)
            => vv.Next<Date>();

        public static implicit operator Guid(Synthetic vv)
            => vv.Next<Guid>();

        public static implicit operator int(Synthetic vv)
            => vv.Next<int>();

        public static implicit operator short(Synthetic vv)
            => vv.Next<short>();

        public static implicit operator ushort(Synthetic vv)
            => vv.Next<ushort>();

        public static implicit operator string(Synthetic u)
            => u.Next<string>();

        public static implicit operator byte(Synthetic u)
            => u.Next<byte>();

        Delegate CreateSource(Type v)
        {
            var m = factories[v];
            return (Delegate) m.Invoke(null, new object[] { facets, seed });

        }

        ValueSource<T> CreateSource<T>()
        {
            var m = factories[typeof(T)];
            return (ValueSource<T>)m.Invoke(null, new object[] { facets, seed });
        }

        Synthetic(ValueSourceConfig settings, IReadOnlyDictionary<Type,MethodInfo> factories)
        {
            this.facets = settings.Facets;
            this.seed = settings.Seed;
            this.factories = factories;
        }

        Synthetic(int? seed, IFacetSet facets)
        {
            this.facets = facets;
            this.seed = seed;
            this.factories = Synthetics.Factories;
        }

        Synthetic(int? seed, params IFacet[] facets)
        {
            this.facets = new FacetSet(facets);
            this.seed = seed;
            this.factories = Synthetics.Factories;
        }

        Synthetic(int? seed = null)
        {
            this.seed = seed;
            this.facets = new FacetSet();
            this.factories = Synthetics.Factories;
        }

        ConcurrentDictionary<Type, object> sources { get; }
            = new ConcurrentDictionary<Type, object>();

        public IFacetSet facets { get; }

        public int? seed { get; }

        IReadOnlyDictionary<Type, MethodInfo> factories { get; }

        public object Next(Type v)
        {
            var source = (Delegate)sources.GetOrAdd(v, _ => CreateSource(v));
            return source.DynamicInvoke();
        }


        ValueSource<V> Source<V>()
            => cast<ValueSource<V>>(sources.GetOrAdd(typeof(V), _ => CreateSource<V>()));
        
        /// <summary>
        /// Retrieves the next synthetic value
        /// </summary>
        /// <typeparam name="V">The synthetic value type</typeparam>
        /// <returns></returns>
        public V Next<V>()
        {
            var source = cast<ValueSource<V>>(sources.GetOrAdd(typeof(V), _ => CreateSource<V>()));
            return source();
        }

        IEnumerable<V> _Next<V>(int count)
        {
            var source = Source<V>();
            for (var i = 0; i < count; i++)
                yield return source();
        }

        /// <summary>
        /// Retrieves the next range of synthetic values
        /// </summary>
        /// <typeparam name="V">The synthetic value type</typeparam>
        /// <param name="count">The number of values to yeild</param>
        /// <returns></returns>
        public Seq<V> Next<V>(int count)
            => Seq.make(_Next<V>(count));
    }
}
