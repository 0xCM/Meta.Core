//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;

    public interface ISqlProjection
    {
        IEnumerable<ISqlTabularProxy> Push(IEnumerable<ISqlTabularProxy> input);
    }

    public interface ISqlProjection<in TSrc, out TDst> : ISqlProjection
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new()
    {
        IEnumerable<TDst> Push(IEnumerable<TSrc> src);
    }
}
