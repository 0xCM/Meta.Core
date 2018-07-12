//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using Meta.Core;
    
    using MetaFlow.Core;

    public interface INodeConfiguration : INodeComponent
    {
        IEnumerable<SqlDatabaseServer> DatabaseServers();
       
        IEnumerable<PlatformNode> PlatformNodes();        
    }
}
