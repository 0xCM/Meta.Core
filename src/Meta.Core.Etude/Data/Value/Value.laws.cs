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


    public interface IValue : ITypeclass
    {

    }

    public interface IValue<X> : IContainer<X>, IEquatable<Value<X>>
    {
        X Data { get; }
    }
}