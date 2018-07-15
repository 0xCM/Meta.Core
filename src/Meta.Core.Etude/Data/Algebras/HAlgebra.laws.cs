//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;



    public interface IHAlgebra : ITypeClass
    {

    }

    public interface IHAlgebra<A> : IHAlgebra, ITypeClass<A>
    {
        A ff { get; }

        A tt { get; }

        A implies(A a1, A a2);

        A conj(A a1, A a2);

        A disj(A a1, A a2);

        A not(A a);
    }

}