//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ICategory 
    {

    }

    public interface ICategory<X> : ICategory, ITypeClass<X>
    {
        X id(X x);

        Func<X, A, C> compose<A, B, C>(Func<X, B, C> f, Func<X, A, B> g);
    }

    public interface ICategory<X,A,B,C> : ICategory
    {
        X id(X x);

        Func<X, A, C> compose(Func<X, B, C> f, Func<X, A, B> g);

    }


}