using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SqlT.Core;

using static metacore;



public class SqlTShell : SqlTModule<SqlTShell>
{
    public static IEnumerable<Assembly> RequiredComponents
        => union(SqlTCore.Assembly, MetaCoreOperations.SystemComponents.Load());
        //=> union(SqlTOperations.SystemComponents.Load(),
        //        MetaCoreOperations.SystemComponents.Load(),
        //        stream(SqlTSqlDocs.Assembly));


    public SqlTShell()
    {
        iter(RequiredComponents.Where(a => a.IsProxyAssembly()),
            a => a.RegisterSqlProxies());
    }

    public override IReadOnlyList<Assembly> ModuleDependencies
        => RequiredComponents.ToReadOnlyList();

}