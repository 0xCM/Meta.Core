//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

public interface ISegmentedName
{
    IReadOnlyList<INameSegment> Segments { get; }
}

public interface ISegmentedName<S> : ISegmentedName
    where S : IReadOnlyList<S>, INameSegment
{
    new S Segments { get; }
}