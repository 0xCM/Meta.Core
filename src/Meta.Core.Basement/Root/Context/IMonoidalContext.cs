//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public interface IMonoidalContext<X,CX> : IMonoid<CX>
        where CX : IContext<X,CX>, new()
    {

    }

   
}