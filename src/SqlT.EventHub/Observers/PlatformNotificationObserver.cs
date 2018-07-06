//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.SqlServer.XEvent.Linq;

    using SqlT.Core;
    using MetaFlow.XE;

    using static metacore;
    using N = SystemNode;

    class PlatformNotificationObserver : ApplicationComponent, IPlatformNotificationObserver
    {
        Option<Task> Worker { get; set; }

        Option<Task> Control { get; set; }

        Option<CorrelationToken> ListenerToken { get; set; }

        public PlatformNotificationObserver(IApplicationContext C, N EventSource, string SessionName)
            : base(C)
        {

            this.EventSource = EventSource;
            this.SessionName = SessionName;
        }

        public N EventSource { get; }

        public string SessionName { get; }

        public override string ToString()
            => concat(EventSource.NodeName, "/xEvents/", SessionName);

        public CorrelationToken Listen(Action<PlatformNotification> Observer, Func<bool> Cancel)
            => ListenerToken.Map(token => token, () =>
            {
                var token = CorrelationToken.Create();
                ListenerToken = token;
                Control = StartListener(Observer, Cancel, token);
                return token;
            });

        Task StartListener(Action<PlatformNotification> Observer, Func<bool> Cancel, CorrelationToken ct)
            => task(() =>
            {
                try
                {
                    Worker.OnNone(() => Worker = task(() => Listen(EventSource, SessionName, Observer, Cancel)));
                    Worker.OnSome(w => w.Wait());
                }
                catch(Exception e)
                {
                    Notify(error(e));
                }
            });

        void Listen(SqlConnectionString connector, string Session, Action<PlatformNotification> Observer, Func<bool> Cancel)
        {
            using (var stream = new QueryableXEventData(connector, Session,
                EventStreamSourceOptions.EventStream,
                EventStreamCacheOptions.DoNotCache))
            {
                foreach (var e in stream)
                {
                    var notification = e.ToPlatformNotification();
                    Observer(notification);

                    if (Cancel())
                        break;
                }
            }
        }

        void Listen(N Src, string Session, Action<PlatformNotification> Observer, Func<bool> Cancel)
        {
            C.SqlConnector(Src).OnSome(connector => Listen(connector, Session, Observer, Cancel))
                            .OnNone(Notify);                     
        }
    }
}