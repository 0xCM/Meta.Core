//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using N = SystemNode;
    
public interface ILinkedContext : IApplicationContext
{
    NodeLink Link { get; }

    N SourceNode { get; }

    N TargetNode { get; }

    INodeContext SourceContext { get; }

    INodeContext TargetContext { get; }

    ILinkedContext ReplaceSource(N NewSource);

    ILinkedContext ReplaceTarget(N NewTarget);

    bool LinkedToSelf { get; }
            
}

  
