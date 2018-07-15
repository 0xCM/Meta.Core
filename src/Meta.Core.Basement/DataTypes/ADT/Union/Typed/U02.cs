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
    public readonly struct U<X1, X2> : IEquatable<U<X1, X2>>, IUnion<X1,X2>
    {
        
        public static implicit operator U<X1,X2>(X1 x1)
            => new U<X1, X2>(x1);

        public static implicit operator U<X1, X2>(X2 x2)
            => new U<X1, X2>(x2);

        public static bool operator ==(U<X1, X2> x, U<X1, X2> y)
            => x.Equals(y);

        public static bool operator !=(U<X1, X2> x, U<X1, X2> y)
            => not(x.Equals(y));

        public static bool operator ==(U<X1, X2> x, X1 y)
            => x.Equals(new U<X1, X2>(y));

        public static bool operator !=(U<X1, X2> x, X1 y)
            => not(x == y);

        public static bool operator ==(U<X1, X2> x, X2 y)
            => x.Equals(new U<X1, X2>(y));

        public static bool operator !=(U<X1, X2> x, X2 y)
            => not(x == y);


        public U(X1 x)
        {
            this.x1 = x;
            this.x2 = none<X2>();
            this.n = 1;
        }

        public U(X2 x)
        {
            this.x1 = none<X1>();
            this.x2 = x;
            this.n = 2;
        }

        public int n { get; }

        public Option<X1> x1 { get; }

        public Option<X2> x2 { get; }

        object IUnion.value
            => first<IOption>(x1, x2).Value;

        public Option<Y1> Match1<Y1>(Func<X1, Y1> f)
            => Match(f);

        public Option<Y2> Match2<Y2>(Func<X2, Y2> f)
            => Match(f);

        public Option<Y1> Match<Y1>(Func<X1, Y1> f1)
            => x1.Map(x => f1(x));

        public Option<Y2> Match<Y2>(Func<X2, Y2> f1)
            => x2.Map(x => f1(x));

        public U<Y1, Y2> Match<Y1, Y2>(Func<X1, Y1> f1, Func<X2, Y2> f2)
            => first(
                Match(f1).Map(x => new U<Y1, Y2>(x)),
                Match(f2).Map(x => new U<Y1, Y2>(x))
                );

        public Y Match<Y>(Func<X1, Y> f1, Func<X2, Y> f2)
            => first(
                Match(f1),
                Match(f2)
                );

        public Y Map<Y>(Func<object, Y> f)
            => x1 ? x1.MapRequired(x => f(x))
            : x2.MapRequired(x => f(x));

        public override bool Equals(object obj)
            => obj is U<X1, X2>
            ? Equals((U<X1, X2>)obj) : false;

        public bool Equals(U<X1, X2> other)
            => this.x1 == other.x1
            && this.x2 == other.x2;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(), format(x1), format(x2));

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    } 
}