//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public delegate Func<CX, CY> InvariantMap<X, CX, Y, CY>(Func<X, Y> f, Func<Y,X> g)
        where CX : IContainer<X>
        where CY : IContainer<Y>;

    public interface IInvariant : ITypeClass
    {

    }

    public interface IInvariant<X, CX, Y, CY> : IInvariant, ITypeClass<X, CX, Y, CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {
        Func<CX, CY> imap(Func<X, Y> f, Func<Y, X> g);
    }


}