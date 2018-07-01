﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
        
    using static metacore;
    using static etude;
    using static Union;

    public readonly struct Union<X1, X2, X3, X4> : IEquatable<Union<X1, X2, X3, X4>>
    {
        public static implicit operator Union<X1, X2, X3, X4>(X1 x1)
            => new Union<X1, X2, X3, X4>(x1);

        public static implicit operator Union<X1, X2, X3, X4>(X2 x2)
            => new Union<X1, X2, X3, X4>(x2);

        public static implicit operator Union<X1, X2, X3, X4>(X3 x3)
            => new Union<X1, X2, X3, X4>(x3);

        public static implicit operator Union<X1, X2, X3, X4>(X4 x4)
            => new Union<X1, X2, X3, X4>(x4);

        public static bool operator ==(Union<X1, X2, X3, X4> x, Union<X1, X2, X3, X4> y)
            => x.Equals(y);

        public static bool operator !=(Union<X1, X2, X3, X4> x, Union<X1, X2, X3, X4> y)
            => not(x.Equals(y));

        public static bool operator ==(Union<X1, X2, X3, X4> x, X1 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator !=(Union<X1, X2, X3, X4> x, X1 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator ==(Union<X1, X2, X3, X4> x, X2 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator !=(Union<X1, X2, X3, X4> x, X2 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator ==(Union<X1, X2, X3, X4> x, X3 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator !=(Union<X1, X2, X3, X4> x, X3 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator ==(Union<X1, X2, X3, X4> x, X4 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public static bool operator !=(Union<X1, X2, X3, X4> x, X4 y)
            => x.Equals(du<X1, X2, X3, X4>(y));

        public Union(X1 x)
        {
            this.x1 = x;
            this.x2 = none<X2>();
            this.x3 = none<X3>();
            this.x4 = none<X4>();
        }

        public Union(X2 x)
        {
            this.x1 = none<X1>();
            this.x2 = x;
            this.x3 = none<X3>();
            this.x4 = none<X4>();
        }

        public Union(X3 x)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = x;
            this.x4 = none<X4>();
        }

        public Union(X4 x)
        {
            this.x1 = none<X1>();
            this.x2 = none<X2>();
            this.x3 = none<X3>();
            this.x4 = x;
        }

        Option<X1> x1 { get; }

        Option<X2> x2 { get; }

        Option<X3> x3 { get; }

        Option<X4> x4 { get; }

        public Option<Y1> Match<Y1>(Func<X1, Y1> f)
            => x1.Map(x => f(x));

        public Option<Y2> Match<Y2>(Func<X2, Y2> f)
            => x2.Map(x => f(x));

        public Option<Y3> Match<Y3>(Func<X3, Y3> f)
            => x3.Map(x => f(x));

        public Option<Y4> Match<Y4>(Func<X4, Y4> f)
            => x4.Map(x => f(x));

        public Union<Y1, Y2, Y3, Y4> Match<Y1, Y2, Y3, Y4>(Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4)
            => first(
                Match(f1).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f2).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f3).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f4).Map(x => du<Y1, Y2, Y3, Y4>(x))
                );

        public Y Map<Y>(Func<object, Y> f)
            => x1 ? x1.MapValue(x => f(x))
            : x2 ? x2.MapValue(x => f(x))
            : x3 ? x3.MapValue(x => f(x))
            : x4 ? x4.MapValue(x => f(x))
            : default;

        public override bool Equals(object obj)
            => obj is Union<X1, X2, X3, X4>
            ? Equals((Union<X1, X2, X3, X4>)obj) : false;

        public bool Equals(Union<X1, X2, X3, X4> other)
            => this.x1 == other.x1
            && this.x2 == other.x2
            && this.x3 == other.x3
            && this.x4 == other.x4
            ;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2),
                format(x3), format(x4)
                );

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }
 
}