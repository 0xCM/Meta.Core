//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IShow : ITypeClass
    {

    }

    public interface IShow<X> : IShow, ITypeClass<X>
    {
        string show(X value);
    }

}