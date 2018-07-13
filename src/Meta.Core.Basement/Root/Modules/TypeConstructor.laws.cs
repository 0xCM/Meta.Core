//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ITypeConstructor<M, X, MX>
        where M : IClassModule<M>, new()
        where MX : IContext<X, MX>, new()
    {
        MX construct();
    }



}



