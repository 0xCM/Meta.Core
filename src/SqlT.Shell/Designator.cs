using System.Collections.Generic;
using System.Reflection;
using Meta.Core.Project;
using System.Linq;
using SqlT.Core;

using static metacore;


//[assembly: AssemblyProduct(SqlTShell.ProductName)]
//[assembly: AssemblyVersion(SqlTShell.AssemblyVersion)]

public class SqlTShell : SqlTModule<SqlTShell>
{
    public static IEnumerable<Assembly> RequiredComponents
        => union(
                stream(SqlTSqlDocs.Assembly,
                    SqlTCore.Assembly,
                    SqlTModels.Assembly,
                    SqlTServices.Assembly,
                    SqlTLanguage.Assembly,
                    SqlTSqlDocs.Assembly,
                    SqlTSharp.Assembly,
                    SqlTWorkflow.Assembly,
                    SqlTSyntax.Assembly,
                    MetaCoreServices.Assembly,
                    MetaCoreWorkflow.Assembly,
                    MetaCoreBuild.Assembly
                    ));


    public SqlTShell()
    {
        iter(RequiredComponents.Where(a => a.IsProxyAssembly()), 
            a => a.RegisterSqlProxies());
    }

    public override IReadOnlyList<Assembly> ModuleDependencies
        => RequiredComponents.ToReadOnlyList();

}