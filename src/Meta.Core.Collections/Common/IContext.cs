//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    public interface IContextFactory<X, CX>
        where CX : IContext<X, CX>
    {

        CX CreateContext(IEnumerable<X> Data);
    }


    public interface IContext
    {


    }

    public interface IContext<X> : IContext
    {

    }

    /// <summary>
    /// Identifies and characterizes a computational context of 
    /// type <typeparamref name="CX"/> over a type <typeparamref name="X"/>
    /// </summary>
    /// <typeparam name="X">The ground type</typeparam>
    /// <typeparam name="CX">The context type</typeparam>
    public interface IContext<X,CX> : IContext<X>
       where CX : IContext<X,CX>
    {

    }




}