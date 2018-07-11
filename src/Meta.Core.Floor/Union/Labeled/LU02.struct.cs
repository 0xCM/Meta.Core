//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using static metacore;


partial class Union
{

    /// <summary>
    /// A labled heterogenous union with 2 potential slots where exactly one will be populated
    /// </summary>
    /// <typeparam name="L">The label type</typeparam>
    /// <typeparam name="X1">The type of the first slot</typeparam>
    /// <typeparam name="X2">The type of the second slot</typeparam>
    public readonly struct LU<L, X1, X2> : IEquatable<LU<L, X1, X2>>, ILabeledUnion<L,X1,X2>
    {
        public static implicit operator LU<L, X1, X2>((L label, X1 x1) x)
            => new LU<L, X1, X2>(x);

        public static implicit operator LU<L, X1, X2>((L label, X2 x2) x)
            => new LU<L, X1, X2>(x);

        public static bool operator ==(LU<L, X1, X2> x, LU<L, X1, X2> y)
            => x.Equals(y);

        public static bool operator !=(LU<L, X1, X2> x, LU<L, X1, X2> y)
            => not(x.Equals(y));

        public static bool operator ==(LU<L, X1, X2> x, (L label, X1 x1) y)
            => x.Equals(new LU<L, X1, X2>(y));

        public static bool operator !=(LU<L, X1, X2> x, (L label, X1 x1) y)
            => x.Equals(new LU<L, X1, X2>(y));

        public static bool operator ==(LU<L, X1, X2> x, (L label, X2 x2) y)
            => x.Equals(new LU<L, X1, X2>(y));

        public static bool operator !=(LU<L, X1, X2> x, (L label, X2 x2) y)
            => x.Equals(new LU<L, X1, X2>(y));

        public LU(L Label, X1 x1)
        {
            this.label = Label;
            this.x1 = x1;
            this.x2 = none<X2>();
        }

        public LU((L Label, X1 x1) x1)
        {
            this.label = x1.Label;
            this.x1 = x1.x1;
            this.x2 = none<X2>();
        }

        public LU(L Label, X2 x2)
        {
            this.label = Label;
            this.x1 = none<X1>();
            this.x2 = x2;
        }

        public LU((L Label, X2 x2) x2)
        {
            this.label = x2.Label;
            this.x1 = none<X1>();
            this.x2 = x2.x2;
        }



        public L label { get; }

        public Option<X1> x1 { get; }

        public Option<X2> x2 { get; }

        public Option<Y1> Match<Y1>(Func<X1, Y1> f)
            => x1.Map(x => f(x));

        public Option<Y2> Match<Y2>(Func<X2, Y2> f)
            => x2.Map(x => f(x));

        public U<Y1, Y2, Y3, Y4> Match<Y1, Y2, Y3, Y4>(Func<X1, Y1> f1, Func<X2, Y2> f2)
            => first(
                Match(f1).Map(x => du<Y1, Y2, Y3, Y4>(x)),
                Match(f2).Map(x => du<Y1, Y2, Y3, Y4>(x))
                );

        public Y Map<Y>(Func<object, Y> f)
            => x1 ? x1.MapRequired(x => f(x))
            : x2 ? x2.MapRequired(x => f(x))
            : default;

        public LU<L, X1, X2, X3> WithType<X3>()
             => ldu<L, X1, X2, X3>(label, x1, x2, default(X3));


        public override bool Equals(object obj)
            => obj is LU<L, X1, X2>
            ? Equals((LU<L, X1, X2>)obj) : false;

        public bool Equals(LU<L, X1, X2> other)
            => object.Equals(this.label,other.label)
            && this.x1 == other.x1            
            && this.x2 == other.x2
            ;

        public override string ToString()
            => string.Join(Symbol.or.Spaced(),
                format(x1), format(x2)
                );

        public override int GetHashCode()
            => Map(x => x.GetHashCode());
    }




}