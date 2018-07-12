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


    public interface IProxyServices : INodeService
    {
        Option<int> SaveAssemblyDescriptions(IEnumerable<SystemProxyAssembly> Descriptions);

        IEnumerable<SqlProxyGenerationResult> GenerateDefinedProxies(SqlDatabaseName Database, bool PLL);

        IEnumerable<SqlProxyGenerationResult> GenerateProxySelection(params string[] profileNames);

        IEnumerable<SqlProxyGenerationResult> GeneratePlatformProxies(bool PLL);
    }


}