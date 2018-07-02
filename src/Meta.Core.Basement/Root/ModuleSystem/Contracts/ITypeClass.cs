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


    public interface ITypeClass 
    {

    }

    public interface ITypeClass<X> : ITypeClass

    {

    }

    public interface ITypeClass<X1,X2> : ITypeClass
    {

    }

    public interface ITypeClass<X1, X2, X3> : ITypeClass
    {

    }

    public interface ITypeClass<X1, X2, X3, X4> : ITypeClass
    {

    }

    public interface ITypeClass<X1, X2, X3, X4, X5> : ITypeClass
    {

    }
}