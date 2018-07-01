//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using N = SystemNode;

public abstract class LinkedComponent : ApplicationComponent, ILinkedComponent
{

    public LinkedComponent(ILinkedContext C)
        : base(C)
    {
        this.C = C;
    }

    protected new ILinkedContext C { get; private set; }

    public new ILinkedContext Context
        => C;


    protected void Relink(NodeLink NewLink)
      => C =  new LinkedContext(base.C, NewLink);

    protected N SourceNode
        => Link.Source;

    protected N TargetNode
        => Link.Target;

    public NodeLink Link
        => C.Link;
}