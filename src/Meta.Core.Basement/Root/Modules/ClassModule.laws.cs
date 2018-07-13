//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;


    public interface IClassModule : ICodeModule
    {


    }

    public interface IClassModule<M> : IClassModule
        where M : IClassModule<M>, new()
    {


    }


}