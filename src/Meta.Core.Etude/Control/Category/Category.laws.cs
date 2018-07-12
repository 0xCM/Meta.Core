//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ICategory : ITypeClass
    {

    }

    public interface ICategory<A> : ICategory, ITypeClass<A>
    {
        A id(A x);

        Func<A, X, Z> compose<X, Y, Z>(Func<A, Y, Z> f, Func<A, X, Y> g);
    }

    public interface ICategory<X,A,B,C> : ICategory
    {
        X id(X x);

        Func<X, A, C> compose(Func<X, B, C> f, Func<X, A, B> g);

    }


}