//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public class SystemDacDeploymentSummary
    {
        public SystemDacDeploymentSummary(SystemIdentifier System, IEnumerable<DacDeploymentSummary> Deployments)
        {
            this.System = System;
            this.Deployments = Deployments.ToReadOnlyList();
        }

        public SystemIdentifier System { get; }

        public IReadOnlyList<DacDeploymentSummary> Deployments { get; }

        public bool Succeeded
            => Deployments.All(d => d.Succeded);

        public IApplicationMessage Message
            => Succeeded ?
                inform($"{System} system deployment succeded")
                : error($"{System} system deployment failed. Failing packages: {Deployments.Where(x => not(x.Succeded)).Select(x => x.SourcePackage.FileName).ToReadOnlyList()}");
    }
}