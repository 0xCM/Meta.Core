//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    partial class etude
    {
        public static Union<X1, X2> du<X1, X2>(X1 x)
            => new Union<X1, X2>(x);

        public static Union<X1, X2> du<X1, X2>(X2 x)
            => new Union<X1, X2>(x);

        public static Union<X1, X2> du<X1, X2>(Option<X1> x1, Option<X2> x2)
            => x1.IsSome() ? du<X1, X2>(x1.ValueOrDefault())
            : du<X1, X2>(x2.Require());

        public static Union<X1, X2, X3> du<X1, X2, X3>(X1 x1)
            => new Union<X1, X2, X3>(x1);

        public static Union<X1, X2, X3> du<X1, X2, X3>(X2 x2)
            => new Union<X1, X2, X3>(x2);

        public static Union<X1, X2, X3> du<X1, X2, X3>(X3 x3)
            => new Union<X1, X2, X3>(x3);

        public static Union<X, X, X> du31<X>(X x1)
            => new Union<X, X, X>(x1: x1);

        public static Union<X, X, X> du32<X>(X x2)
            => new Union<X, X, X>(x2: x2);

        public static Union<X, X, X> du33<X>(X x3)
            => new Union<X, X, X>(x3: x3);

        public static Union<X1, X2, X3> du<X1, X2, X3>(Option<X1> x1, Option<X2> x2, Option<X3> x3)
            => x1.IsSome() ? du<X1, X2, X3>(x1.ValueOrDefault())
            : x2.IsSome() ? du<X1, X2, X3>(x2.ValueOrDefault())
            : du<X1, X2, X3>(x3.Require());

        public static Union<X1, X2, X3, X4> du<X1, X2, X3, X4>(X1 x)
            => new Union<X1, X2, X3, X4>(x);

        public static Union<X1, X2, X3, X4> du<X1, X2, X3, X4>(X2 x)
            => new Union<X1, X2, X3, X4>(x);

        public static Union<X1, X2, X3, X4> du<X1, X2, X3, X4>(X3 x)
            => new Union<X1, X2, X3, X4>(x);

        public static Union<X1, X2, X3, X4> du<X1, X2, X3, X4>(X4 x)
            => new Union<X1, X2, X3, X4>(x);

        public static Union<X1, X2, X3, X4> du<X1, X2, X3, X4>(Option<X1> x1, Option<X2> x2, Option<X3> x3, Option<X4> x4)
            => x1.IsSome() ? du<X1, X2, X3, X4>(x1.ValueOrDefault())
            : x2.IsSome() ? du<X1, X2, X3, X4>(x2.ValueOrDefault())
            : x3.IsSome() ? du<X1, X2, X3, X4>(x3.ValueOrDefault())
            : du<X1, X2, X3, X4>(x4.Require());

        public static Union<Y1, Y2> match<X1, Y1, X2, Y2>(Union<X1, X2> x,
            Func<X1, Y1> f1, Func<X2, Y2> f2)
                => du(x.Match(f1), x.Match(f2));

        public static Union<Y1, Y2, Y3> match<X1, Y1, X2, Y2, X3, Y3>(Union<X1, X2, X3> x,
            Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
                => du(x.Match(f1), x.Match(f2), x.Match(f3));

        public static Union<Y1, Y2, Y3, Y4> match<X1, Y1, X2, Y2, X3, Y3, X4, Y4>(Union<X1, X2, X3, X4> x,
            Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4)
                => du(x.Match(f1), x.Match(f2), x.Match(f3), x.Match(f4));

    }
}