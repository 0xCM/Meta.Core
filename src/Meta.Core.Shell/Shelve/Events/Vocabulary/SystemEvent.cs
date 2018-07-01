//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using N = SystemNodeIdentifier;

    using static metacore;

    public sealed class SystemEvent : SystemNodeEvent<string>
    {
        public SystemEvent(N SourceNode, SystemIdentifier SourceSystem, string EventName, string Body = null, CorrelationToken? CT = null, bool ErrorCondition = false, DateTime? Timestamp = null)
            : base(SourceNode, SourceSystem, Body ?? string.Empty, EventName, CT, ErrorCondition, Timestamp)
        {

        }

    }



}