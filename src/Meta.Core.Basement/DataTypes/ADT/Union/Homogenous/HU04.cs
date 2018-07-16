//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;
using Meta.Core;

partial class Union
{
    /// <summary>
    /// A labled homogenous union with 4 potential slots from which exactly one will be populated
    /// </summary>
    /// <typeparam name="X">The type of the first slot</typeparam>
    public readonly struct HU4<X> : IEquatable<HU4<X>>
    {
        public static implicit operator HU4<X>((int index, X value) x)
            => new HU4<X>(x);

        public static implicit operator (int n, X value)(HU4<X> x)
            => x.AsTuple();

        public static bool operator ==(HU4<X> x, HU4<X> y)
            => x.Equals(y);

        public static bool operator !=(HU4<X> x, HU4<X> y)
            => not(x.Equals(y));

        public HU4(int index, X value)
        {
            this.n = index;
            this.value = value;
            
        }

        public HU4((int n, X value) x)
        {
            this.n = x.n;
            this.value = x.value;

        }

        public int n { get; }

        public X value { get; }

        public Y Map<Y>(Func<X, Y> f)
            => f(value);

        public Y Map<Y>(Func<int, X, Y> f)
            => f(n, value);

        public (int n, X value) AsTuple()
            => (n, value);

        public override bool Equals(object obj)
           => (obj is HU4<X> lu4) ? Equals(lu4) : false;

        public bool Equals(HU4<X> other)
            => object.Equals(this.value, other.value)
            && object.Equals(this.n, other.n)
            ;
 
        public override int GetHashCode()
            => AsTuple().GetHashCode();
    }
}