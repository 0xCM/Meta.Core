//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;



public interface ILink
{
    LinkIdentifier Name { get; }
}

public interface ILink<X> : ILink
{

    X Source { get; }

    X Target { get; }
}


public interface ILink<X,Y> : ILink
{
    X Source { get; }

    Y Target { get; }

}