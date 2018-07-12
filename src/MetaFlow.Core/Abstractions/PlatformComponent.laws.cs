//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;

    public interface IPlatformComponent : IAssemblyDesignator
    {
        SystemIdentifier DefiningSystem { get; }
    }


}