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


    public interface ITypeclass 
    {

    }

    public interface ITypeclass<X> : ITypeclass

    {

    }

    public interface ITypeclass<X1,X2> : ITypeclass
    {

    }

    public interface ITypeclass<X1, X2, X3> : ITypeclass
    {

    }

    public interface ITypeclass<X1, X2, X3, X4> : ITypeclass
    {

    }

    public interface ITypeclass<X1, X2, X3, X4, X5> : ITypeclass
    {

    }
}