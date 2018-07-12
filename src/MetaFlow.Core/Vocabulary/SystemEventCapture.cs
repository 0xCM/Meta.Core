//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using static metacore;

    using Meta.Core;
    using SqlT.Core;
    using MetaFlow.WF;
    using N = SystemNodeIdentifier;

    public class SystemEventCapture<TBody> : ISystemEventCapture<TBody>
        where TBody : class, ISystemEvent, new()
    {
        public SystemEventCapture
            (
                N SourceNode,
                SystemIdentifier SourceSystem,
                TBody EventBody,
                ISystemEventIdentity Identity = null,
                CorrelationToken? CT = null,
                int SeverityLevel = 0,
                DateTime? EventTS = null
            )
        {


            this.SourceNode = SourceNode;
            this.SourceSystem = SourceSystem;
            this.EventBody = EventBody;
            this.FormattedBody = JsonServices.ToJson(EventBody);
            this.EventName = $"{SourceSystem}/{typeof(TBody).Name}";
            this.EventType = typeof(TBody);
            this.CT = CT;
            this.Identity = Identity ?? new SystemEventIdentity(Guid.NewGuid(), null);            
            this.SeverityLevel = SeverityLevel;
            this.EventUri = SystemEventUri.Define(SourceNode, SourceSystem, typeof(TBody), this.Identity);
            this.ErrorCondition = SeverityLevel < 0;
            this.EventTS = EventTS ?? now();
        }
        public Guid EventId
            => Identity.EventId;

        public Guid? PairId
            => Identity.PairId;

        public ISystemEventIdentity Identity { get; }

        public SystemEventUri EventUri { get; }

        public int SeverityLevel { get; }

        public TBody EventBody { get; }

        string FormattedBody { get; }

        public N SourceNode { get; }

        public SystemIdentifier SourceSystem { get; }

        public string EventName { get; }

        public Type EventType { get; }

        public DateTime EventTS { get; }

        public bool ErrorCondition { get; }

        public CorrelationToken? CT { get; }

        string ISystemEventCapture.SourceNodeId
        {
            get { return SourceNode; }
            set { }
        }

        Guid? ISystemEventCapture.PairId
        {
            get { return PairId; }
            set { }
        }

        Guid ISystemEventCapture.EventId
        {
            get { return EventId; }
            set { }
        }

        string ISystemEventCapture.SourceSystemId
        {
            get {return SourceSystem;}
            set { }
        }

        string ISystemEventCapture.EventType
        {
            get { return EventType.Name; }
            set { }
        }
                

        string ISystemEventCapture.EventUri
        {
            get { return EventUri; }
            set { }
        }


        string ISystemEventCapture.CorrelationToken
        {
            get { return CT; }
            set { }
        }
            
        int ISystemEventCapture.SeverityLevel
        {
            get { return SeverityLevel; }
            set { }
        }

        string ISystemEventCapture.EventBody
        {
            get { return FormattedBody; }
            set { }
        }

        DateTime ISystemEventCapture.EventTS
        {
            get { return EventTS; }
            set { }
        }

        public SystemNotification ToNotification(string FormattedMessage = null)
            =>  new SystemNotification

            (
                   EventId: Identity.EventId,
                   PairId: Identity.PairId,
                   SourceNodeId: SourceNode,
                   SourceSystemId: SourceSystem,
                   EventType: EventName,
                   EventUri: EventUri,
                   CorrelationToken: CT,
                   SeverityLevel: SeverityLevel,
                   EventTS: EventTS,
                   EventBody: FormattedBody,
                   FormattedMessage: FormattedMessage ?? string.Empty
              );

        public SystemEventCapture Captured()
            => new SystemEventCapture
            (
                   EventId: Identity.EventId,
                   PairId: Identity.PairId,
                   SourceNodeId: SourceNode,
                   SourceSystemId: SourceSystem,
                   EventType: EventName,
                   EventUri: EventUri,
                   CorrelationToken: CT,
                   SeverityLevel: SeverityLevel,
                   EventTS: EventTS,
                   EventBody: FormattedBody 
              );
        
    }
}
