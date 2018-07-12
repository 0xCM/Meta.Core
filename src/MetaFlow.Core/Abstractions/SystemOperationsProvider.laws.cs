//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using SqlT.Core;
    using Meta.Core;

    using static metacore;

    public interface ISystemOperationsProvider  : IPlatformComponent
    {
        IEnumerable<Assembly> LoadedComponents { get; }

        IEnumerable<SystemOperation> ProvidedOperations { get; }
    }


}
