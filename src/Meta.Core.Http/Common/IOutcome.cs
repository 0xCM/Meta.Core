//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public interface IOutcome
{
    bool Succeeded { get; }
    object Payload { get; }
    IEnumerable<IApplicationMessage> Messages { get; }
}

public interface IOutcome<P> : IOutcome
{
    new P Payload { get; }
}

