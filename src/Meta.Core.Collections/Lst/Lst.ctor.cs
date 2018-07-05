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

    public interface ILstTypeCtor<X> : ITypeCtor<G.IEnumerable<X>, X, Lst<X>>
    {

    }

    /// <summary>
    /// List constructor
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct LstTypeCtor<X> : ILstTypeCtor<X>
    {
        public static readonly LstTypeCtor<X> instance = default;

        public Func<G.IEnumerable<X>, Lst<X>> ctor()
            => stream => Lst<X>.Factory(stream);
    }
}