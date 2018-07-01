//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using N = SystemNode;


public abstract class NodeComponent : ApplicationComponent, INodeComponent
{

    protected NodeComponent(INodeContext C)
        : base(C)
    {

        this.Host = C.Host;
        this.C = C;
    }

    public N Host { get; }


    protected new INodeContext C { get; }

    public override string ComponentName
        => $"{Host}/{GetType().Name}";

}

