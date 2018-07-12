//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Diagnostics.Tracing;
    using Meta.Core;

    using static metacore;
    using static StatusMessages;

    using MetaFlow.WF;
    using SqlT.Core;   

    class SystemMessaging : PlatformService<SystemMessaging,ISystemMessaging>, ISystemMessaging
    {

        public SystemMessaging(INodeContext C)
            : base(C)
        {

            CommandWorkflow = C.CommandWorkflow();
            EventHub = C.SystemEventHub();
        }
        
        protected ISystemCommandWorkflow CommandWorkflow { get; }

        protected ISystemEventHub EventHub { get; }
      
        ISystemEventCapture<TBody> CaptureSystemEvent<TBody>(TBody Body, CorrelationToken? CT = null, EventLevel EventLevel = EventLevel.Informational)
                where TBody : class, ISystemEvent, new()
                    => new SystemEventCapture<TBody>(
                        SourceNode: Host, 
                        SourceSystem: typeof(TBody).DefiningSystem(), 
                        EventBody: Body, 
                        CT: CT ?? CorrelationToken.Create(), 
                        SeverityLevel: (int)EventLevel                       
                        );

        ISystemEventCapture<TBody> RaiseSystemEvent<TBody>(TBody Body, CorrelationToken? CT = null, EventLevel EventLevel = EventLevel.Informational)
            where TBody : class, ISystemEvent, new()
        {
            var capture = CaptureSystemEvent(Body, CT, EventLevel);
            EventHub.RaiseEvent(capture);
            return capture;
        }

        ISystemEventCapture<TBody> CapturePairedEvent<TBody>(ISystemEventCapture Antecedent, TBody Body)
            where TBody : class, ISystemEvent, new()
                => new SystemEventCapture<TBody>
                (
                      SourceNode: Host,
                      SourceSystem: typeof(TBody).DefiningSystem(),
                      EventBody: Body,
                      Identity: new SystemEventIdentity(Guid.NewGuid(), Antecedent.EventId),
                      CT: Antecedent.CorrelationToken,                      
                      SeverityLevel: Antecedent.SeverityLevel
                    );


        public ISystemEventCapture<TBody> RaiseStatus<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new()
                => RaiseSystemEvent(Body, CT, EventLevel.Informational);

        public ISystemEventCapture<TBody> RaiseWarning<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new()
            => RaiseSystemEvent(Body, CT, EventLevel.Warning);

        public ISystemEventCapture<TBody> RaiseError<TBody>(TBody Body, CorrelationToken? CT = null)
            where TBody : class, ISystemEvent, new()
                => RaiseSystemEvent(Body, CT, EventLevel.Error);

        public ISystemEventCapture<TBody> RaisePaired<TBody>(ISystemEventCapture Antecedent, TBody Body)
            where TBody : class, ISystemEvent, new()
        {
            var capture = CapturePairedEvent(Antecedent, Body);
            EventHub.RaiseEvent(capture);
            return capture;
        }
    
        public Option<SystemTask> SubmitCommand<K>(K Command, CorrelationToken? CT = null)
               where K : class, ISystemCommand, ISqlTableTypeProxy, new()
                => CommandWorkflow.Submit(Command, CT ?? CorrelationToken.Create())
                        .OnNone(Notify).OnSome(task => Notify(TaskCreated(task)));

    }

}