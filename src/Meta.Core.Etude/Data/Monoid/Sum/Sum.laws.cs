//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    public interface ISum : INewtype
    {

    }

    public interface ISum<A> : ISum, INewType<A>
    {
        
    }



}