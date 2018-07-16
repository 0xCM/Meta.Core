//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Runtime.CompilerServices;

using Meta.Core;
using static minicore;

partial class Product
{

    /// <summary>
    /// The algebraic product of two types
    /// </summary>
    /// <typeparam name="X1">The first type</typeparam>
    /// <typeparam name="X2">The second type</typeparam>
    /// <remarks>This and the 2-tuple type are effectively isomorphic</remarks>
    public readonly struct P<X1, X2> : IEquatable<P<X1, X2>>, IProduct<X1,X2>
    {

        public const int Arity = 2;

        /// <summary>
        /// Constructs a product from a tuple
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator P<X1, X2>((X1 x1, X2 x2) x)
            => new P<X1, X2>(x);

        /// <summary>
        /// Constructs a tuple from a product
        /// </summary>
        /// <param name="p">The source product</param>
        public static implicit operator (X1, X2) (P<X1, X2> p)
            => p.AsTuple();

        public static bool operator ==(P<X1, X2> x, P<X1, X2> y)
            => x.Equals(y);

        public static bool operator !=(P<X1, X2> x, P<X1, X2> y)
            => not(x.Equals(y));

        public P(X1 x1, X2 x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public P((X1 x1, X2 x2) x)
        {
            this.x1 = x.x1;
            this.x2 = x.x2;
        }

        /// <summary>
        /// The value of the first factor
        /// </summary>
        public X1 x1 { get; }

        /// <summary>
        /// The value of the second factor
        /// </summary>
        public X2 x2 { get; }

        /// <summary>
        /// Presents the product as a tuple
        /// </summary>
        /// <returns></returns>
        public (X1 x1, X2 x2) AsTuple()
            => (x1, x2);

        int ITuple.Length
            => Arity;

        object ITuple.this[int n]
            => n is 0 ? x1 :
               n is 1 ? x2 : fail<object>(IndexOutOfRange(n));

        public override bool Equals(object obj)
           => (obj is P<X1, X2> p) ? Equals(p) : false;

        public bool Equals(P<X1, X2> other)
            => other.AsTuple().Equals(this.AsTuple());

        public override int GetHashCode()
            => AsTuple().GetHashCode();

    }

}