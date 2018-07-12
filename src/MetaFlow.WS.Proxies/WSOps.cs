namespace MetaFlow.Proxies.WS
{
    using System;
    using SqlT.Core;
    using System.Collections.Generic;
    using System.Linq;

    public class WorkspaceProxyContext : SqlContext<MetaFlowWorkspaceProxies>
    {
        internal WorkspaceProxyContext(INodeContext C, SqlConnectionString Connector)
            : base(C, Connector)
        {
           
        }

    }



}


