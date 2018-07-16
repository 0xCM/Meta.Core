//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IIdentity : ITypeClass
    { }

    public interface IIdentity<X> : IIdentity, ITypeClass<X>
    {

    }

}