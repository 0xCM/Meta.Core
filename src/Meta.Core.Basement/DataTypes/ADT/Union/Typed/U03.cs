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

    public readonly struct U<X1, X2, X3> : IEquatable<U<X1, X2, X3>>, IUnion<X1,X2,X3>
    {

        public static implicit operator U<X1, X2, X3>(X1 x1)
            => new U<X1, X2, X3>(x1);

        public static implicit operator U<X1, X2, X3>(X2 x2)
            => new U<X1, X2, X3>(x2);

        public static implicit operator U<X1, X2, X3>(X3 x3)
            => new U<X1, X2, X3>(x3);

        public static bool operator ==(U<X1, X2, X3> x, U<X1, X2, X3> y)
            => x.Equals(y);

        public static bool operator !=(U<X1, X2, X3> x, U<X1, X2, X3> y)
            => not(x.Equals(y));

        public U(X1 x1)
        {
            this.x1 = x1;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
            this.n = 1;
        }

        public U(X2 x2)
        {
            this.x1 = none<X1>();
            this.x2 = x2;
            this.x3 = none<X3>();
            this.n = 2;
        }

        public U(X3 x3)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x3;
            this.n = 3;
        }

        public int n { get; }

        public Option<X1> x1 { get; }

        public Option<X2> x2 { get; }

        public Option<X3> x3 { get; }

        object IUnion.value
            => first<IOption>(x1, x2, x3).Value;

        public Option<Y1> Match<Y1>(Func<X1, Y1> f1)
            => x1.Map(x => f1(x));

        public Option<Y2> Match<Y2>(Func<X2, Y2> f1)
            => x2.Map(x => f1(x));

        public Option<Y3> Match<Y3>(Func<X3, Y3> f1)
            => x3.Map(x => f1(x));

        public U<Y1, Y2, Y3> Match<Y1, Y2, Y3>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => first(
                Match(f1).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f2).Map(x => new U<Y1, Y2, Y3>(x)),
                Match(f3).Map(x => new U<Y1, Y2, Y3>(x))
                );

        public Y Map<Y>(Func<object, Y> f)
            => x1 ? x1.MapRequired(x => f(x))
            : x2 ? x2.MapRequired(x => f(x))
            : x3 ? x3.MapRequired(x => f(x))
            : default;

        public U<X1, X2, X3> Revalue(X1 x1)
            => new U<X1, X2, X3>(x1: x1);

        public U<X1, X2, X3> Revalue(X2 x2)
            => new U<X1, X2, X3>(x2: x2);

        public U<X1, X2, X3> Revalue(X3 x3)
            => new U<X1, X2, X3>(x3: x3);

        public override bool Equals(object obj)
            => obj is U<X1, X2, X3>
            ? Equals((U<X1, X2, X3>)obj) : false;

        public bool Equals(U<X1, X2, X3> other)
            => this.x1 == other.x1
            && this.x2 == other.x2
            && this.x3 == other.x3
            ;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(), format(x1), format(x2), format(x3));

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }

}