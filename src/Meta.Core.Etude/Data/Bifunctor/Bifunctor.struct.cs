//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;            

    readonly struct Bifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2> : IBifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2>
        where CX1 : IContainer<X1, CX1>, new()
        where CX2 : IContainer<X2, CX2>, new()
        where CY1 : IContainer<Y1, CY1>, new()
        where CY2 : IContainer<Y2, CY2>, new()
    {
        public static readonly Bifunctor<X1, CX1, X2, CX2, Y1, CY1, Y2, CY2> instance = default;

        public Func<(CX1, CX2), (CY1, CY2)> bimap(Func<X1, Y1> f, Func<X2, Y2> g)
        {            
            Func<(CX1, CX2), (CY1, CY2)> _map = ((CX1 cx1, CX2 cx2) x)
                => (new CY1().Factory(from item in x.cx1.Stream() select f(item)), 
                    new CY2().Factory(from item in x.cx2.Stream() select g(item)));
            return _map;
         }
    }
}