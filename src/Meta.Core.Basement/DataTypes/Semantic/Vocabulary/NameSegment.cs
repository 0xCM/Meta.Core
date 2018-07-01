//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Represents discrete part of a semantic name
/// </summary>
public abstract class NameSegment<B, V> : INameSegment<V>
    where B : NameSegment<B, V>
{
    protected NameSegment(string Name)
    { }

    protected NameSegment()
    {
        SegmentType = typeof(B).Name;
    }

    public string SegmentType { get; }

    public abstract string Render(V value);

    public abstract V Parse(string value);

    object INameSegment.Parse(string value)
       => Parse(value);

    string INameSegment.Render(object value)
        => Render((V)value);
}

public class NameSegment<V> : NameSegment<NameSegment<V>, V>
    where V : INameSegment<V>
{
    INameSegment<V> AdaptedSegment;


    public NameSegment(V src)
        : base(src.SegmentType)
    {
        this.AdaptedSegment = src;
    }

    public override string Render(V value)
        => AdaptedSegment.Render(value);

    public override V Parse(string value)
        => AdaptedSegment.Parse(value);

}
public sealed class NameSegment : NameSegment<NameSegment, object>
{
    INameSegment AdaptedSegment;
    

    public NameSegment(INameSegment src)
        : base(src.SegmentType)
    {
        this.AdaptedSegment = src;
    }

    public override string Render(object value)
        => AdaptedSegment.Render(value);

    public override object Parse(string value)
        => AdaptedSegment.Parse(value);

}

