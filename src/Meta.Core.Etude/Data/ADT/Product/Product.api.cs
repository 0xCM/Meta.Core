//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Meta.Core;

using static adt;

partial class etude
{

    public static Product<X1, X2> product<X1, X2>(X1 x1, X2 x2)
        => (x1, x2);

    public static Product<X1, X2, X3> product<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => (x1, x2, x3);

    public static Product<X1, X2, X3, X4> product<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => (x1, x2, x3, x4);

    public static Product<X1, X2, X3, X4> product<X1, X2, X3, X4>(Product<X1, X2> x1, Product<X3, X4> x2)
        => new Product<X1, X2, X3, X4>(x1, x2);

    public static Product<U<X1, X2>, U<X3, X4>> product<X1, X2, X3, X4>(U<X1, X2> x1, U<X3, X4> x2)
        => product(x1, x2);

    public static Product<U<X1, X2, X3>, U<X4, X5, X6>> product<X1, X2, X3, X4, X5, X6>(U<X1, X2> x1, U<X3, X4> x2, U<X5, X6> x3)
        => product(x1, x2, x3);

}
