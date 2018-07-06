//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;
using static etude;

using Meta.Core;

partial class adt
{
    public readonly struct LU<L, X1, X2, X3> : IEquatable<LU<L, X1, X2, X3>>
    {
        public static implicit operator LU<L, X1, X2, X3>((L label, X1 x1) x)
            => new LU<L, X1, X2, X3>(x);

        public static implicit operator LU<L, X1, X2, X3>((L label, X2 x2) x)
            => new LU<L, X1, X2, X3>(x);

        public static implicit operator LU<L, X1, X2, X3>((L label, X3 x3) x)
            => new LU<L, X1, X2, X3>(x);

        public static bool operator ==(LU<L, X1, X2, X3> x, LU<L, X1, X2, X3> y)
            => x.Equals(y);

        public static bool operator !=(LU<L, X1, X2, X3> x, LU<L, X1, X2, X3> y)
            => not(x.Equals(y));

        public static bool operator ==(LU<L, X1, X2, X3> x, (L label, X1 x1) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public static bool operator !=(LU<L, X1, X2, X3> x, (L label, X1 x1) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public static bool operator ==(LU<L, X1, X2, X3> x, (L label, X2 x2) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public static bool operator !=(LU<L, X1, X2, X3> x, (L label, X2 x2) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public static bool operator ==(LU<L, X1, X2, X3> x, (L label, X3 x3) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public static bool operator !=(LU<L, X1, X2, X3> x, (L label, X3 x3) y)
            => x.Equals(new LU<L, X1, X2, X3>(y));

        public LU(L Label, X1 x1)
        {
            this.label = Label;
            this.x1 = x1;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
        }

        public LU((L Label, X1 x1) x1)
        {
            this.label = x1.Label;
            this.x1 = x1.x1;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
        }

        public LU(L Label, X2 x2)
        {
            this.label = Label;
            this.x1 = none<X1>();
            this.x2 = x2;
            this.x3 = none<X3>();
        }

        public LU((L Label, X2 x2) x2)
        {
            this.label = x2.Label;
            this.x1 = none<X1>();
            this.x2 = x2.x2;
            this.x3 = none<X3>();
        }

        public LU(L Label, X3 x3)
        {
            this.label = Label;
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x3;
        }

        public LU((L Label, X3 x3) x3)
        {
            this.label = x3.Label;
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x3.x3;
        }


        L label { get; }

        Option<X1> x1 { get; }

        Option<X2> x2 { get; }

        Option<X3> x3 { get; }

        public Option<Y1> Match<Y1>(Func<X1, Y1> f)
            => x1.Map(x => f(x));

        public Option<Y2> Match<Y2>(Func<X2, Y2> f)
            => x2.Map(x => f(x));

        public Option<Y3> Match<Y3>(Func<X3, Y3> f)
            => x3.Map(x => f(x));

        public U<Y1, Y2, Y3, Y4> Match<Y1, Y2, Y3, Y4>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => first(
                Match(f1).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f2).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f3).Map(x => du<Y1, Y2, Y3, Y4>(x))
                );

        public Y Map<Y>(Func<object, Y> f)
            => x1 ? x1.MapRequired(x => f(x))
            : x2 ? x2.MapRequired(x => f(x))
            : x3 ? x3.MapRequired(x => f(x))
            : default;

        public override bool Equals(object obj)
            => obj is LU<L, X1, X2, X3>
            ? Equals((LU<L, X1, X2, X3>)obj) : false;

        public bool Equals(LU<L, X1, X2, X3> other)
            => object.Equals(this.label, other.label)
            && this.x1 == other.x1
            && this.x2 == other.x2
            && this.x3 == other.x3
            ;

        public LU<L,X1, X2, X3, X4> WithType<X4>()
             => ldu<L,X1, X2, X3, X4>(label, x1, x2, x3, default(X4));

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2),
                format(x3) 
                );

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }
}