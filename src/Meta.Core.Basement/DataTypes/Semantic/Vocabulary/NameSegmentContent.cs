//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

public struct NameSegmentContent : INameSegmentContent
{

    public static implicit operator NameSegmentContent((NameSegment Segment, object Value) sv)
        => new NameSegmentContent(sv);

    public static implicit operator (NameSegment Segment, object Value) (NameSegmentContent sv)
        => new NameSegmentContent(sv);

    public NameSegmentContent((NameSegment Segment, object Value) sv)
        : this(sv.Segment, sv.Value) { }

    public NameSegmentContent(NameSegment Segment, object Value)
    {
        this.Segment = Segment;
        this.Value = Value;
    }
    public NameSegment Segment { get; }

    public object Value { get; }

    public override string ToString()
        => Segment.Render(Value);
}

public struct NameSegmentContent<V>  : INameSegmentContent<V>
    where V:INameSegmentContent
    
{
    public static implicit operator NameSegmentContent<V>((NameSegment Segment, V Value) sv)
        => new NameSegmentContent<V>(sv);

    public static implicit operator (NameSegment Segment, V Value) (NameSegmentContent<V> sv)
        => new NameSegmentContent<V>(sv);

    public NameSegmentContent((NameSegment Segment, V Value) sv)
        : this(sv.Segment, sv.Value) { }

    public NameSegmentContent(NameSegment Segment, V Value)
    {
        this.Segment = Segment;
        this.Value = Value;
    }
    public NameSegment Segment { get; }

    public V Value { get; }

    object INameSegmentContent.Value
        => Value;

    public override string ToString()
        => Segment.Render(Value);

}
