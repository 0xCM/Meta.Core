//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    /// <summary>
    /// Contract for a factory that 
    /// 1. Produces computational contexts of type <typeparamref name="CX"/>
    /// 2. Where: The pduced contexts are parameterized by <typeparamref name="X"/>
    /// 3. Where: Instances of the context are created predicated on 
    /// an input value of type <typeparamref name="Data"/>
    /// </summary>
    /// <typeparam name="Data">The type of the data required to create an instance of the context</typeparam>
    /// <typeparam name="X">The type over which the context is parameterized</typeparam>
    /// <typeparam name="CX">The context type</typeparam>
    public interface ITypeCtor<Data, X, CX>
        where CX : IContext<X>
    {
        Func<Data, CX> ctor();
    }

}



