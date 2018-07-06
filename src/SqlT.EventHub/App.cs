//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    using SqlT.Core;
    using Meta.Core;
    using Meta.Core.Messaging;

    using MetaFlow.Core;
    using MetaFlow.XE;

    using static PlatformNodeIdentifiers;

    using N = SystemNode;

    using static metacore;

    class App : FlowSubsystemShell<App, AppArgs>
    {
        static int Main(string[] args)
            => HandleMain(args);

        public App()
        {

        }

        bool CancelListeners()
            => false;


        void OnPlatformNotification(PlatformNotification message)
                => PlatformNotificationHub.Broadcast(message);
        

        void OnMessage(PlatformNotification message)
            => SystemConsole.Get().WriteLine(message.Format());
        
        IEnumerable<N> ObservableNodes
            => C.PlatformNodes().Where(n => stream(n00, n01, n05).Contains(n.NodeIdentifier));

        IReadOnlyList<(N, CorrelationToken)> Listeners { get; set; }

        int StoppedCount = 0;

        bool Stopping
            => StoppedCount != 0;

        IEnumerable<(N, CorrelationToken)> Listen(IEnumerable<N> Sources, string SessionName, Action<PlatformNotification> Observer, Func<bool> Cancel)
            => from source in Sources
               let listener = new PlatformNotificationObserver(C, source, SessionName)
               let ct = listener.Listen(Observer, Cancel)
               select (listener.EventSource, ct);


        ServiceHost ExchangeHost {get;set;}

        Option<IHubConnection<PlatformNotification>> HubConnection { get; set; }

        void HostExchange()
        {
            task(() =>
            {
                try
                {
                    ExchangeHost = PlatformNotificationHub.HostExchange(PlatformNotificationHubConnection.DefaultExchange);
                    HubConnection = some(PlatformNotificationHubConnection.Create(OnMessage));
                }
                catch(Exception e)
                {
                    Notify(e);
                }
            });
        }

        protected override AppExec OnAppExec(AppExec exec)
        {
            HostExchange();                        
            Notify(inform($"Listening to platform notifications on {string.Join(",", ObservableNodes)}"));
            Listeners = Listen(ObservableNodes, "PlatformNotifications", OnPlatformNotification, CancelListeners).ToReadOnlyList();
            if(!Stopping)
                Console.ReadKey();
            Notify(inform($"Cancelling platform event listeners"));
            StoppedCount++;
            Notify(inform($"Platform notification listener at index {StoppedCount} has stopped"));
            return exec;
        }
    }
}



