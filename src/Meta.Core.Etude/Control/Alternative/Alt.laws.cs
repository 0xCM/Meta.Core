//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IAlternative<X,CX> : IAlt<X,CX>, IPlus<X,CX>
        where CX : IContainer<X>
    {


    }

}