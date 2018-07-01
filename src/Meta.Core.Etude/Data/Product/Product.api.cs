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

        public static Product<X1, X2> product<X1, X2>(X1 x1, X2 x2)
            => (x1, x2);

        public static Product<X1, X2, X3> product<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
            => (x1, x2, x3);

        public static Product<X1, X2, X3, X4> product<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
            => (x1, x2, x3, x4);

        public static Product<X1, X2, X3, X4> product<X1, X2, X3, X4>(Product<X1, X2> x1, Product<X3, X4> x2)
            => new Product<X1, X2, X3, X4>(x1, x2);

        public static Product<Union<X1, X2>, Union<X3, X4>> product<X1, X2, X3, X4>(Union<X1, X2> x1, Union<X3, X4> x2)
            => product(x1, x2);

        public static Product<Union<X1, X2, X3>, Union<X4, X5, X6>> product<X1, X2, X3, X4, X5, X6>(Union<X1, X2> x1, Union<X3, X4> x2, Union<X5, X6> x3)
            => product(x1, x2, x3);

    }
}