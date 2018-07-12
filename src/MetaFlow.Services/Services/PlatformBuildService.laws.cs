//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;
    using Meta.Core.Build;

    using static metacore;

    public interface IPlatformBuildService
    {
        SolutionBuildResult BuildSystemSolution(SystemIdentifier System);

        PlatformBuildResult BuildPlatform();
    }
}