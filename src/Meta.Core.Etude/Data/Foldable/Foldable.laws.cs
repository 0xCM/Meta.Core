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
    /// Specifies the required signature of a left fold operation
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="CX"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="f"></param>
    /// <param name="y0"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public delegate Y LFolder<X, CX, Y>(Func<X, Y, Y> f, Y y0, CX context)
        where CX : IContext<X>;

    /// <summary>
    /// Specifies the required signature of a right fold operation
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <typeparam name="CX">A context parametrized by the item type</typeparam>
    /// <typeparam name="Y">The type of the accumulated value</typeparam>
    /// <param name="f">The fold accumulator</param>
    /// <param name="y0"></param>
    /// <param name="container"></param>
    /// <returns></returns>
    public delegate Y RFolder<X, CX, Y>(Func<Y, X, Y> f, Y y0, CX container)
        where CX : IContext<X>;

    /// <summary>
    /// Identifies and characterizes the <see cref="Modules.Foldable"/> typeclass
    /// </summary>
    public interface IFoldable : ITypeClass
    {

    }


    public interface IFoldable<X,CX> : IFoldable, ITypeClass<X,CX>
        where CX : IContext<X>
    {
        X fold(IMonoid<X> m, CX context);

        Y foldr<Y>(Func<X, Y, Y> f, Y y0, CX context);

        Y foldl<Y>(Func<Y, X, Y> f, Y y0, CX context);

    }

}