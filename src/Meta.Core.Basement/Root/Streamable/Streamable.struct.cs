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


    /// <summary>
    /// Canonical implementation of <see cref="IStreamable{X}"/>
    /// </summary>
    /// <typeparam name="X">The stream element type</typeparam>
    public readonly struct Streamable<X> : IStreamable<X>
    {
        public static readonly Streamable<X> Empty 
            = new Streamable<X>(() => stream<X>(), Cardinality.Zero);

        public Streamable(Streamer<X> streamer, Cardinality cardinality)
        {
            this.streamer = streamer;
            this.Cardinality = cardinality;
        }

        Streamer<X> streamer { get; }

        /// <summary>
        /// Characterizes the cardinality of the stream
        /// </summary>
        public Cardinality Cardinality { get; }

        /// <summary>
        /// Initiates the stream
        /// </summary>
        /// <returns></returns>
        public IEnumerable<X> Stream()
            => streamer();

        IEnumerable IStreamable.Stream()
            => Stream();
    }

    /// <summary>
    /// Represents a source of a stream that is known to terminate
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    public readonly struct FiniteStreamable<X> : IStreamable<X>
    {
        public static readonly FiniteStreamable<X> Empty
            = new FiniteStreamable<X>(() => stream<X>(), Cardinality.Zero);

        public FiniteStreamable(Streamer<X> Streamer)

        {
            this.Streamer = Streamer;
            this.Cardinality = Cardinality.Finite;

        }

        FiniteStreamable(Streamer<X> Streamer, Cardinality cardinality)
        {
            this.Streamer = Streamer;
            this.Cardinality = cardinality;
        }

        Streamer<X> Streamer { get; }

        /// <summary>
        /// Initiates the stream
        /// </summary>
        /// <returns></returns>
        public IEnumerable<X> Stream()
            => Streamer();

        IEnumerable IStreamable.Stream()
            => Stream();

        /// <summary>
        /// Characterizes the cardinality of the stream, either 
        /// <see cref="Cardinality.Finite"/> or <see cref="Cardinality.Zero"/>
        /// </summary>
        public Cardinality Cardinality { get; }
            
    }

}