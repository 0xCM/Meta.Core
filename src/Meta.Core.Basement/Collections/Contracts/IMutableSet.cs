//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using G = System.Collections.Generic;
    using System.Linq;

    public interface IMutableSet<X> : G.ISet<X>, IReadOnlySet<X>
    {

    }
}
