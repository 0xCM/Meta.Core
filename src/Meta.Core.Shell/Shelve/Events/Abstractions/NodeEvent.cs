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


    public abstract class NodeEvent<TBody> : INodeEvent<TBody>
    {
        protected NodeEvent
        (
            N SourceNode, 
            TBody Body = default(TBody),
            string EventType = null,
            CorrelationToken? CT = null, 
            bool ErrorCondition = false,  
            DateTime? EventTS = null
        )
        {
            this.SourceNode = SourceNode;
            this.EventType = EventType ?? GetType().Name;
            this.Body = Body;
            this.ErrorCondition = ErrorCondition;
            this.CT = CT ?? CorrelationToken.Create();
            this.EventTS = EventTS ?? now();
            
        }

        public string EventType { get; }

        public N SourceNode { get; }

        public bool ErrorCondition { get; }

        public CorrelationToken? CT { get; }

        public TBody Body { get; }

        public DateTime EventTS { get; }

        object INodeEvent.Body
            => Body;

        public override string ToString()
            => $"{SourceNode}/{EventType}";

    }



}