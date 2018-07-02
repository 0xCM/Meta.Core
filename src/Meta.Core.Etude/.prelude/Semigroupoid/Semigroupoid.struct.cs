//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    /// <summary>
    /// Canonical semigroupoid over <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Semigroupoid
    /// </remarks>
    public readonly struct Semigroupoid<X> : ISemigroupoid<X>
    {
        public static readonly Semigroupoid<X> instance 
            = new Semigroupoid<X>();

        public Func<X, A, C> compose<A,B,C>(Func<X, B, C> f, Func<X, A, B> g)
            => (x, y) => f(x, g(x, y));


        public Func<X, A, C> rcompose<A, B, C>(Func<X, A, B> f, Func<X, B, C> g)
            => (x, y) => g(x, f(x, y));
        
    }

    partial class classops
    {
        /// <summary>
        /// Represents the <see cref="ISemigroupoid"/> compose operation
        /// </summary>
        public readonly struct fcompose : IClassOp<fcompose>
        {
            public static readonly fcompose op = default;
            public const string S = "<<<";
        }

        /// <summary>
        /// Represents this <see cref="ISemigroupoid"/> fcompose operation
        /// </summary>
        public readonly struct rcompose : IClassOp<rcompose>
        {
            public static readonly rcompose op = default;
            public const string S = ">>>";
        }

    }

}
