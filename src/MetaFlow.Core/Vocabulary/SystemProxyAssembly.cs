//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;


    public class SystemProxyAssembly
    {
        public SystemProxyAssembly(ClrAssembly Assembly, IEnumerable<CodeGenerationProfile> GenerationProfiles)
        {
            this.Assembly = Assembly;
            this.GenerationProfiles = GenerationProfiles.ToReadOnlyList();
            this.DesignatorName = Assembly.Designator.Map(d => d.GetType().Name, () => Assembly.Identifier.IdentifierText);
            this.DefiningSystem = Assembly.DefiningSystem();
        }

        public SystemIdentifier DefiningSystem { get; }

        public ClrAssembly Assembly { get; }

        public string DesignatorName { get; }

        public IReadOnlyList<CodeGenerationProfile> GenerationProfiles { get; }

    }




}