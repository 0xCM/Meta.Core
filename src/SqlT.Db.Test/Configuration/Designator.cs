using System.Collections.Generic;
using System.Reflection;
using Meta.Core.Project;
using System.Linq;
using SqlT.Core;

using static metacore;


[assembly: AssemblyProduct(SqlTDbTest.ProductName)]
[assembly: AssemblyVersion(SqlTDbTest.AssemblyVersion)]

public class SqlTDbTest : SqlTModule<SqlTDbTest>
{
    public static IEnumerable<Assembly> RequiredComponents
        => union(SqlTOperations.SystemComponents.Load(),
                MetaCoreOperations.SystemComponents.Load(),
                stream(SqlTSqlDocs.Assembly));


    public SqlTDbTest()
    {
        iter(RequiredComponents.Where(a => a.IsProxyAssembly()), 
            a => a.RegisterSqlProxies());
    }

    public override IReadOnlyList<Assembly> ModuleDependencies
        => RequiredComponents.ToReadOnlyList();

}