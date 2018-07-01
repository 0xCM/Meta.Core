//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IIdentity : ITypeclass
    { }

    public interface IIdentity<X> : ITypeclass<X>
    {

    }

}