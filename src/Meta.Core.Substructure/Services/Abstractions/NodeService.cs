//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using N = SystemNode;

public abstract class NodeService<S,I> : ApplicationService<S,I>, INodeService
    where S : NodeService<S,I>
{

    protected NodeService(INodeContext C)
        : base(C)
    {



    }


    protected new INodeContext C
        => base.C as INodeContext;

    public N Host
        => C.Host;

}
