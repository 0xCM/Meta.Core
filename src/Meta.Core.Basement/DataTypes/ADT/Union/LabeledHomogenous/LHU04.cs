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
    /// <typeparam name="L">The label type</typeparam>
    /// <typeparam name="X">The type of the first slot</typeparam>
    public readonly struct LHU4<L, X> : IEquatable<LHU4<L, X>>
    {
        public static implicit operator LHU4<L,X>((L label, byte index, X value) x)
            => new LHU4<L,X>(x);

        public static implicit operator (L label, int index, X value)(LHU4<L, X> x)
            => x.AsTuple();

        public static bool operator ==(LHU4<L, X> x, LHU4<L, X> y)
            => x.Equals(y);

        public static bool operator !=(LHU4<L, X> x, LHU4<L, X> y)
            => not(x.Equals(y));

        public LHU4(L label, byte index, X value)
        {
            this.label = label;
            this.n = index;
            this.value = value;
            
        }

        public LHU4((L label, byte index, X value) x)
        {
            this.label = x.label;
            this.n = x.index;
            this.value = x.value;

        }

        int n { get; }

        L label { get; }

        X value { get; }

        public Y Map<Y>(Func<L, X, Y> f)
            => f(label, value);

        public Y Map<Y>(Func<L, int, X, Y> f)
            => f(label, n, value);

        public override bool Equals(object obj)
           => (obj is LHU4<L, X> lu4) ? Equals(lu4) : false;

        public bool Equals(LHU4<L, X> other)
            => object.Equals(this.label, other.label)
            && object.Equals(this.value, other.value)
            && object.Equals(this.n, other.n)
            ;

        public (L label, int index, X value) AsTuple()
            => (label, n, value);

 
        public override int GetHashCode()
            => AsTuple().GetHashCode();

    }
}