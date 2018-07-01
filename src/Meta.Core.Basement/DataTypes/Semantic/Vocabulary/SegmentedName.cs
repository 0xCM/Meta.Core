//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;


public abstract class SegmentedName<N,S> : SemanticIdentifier<N,S>, ISegmentedName<S>
    where N : SegmentedName<N,S>
    where S : IReadOnlyList<S>, INameSegment
{
    protected SegmentedName(S Segments)
        : base(Segments)
    {
        this.Segments = Segments;

    }

    public S Segments { get; }

    IReadOnlyList<INameSegment> ISegmentedName.Segments
        => Segments.Cast<INameSegment>().ToReadOnlyList();
}

