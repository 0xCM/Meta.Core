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

    public readonly struct P<X1> : IEquatable<P<X1>>, IProduct<X1>
    {
        public const int Arity = 1;

        public static implicit operator P<X1>(X1 x1)
            => new P<X1>(x1);

        public static implicit operator X1 (P<X1> p)
            => p.x1;

        public static bool operator ==(P<X1> x, P<X1> y)
            => x.Equals(y);

        public static bool operator !=(P<X1> x, P<X1> y)
            => not(x.Equals(y));

        public P(X1 x1)
        {
            this.x1 = x1;
            
        }

        public X1 x1 { get; }

        int ITuple.Length
            => Arity;

        object ITuple.this[int n] 
            => n is 0 ? x1 : fail<object>(IndexOutOfRange(n));

        public ValueTuple<X1> AsTuple()
            => ValueTuple.Create(x1);

        public override bool Equals(object obj)
           => (obj is P<X1> p) ? Equals(p) : false;

        public bool Equals(P<X1> other)
            => object.Equals(x1, other.x1);

        public override int GetHashCode()
            => x1.GetHashCode();

    }

}