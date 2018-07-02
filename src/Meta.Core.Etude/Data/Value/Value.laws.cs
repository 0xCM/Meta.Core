//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public interface IValue : ITypeClass
    {

    }




    public interface IValue<X> : IContainer<X,Value<X>>, IEquatable<Value<X>>
    {
        X Data { get; }
    }
}