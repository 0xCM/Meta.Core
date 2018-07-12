//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface IBifunctor : ITypeClass
    {

    }

    public interface IBifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2> : IBifunctor
       where CX1 : IContainer<X1, CX1>, new()
       where CX2 : IContainer<X2, CX2>, new()
       where CY1 : IContainer<Y1, CY1>, new()
       where CY2 : IContainer<Y2, CY2>, new()
    {
        Func<(CX1, CX2), (CY1, CY2)> bimap(Func<X1, Y1> f, Func<X2, Y2> g);
    }

    public delegate Func<(CX1, CY1), (CX2, CY2)> BifunctorMap<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2>(Func<X1, Y1> f, Func<X2, Y2> g)
       where CX1 : IContainer<X1, CX1>, new()
       where CX2 : IContainer<X2, CX2>, new()
       where CY1 : IContainer<Y1, CY1>, new()
       where CY2 : IContainer<Y2, CY2>, new();

    

}