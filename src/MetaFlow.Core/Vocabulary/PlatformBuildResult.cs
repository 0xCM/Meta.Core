//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using Meta.Core;
    using Meta.Core.Build;
    using Meta.Core.Project;
    using Meta.Core.Shell;



    using static metacore;



    public class PlatformBuildResult
    {

        public PlatformBuildResult(IEnumerable<SolutionBuildResult> SolutionBuilds)
        {
            SystemBuilds = SolutionBuilds.ToReadOnlyList();
            Succeeded = SolutionBuilds.All(x => x.Succeeded);
        }

        public IReadOnlyList<SolutionBuildResult> SystemBuilds { get; }


        public bool Succeeded { get; }

        public override string ToString()
            => Succeeded ? "Success" : "Fail";

        public IEnumerable<SolutionBuildResult> Failures
            => SystemBuilds.Where(x => not(x.Succeeded));


        public Option<PlatformBuildResult> ToOption()
            => Succeeded 
            ? some(this) 
            : none<PlatformBuildResult>(error($"{Failures.Select(x => x.OwningSystem).ToReadOnlyList()} system solution builds failed"));

    }

}