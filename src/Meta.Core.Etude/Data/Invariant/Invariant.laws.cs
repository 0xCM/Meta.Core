//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IInvariant : ITypeclass
    {

    }

    public interface IInvariant<X, CX, Y, CY> : ITypeclass<X, CX, Y, CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {
        CY imap(Func<X, Y> f, Func<Y, X> g, CX Fx);
    }


}