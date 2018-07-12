using System;
using System.Reflection;
using SqlT.Core;

[assembly: SqlProxyAssembly]

public class MetaFlowWorkflowProxies : SqlProxyAssembly<MetaFlowWorkflowProxies>
{

    public MetaFlowWorkflowProxies()
    {
        MetaFlowCoreTypes.Assembly.RegisterSqlProxies();
    }


}

