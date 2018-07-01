//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;
    using System.Collections;
    using G = System.Collections.Generic;
    using I = System.Collections.Immutable;

    /// <summary>
    /// List constructor
    /// </summary>
    /// <typeparam name="X">The element type</typeparam>
    public readonly struct ListC<X> : ITypeConstructor<X, List<X>, G.IEnumerable<X>>
    {
        public static implicit operator TypeConstructor(ListC<X> c)
            => new TypeConstructor(typeof(List<>));

        static readonly ListFactory<X> Factory = List<X>.Factory;

        public static ListFactory<X> ctor()
            => Factory;

        Func<G.IEnumerable<X>, List<X>> ITypeConstructor<X, List<X>, G.IEnumerable<X>>.ctor()
            => source => ctor()(source);
    }


}