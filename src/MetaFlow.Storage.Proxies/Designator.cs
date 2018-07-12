using System;
using System.Reflection;
using SqlT.Core;

[assembly: SqlProxyAssembly]
public class MetaFlowCoreStorage : SqlProxyAssembly<MetaFlowCoreStorage>
{
    public const string ProductName = "MetaFlow/Core";
    public const string AssemblyVersion = "1.0.*";

    static MetaFlowCoreStorage()
    {
        MetaFlowCoreTypes.Assembly.RegisterSqlProxies();
        SqlTStoreProxies.Assembly.RegisterSqlProxies();
        SqlTZ0.Assembly.RegisterSqlProxies();

    }


}

