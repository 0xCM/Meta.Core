//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using static minicore;
    using Modules;

    /// <summary>
    /// Reifies the <see cref="IContainer"/> typeclass
    /// </summary>
    /// <typeparam name="X">The contained element type</typeparam>
    public readonly struct Container<X> : IContainer<X>
    {
        /// <summary>
        /// The canonical 0
        /// </summary>
        public static readonly Container<X> Empty
            = new Container<X>(Streamable.make(() => stream<X>(), Cardinality.Zero));

        public Container(IStreamable<X> contained)
            => this.Contained = contained;

        IStreamable<X> Contained { get; }

        public Cardinality Cardinality
            => Contained.Cardinality;

        public IEnumerable<X> Stream()
            => Contained.Stream();

        public IContainer<Y> GetEmpty<Y>()
            => Container<Y>.Empty;

        public ContainerFactory<X> GetFactory()
            => input => new Container<X>(Streamable.make(() =>input, Cardinality.Unknown));

        IEnumerable IStreamable.Stream()
            => Stream();
    }

    public readonly struct Container<X, CX> : IContainer<X, CX>
        where CX : IContainer<X, CX>, new()
    {
        public CX Empty
            => Factory(stream<X>());

        public Cardinality Cardinality
            => Contained.Cardinality;

        IStreamable<X> Contained { get; }

        public Container(IStreamable<X> contained, ContainerFactory<X,CX> factory)
        {
            this.Contained = contained;
            this.Factory = factory;
        }

        public bool Equals(CX other)
            => Stream().ToReadOnlyList().ContentEqualTo(other.Stream().ToReadOnlyList());
            
        public ContainerFactory<X, CX> Factory { get; }

        ContainerFactory<X> IContainer<X>.GetFactory()
        {
            var _factory = Factory;
            return items => _factory(items);
        }        

        public IEnumerable<X> Stream()
            => Contained.Stream();

        IContainer<Y> IContainer<X>.GetEmpty<Y>()
             => Container<Y>.Empty;
        IEnumerable IStreamable.Stream()
            => Stream();

    }
}