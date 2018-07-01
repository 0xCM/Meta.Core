//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public delegate Y LFolder<X, CX, Y>(Func<X, Y, Y> f, Y y0, CX container)
        where CX : IContainer<X>;

    public delegate Y RFolder<X, CX, Y>(Func<Y, X, Y> f, Y y0, CX container)
        where CX : IContainer<X>;

    /// <summary>
    /// Identifies and characterizes the <see cref="Modules.Foldable"/> typeclass
    /// </summary>
    public interface IFoldable : ITypeclass
    {

    }

    public interface IFoldable<X,CX> : IFoldable, ITypeclass<X,CX>
        where CX : IContainer<X>
    {
        X fold(IMonoid<X> m, CX container);

        Y foldr<Y>(Func<X, Y, Y> f, Y y0, CX container);

        Y foldl<Y>(Func<Y, X, Y> f, Y y0, CX container);

    }

}