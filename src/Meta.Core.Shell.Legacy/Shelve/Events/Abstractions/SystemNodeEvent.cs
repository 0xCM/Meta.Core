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

    public abstract class SystemNodeEvent<TBody> : NodeEvent<TBody>, ISystemNodeEvent<TBody>
    {
        protected SystemNodeEvent
            (
                N SourceNode,
                SystemIdentifier SourceSystem,
                TBody Body = default(TBody),
                string EventName = null, 
                CorrelationToken? CT = null,  
                bool ErrorCondition = false, 
                DateTime? EventTS = null
            )
            : base(SourceNode, Body, EventName, CT,  ErrorCondition, EventTS)
        {

            this.SourceSystem = SourceSystem;
        }


        public SystemIdentifier SourceSystem { get; }
    }

}