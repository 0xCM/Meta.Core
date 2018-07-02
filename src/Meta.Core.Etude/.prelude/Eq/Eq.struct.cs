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

    /// <summary>
    /// Defines a type conforming to <see cref="IEq{X}"/> predicated on 
    /// a constructor-injected <see cref="Equator{X}"/>
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct Eq<X> : IEq<X>
    {
        /// <summary>
        /// The default <see cref="IEq"/> instance, predicated 
        /// on the default (or custom) <see cref="object.Equals(object, object)"/> method
        /// </summary>
        public static readonly Eq<X> instance 
            = new Eq<X>((x, y) => Equals(x, y));

        Equator<X> Equator { get; }

        public Eq(Equator<X> Equator)
            => this.Equator = Equator;

        public bool eq(X x1, X x2)
            => Equator(x1, x2);
    }

    public readonly struct Eq<X, CX> : IEq<X, CX>
        where CX : IContainer<X>
    {

        public static readonly Eq<X, CX> instance
            = new Eq<X, CX>((cx, cy) => Equals(cx, cy));

        public Eq(Equator<X,CX> Equator)
            => this.Equator = Equator;

        Equator<X,CX> Equator { get; }

        public bool eq(CX cx1, CX cx2)
            => Equator(cx1, cx2);
    }
}