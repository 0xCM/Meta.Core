//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ICategory : ISemigroupoid
    {

    }

    public interface ICattegory<X> : ISemigroupoid<X>
    {
        X identity(X x);
    }


}