using System;
using System.Reflection;
using SqlT.Core;

[assembly: SqlProxyAssembly]
[assembly: AssemblyVersion(SqlTZ0.AssemblyVersion)]
[assembly: AssemblyProduct(SqlTZ0.ProductName)]
[assembly: AssemblyClassifier(ComponentClassification.DataProxy)]
[assembly: AssemblyTitle(nameof(SqlTZ0))]

public class SqlTZ0 : SqlProxyAssembly<SqlTZ0>
{
    public const string ProductName = "SqlT/Z0";
    public const string AssemblyVersion = "1.0.0";

    public SqlTZ0()
    {
        SqlTZ0.Assembly.RegisterSqlProxies();
    }


}

