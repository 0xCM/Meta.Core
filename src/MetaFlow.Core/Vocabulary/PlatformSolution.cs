//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using SqlT.Core;
    using Meta.Core.Project;

    using N = SystemNodeIdentifier;


    public class PlatformSolution
    {
        public PlatformSolution(SystemIdentifier DefiningSystem, SolutionName SolutionName)
        {
            this.DefiningSystem = DefiningSystem;
            this.SolutionName = SolutionName;
        }

        public SystemIdentifier DefiningSystem { get; }

        public SolutionName SolutionName { get; }

        public override string ToString()
            => $"{DefiningSystem}/{SolutionName}";

    }


}