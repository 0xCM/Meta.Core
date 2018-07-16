//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using static minicore;

public static partial class Product
{
    public static P<X1> make<X1>(X1 x1)
        => new P<X1>(x1);

    public static IProduct make(params object[] values)
    {
        var len = values.Length;
        var typeDef = 
            len is 1 ? typeof(P<>) :
            len is 2 ? typeof(P<,>) :
            len is 3 ? typeof(P<,,>) :
            len is 4 ? typeof(P<,,,>) 
            : fail<Type>(IndexOutOfRange(len));
        var type = typeDef.MakeGenericType(values.Select(v => v.GetType()).ToArray());
        return Activator.CreateInstance(type, values) as IProduct;                   
    }
   

    public static P<X1,X2> make<X1, X2>(X1 x1, X2 x2)
        => new P<X1,X2>(x1,x2);

    public static P<X1, X2, X3> make<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
        => new P<X1, X2, X3>(x1, x2, x3);

    public static P<X1, X2, X3, X4> make<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
        => new P<X1, X2, X3, X4>(x1, x2, x3, x4);

    public static P<X1, X2> smash<X1, X2, X3, X4>(P<X1> p1, P<X2> p2)
        => make(p1.x1, p2.x1);

    public static P<X1, X2, X3> smash<X1, X2, X3, X4>(P<X1> p1, P<X2,X3> p2)
        => make(p1.x1, p2.x1, p2.x2);

    public static P<X1, X2, X3, X4> smash<X1, X2, X3, X4>(P<X1> p1, P<X2, X3, X4> p2)
        => make(p1.x1, p2.x1, p2.x2, p2.x3);

    public static P<X1, X2, X3> smash<X1, X2, X3, X4>(P<X1, X2> p1, P<X3> p2)
        => make(p1.x1, p1.x2, p2.x1);

    public static P<X1, X2, X3, X4> smash<X1, X2, X3, X4>(P<X1, X2> p1, P<X3,X4> p2)
        => make(p1.x1, p1.x2, p2.x1, p2.x2);

    public static P<X1, X2, X3, X4> smash<X1, X2, X3, X4>(P<X1, X2, X3> p1, P<X4> p2)
        => make(p1.x1, p1.x2, p1.x3, p2.x1);

    public static P<Y1> map<X1, Y1>(Func<P<X1>, P<Y1>> f, P<X1> p)
        => f(p);

    public static P<Y1, Y2> map<X1, Y1, X2, Y2>(Func<P<X1, X2>, P<Y1, Y2>> f, P<X1, X2> p)
        => f(p);

    public static P<Y1, Y2, Y3> map<X1, Y1, X2, Y2, X3, Y3>(Func<P<X1, X2, X3>, P<Y1, Y2, Y3>> f, P<X1, X2, X3> p)
        => f(p);

    public static P<Y1, Y2, Y3, Y4> map<X1, Y1, X2, Y2, X3, Y3, X4, Y4>(Func<P<X1, X2, X3, X4>, P<Y1, Y2, Y3, Y4>> f, P<X1, X2, X3, X4> p)
        => f(p);
}