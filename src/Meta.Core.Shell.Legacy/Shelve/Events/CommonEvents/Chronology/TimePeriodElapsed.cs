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


    /// <summary>
    /// Occurs when a period of time elapses
    /// </summary>
    public sealed class TimePeriodElapsed : NodeEvent<TimeSpan>
    {
        public TimePeriodElapsed(N SourceNode, TimeSpan Period, CorrelationToken? CT = null, DateTime? Timestamp = null)
            : base(SourceNode, Period, ErrorCondition: false, CT: CT, EventTS: Timestamp)
        {


        }

    }


}