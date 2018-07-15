//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

using static minicore;

partial class Union
{   
    public readonly struct U<X1> : IEquatable<U<X1>>, IUnion<X1>
    {
        public static implicit operator U<X1>(X1 x1)
            => new U<X1>(x1);

        public static bool operator ==(U<X1> x, U<X1> y)
            => x.Equals(y);

        public static bool operator !=(U<X1> x, U<X1> y)
            => not(x.Equals(y));

        public static bool operator ==(U<X1> x, X1 y)
            => y == null ? false 
            : y.Equals(x.x1.ValueOrDefault());

        public static bool operator !=(U<X1> x, X1 y)
            => not(x == y);

        public U(X1 x1)
        {
            this.x1 = x1;
            this.n = 1;
        }

        public int n { get; }

        public Option<X1> x1 { get; }

        object IUnion.value
            => x1.ValueOrDefault();

        public Option<Y1> match<Y1>(Func<X1, Y1> f1)
            => x1.Map(x => f1(x));

        public Y map<Y>(Func<object, Y> f)
            => x1.MapRequired(x => f(x));

        public bool Equals(U<X1> other)
            => x1.Equals(other.x1);

        public override bool Equals(object obj)
            => obj is U<X1>
            ? Equals((U<X1>)obj) : false;

        public override string ToString()
            => format(x1);

        public override int GetHashCode()
            => map(x => x.GetHashCode());           
    } 
}