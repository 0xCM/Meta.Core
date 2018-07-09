//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;
using Meta.Core;

partial class Union
{
    /// <summary>
    /// A labled heterogenous union with 4 potential slots from which exactly one will be populated
    /// </summary>
    /// <typeparam name="L">The label type</typeparam>
    /// <typeparam name="X1">The type of the first slot</typeparam>
    /// <typeparam name="X2">The type of the second slot</typeparam>
    /// <typeparam name="X3">The type of the third slot</typeparam>
    /// <typeparam name="X4">The type of the fourth slot</typeparam>
    public readonly struct LU4<L, X> : IEquatable<LU4<L, X>>
    {
        public static implicit operator LU4<L,X>((L label, byte index, X value) x)
            => new LU4<L,X>(x);

        public static implicit operator (L label, byte index, X value)(LU4<L, X> x)
            => x.AsTuple();

        public static bool operator ==(LU4<L, X> x, LU4<L, X> y)
            => x.Equals(y);

        public static bool operator !=(LU4<L, X> x, LU4<L, X> y)
            => not(x.Equals(y));

        public LU4(L label, byte index, X value)
        {
            this.label = label;
            this.index = index;
            this.value = value;
            
        }

        public LU4((L label, byte index, X value) x)
        {
            this.label = x.label;
            this.index = x.index;
            this.value = x.value;

        }

        L label { get; }

        byte index { get; }

        X value { get; }

        public Y Map<Y>(Func<L, X, Y> f)
            => f(label, value);

        public Y Map<Y>(Func<L, int, X, Y> f)
            => f(label, index, value);

        public override bool Equals(object obj)
           => (obj is LU4<L, X> lu4) ? Equals(lu4) : false;

        public bool Equals(LU4<L, X> other)
            => object.Equals(this.label, other.label)
            && object.Equals(this.value, other.value)
            && object.Equals(this.index, other.index)
            ;

        public (L label, byte index, X value) AsTuple()
            => (label, index, value);

        public override string ToString()
            => AsTuple().Format();

        public override int GetHashCode()
            => AsTuple().GetHashCode();

    }
}