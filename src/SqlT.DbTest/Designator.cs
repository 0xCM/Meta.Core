//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SqlT.Core;

using static metacore;



public class SqlTDbTest : SqlTModule<SqlTDbTest>
{
    public static IEnumerable<Assembly> RequiredComponents
        => unionize(SqlTPlatform.SystemComponents.Load(),
                MetaCorePlatform.SystemComponents.Load());


    public SqlTDbTest()
    {
        iter(RequiredComponents.Where(a => a.IsProxyAssembly()), 
            a => a.RegisterSqlProxies());
    }

    public override IReadOnlyList<Assembly> ModuleDependencies
        => RequiredComponents.ToReadOnlyList();

}