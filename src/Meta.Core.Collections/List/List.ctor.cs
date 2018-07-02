//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    
    using G = System.Collections.Generic;

    public interface IListTypeCtor<X> : ITypeCtor<G.IEnumerable<X>, X, List<X>>
    {

    }

    /// <summary>
    /// List constructor
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct ListTypeCtor<X> : IListTypeCtor<X>
    {
        public static readonly ListTypeCtor<X> instance = default;

        public Func<G.IEnumerable<X>, List<X>> ctor()
            => stream => List<X>.Factory(stream);
    }
}