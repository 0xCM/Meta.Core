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
            = new Container<X>(Seq<X>.Empty);

        public Container(IStreamable<X> contained)
            => this.Contained = contained;

        IStreamable<X> Contained { get; }

        public Cardinality Cardinality
            => Contained.Cardinality;

        public IEnumerable<X> Stream()
            => Contained.Stream();

        Seq<X> IContainer<X>.Contained()
            => Seq.make(Contained.Stream());

        ContainerFactory<Y> IContainer<X>.Factory<Y>()
            => x => new Container<Y>(Seq.make(x));

    }



}