//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;



public static partial class Union
{
    internal static string component<X>(X x)
        => $"{typeof(X).DisplayName()}:{x}";

    internal static string format<T>(Option<T> option)
        => option.Map(value => $"{typeof(T).DisplayName()}:{value}", () => typeof(T).DisplayName());

    public static U<X1, X2> du<X1, X2>(X1 x)
        => new U<X1, X2>(x);

    public static U<X1, X2> du<X1, X2>(X2 x)
        => new U<X1, X2>(x);

    public static LU<L, X1> ldu<L, X1>(L label, X1 x)
        => new LU<L, X1>(label, x);

    public static LU<L, X1, X2> ldu<L, X1, X2>(L label, X1 x)
        => new LU<L, X1, X2>(label, x);

    public static LU<L, X1, X2> ldu<L, X1, X2>(L label, X2 x)
        => new LU<L, X1, X2>(label, x);

    public static U<X1, X2> du<X1, X2>(Option<X1> x1, Option<X2> x2)
        => x1.IsSome() ? du<X1, X2>(x1.ValueOrDefault())
        : du<X1, X2>(x2.Require());

    public static LU<L, X1, X2> ldu<L, X1, X2>(L label, Option<X1> x1, Option<X2> x2)
        => x1.IsSome() ? ldu<L, X1, X2>(label, x1.ValueOrDefault())
        : ldu<L, X1, X2>(label, x2.Require());

    public static U<X1, X2, X3> du<X1, X2, X3>(X1 x1)
        => new U<X1, X2, X3>(x1);

    public static U<X1, X2, X3> du<X1, X2, X3>(X2 x2)
        => new U<X1, X2, X3>(x2);

    public static U<X1, X2, X3> du<X1, X2, X3>(X3 x3)
        => new U<X1, X2, X3>(x3);

    public static U<X, X, X> du31<X>(X x1)
        => new U<X, X, X>(x1: x1);

    public static U<X, X, X> du32<X>(X x2)
        => new U<X, X, X>(x2: x2);

    public static U<X, X, X> du33<X>(X x3)
        => new U<X, X, X>(x3: x3);

    public static U<X1, X2, X3> du<X1, X2, X3>(Option<X1> x1, Option<X2> x2, Option<X3> x3)
        => x1.IsSome() ? du<X1, X2, X3>(x1.ValueOrDefault())
        : x2.IsSome() ? du<X1, X2, X3>(x2.ValueOrDefault())
        : du<X1, X2, X3>(x3.Require());

    public static U<X1, X2, X3, X4> du<X1, X2, X3, X4>(X1 x)
        => new U<X1, X2, X3, X4>(x);

    public static U<X1, X2, X3, X4> du<X1, X2, X3, X4>(X2 x)
        => new U<X1, X2, X3, X4>(x);

    public static U<X1, X2, X3, X4> du<X1, X2, X3, X4>(X3 x)
        => new U<X1, X2, X3, X4>(x);

    public static U<X1, X2, X3, X4> du<X1, X2, X3, X4>(X4 x)
        => new U<X1, X2, X3, X4>(x);

    public static LU<L, X1, X2, X3> ldu<L, X1, X2, X3>(L label, X1 x1)
        => new LU<L, X1, X2, X3>(label, x1);

    public static LU<L, X1, X2, X3> ldu<L, X1, X2, X3>(L label, X2 x2)
        => new LU<L, X1, X2, X3>(label, x2);

    public static LU<L, X1, X2, X3> ldu<L, X1, X2, X3>(L label, X3 x3)
        => new LU<L, X1, X2, X3>(label, x3);

    public static LU<L, X1, X2, X3> ldu<L, X1, X2, X3>(L label, Option<X1> x1, Option<X2> x2, Option<X3> x3)
        => x1.IsSome() ? ldu<L, X1, X2, X3>(label, x1.ValueOrDefault())
        : x2.IsSome() ? ldu<L, X1, X2, X3>(label, x2.ValueOrDefault())
        : ldu<L, X1, X2, X3>(label, x3.Require());

    public static LU<L, X1, X2, X3, X4> ldu<L, X1, X2, X3, X4>(L label, X1 x1)
        => new LU<L, X1, X2, X3, X4>(label, x1);

    public static LU<L, X1, X2, X3, X4> ldu<L, X1, X2, X3, X4>(L label, X2 x2)
        => new LU<L, X1, X2, X3, X4>(label, x2);

    public static LU<L, X1, X2, X3, X4> ldu<L, X1, X2, X3, X4>(L label, X3 x3)
        => new LU<L, X1, X2, X3, X4>(label, x3);

    public static LU<L, X1, X2, X3, X4> ldu<L, X1, X2, X3, X4>(L label, X4 x4)
        => new LU<L, X1, X2, X3, X4>(label, x4);

    public static LU<L, X1, X2, X3, X4> ldu<L, X1, X2, X3, X4>(L label, Option<X1> x1, Option<X2> x2, Option<X3> x3, Option<X4> x4)
        => x1.IsSome() ? ldu<L, X1, X2, X3, X4>(label, x1.ValueOrDefault())
        : x2.IsSome() ? ldu<L, X1, X2, X3, X4>(label, x2.ValueOrDefault())
        : x3.IsSome() ? ldu<L, X1, X2, X3, X4>(label, x3.ValueOrDefault())
        : ldu<L, X1, X2, X3, X4>(label, x4.Require());

    public static U<X1, X2, X3, X4> du<X1, X2, X3, X4>(Option<X1> x1, Option<X2> x2, Option<X3> x3, Option<X4> x4)
        => x1.IsSome() ? du<X1, X2, X3, X4>(x1.ValueOrDefault())
        : x2.IsSome() ? du<X1, X2, X3, X4>(x2.ValueOrDefault())
        : x3.IsSome() ? du<X1, X2, X3, X4>(x3.ValueOrDefault())
        : du<X1, X2, X3, X4>(x4.Require());

    public static U<Y1, Y2> match<X1, Y1, X2, Y2>(U<X1, X2> x,
        Func<X1, Y1> f1, Func<X2, Y2> f2)
            => du(x.Match(f1), x.Match(f2));

    public static U<Y1, Y2, Y3> match<X1, Y1, X2, Y2, X3, Y3>(U<X1, X2, X3> x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3)
            => du(x.Match(f1), x.Match(f2), x.Match(f3));

    public static U<Y1, Y2, Y3, Y4> match<X1, Y1, X2, Y2, X3, Y3, X4, Y4>(U<X1, X2, X3, X4> x,
        Func<X1, Y1> f1, Func<X2, Y2> f2, Func<X3, Y3> f3, Func<X4, Y4> f4)
            => du(x.Match(f1), x.Match(f2), x.Match(f3), x.Match(f4));


}

