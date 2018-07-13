//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Linq;

    public delegate V ValueConstructor<out V>();

    public delegate V ValueConstructor<in X1, out V>(X1 x1);

    public delegate V ValueConstructor<in X1, in X2, out V>(X1 x1, X2 x2);

    public delegate V ValueConstructor<in X1, in X2, in X3, out V>(X1 x1, X2 x2, X3 x3);

    public delegate V ValueConstructor<in X1, in X2, in X3, in X4, out V>(X1 x1, X2 x2, X3 x3, X4 x4);

    public delegate V ValueConstructor<in X1, in X2, in X3, in X4, in X5, out V>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5);

    public delegate V ValueConstructor<in X1, in X2, in X3, in X4, in X5, in X6, out V>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6);

    public delegate V ValueConstructor<in X1, in X2, in X3, in X4, in X5, in X6, in X7, out V>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7);
}