//-------------------------------------------------------------------------------------------
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

    public readonly struct Union<X1> : IEquatable<Union<X1>>
    {
        public static implicit operator Union<X1>(X1 x1)
            => new Union<X1>(x1);

        public static bool operator ==(Union<X1> x, Union<X1> y)
            => x.Equals(y);

        public static bool operator !=(Union<X1> x, Union<X1> y)
            => not(x.Equals(y));

        public static bool operator ==(Union<X1> x, X1 y)
            => y == null ? false 
            : y.Equals(x.x1.ValueOrDefault());

        public static bool operator !=(Union<X1> x, X1 y)
            => not(x == y);

        public Union(X1 x1)
        {
            this.x1 = x1;
        }

        Option<X1> x1 { get; }

        public Option<Y1> match<Y1>(Func<X1, Y1> f1)
            => x1.Map(x => f1(x));

        public Y map<Y>(Func<object, Y> f)
            => x1.MapValue(x => f(x));

        public bool Equals(Union<X1> other)
            => eq(x1, other.x1);

        public override bool Equals(object obj)
            => obj is Union<X1>
            ? Equals((Union<X1>)obj) : false;


        public override string ToString()
            => format(x1);

        public override int GetHashCode()
            => map(x => x.GetHashCode());           
    } 
}