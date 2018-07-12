//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Concurrent;

    using Meta.Core;

    using SqlT.Syntax;
    using SqlT.Core;

    using static SqlT.Syntax.SqlSyntax;
    using static SqlT.Syntax.sql;    

    using static metacore;

    class SqlLogMessageBroker : ISqlLogMessageBroker
    {

        AppMessageObserver Sentinel { get; }

        ISqlClientOptionBroker TargetBroker { get; }

        ConcurrentDictionary<Guid, Guid> RoutedMessages { get; }
            = new ConcurrentDictionary<Guid, Guid>();

        ConcurrentDictionary<string, ConcurrentBag<AppMessageSubscriber>> subscribers
            = new ConcurrentDictionary<string, ConcurrentBag<AppMessageSubscriber>>();

        public SqlLogMessageBroker(SqlConnectionString TargetConnector, AppMessageObserver Sentinel = null)
        {
            this.TargetConnector = TargetConnector;
            this.Sentinel = Sentinel;
            this.TargetBroker = TargetConnector.SqlClientBroker();
        }

        /// <summary>
        /// Removes the identified subscriber
        /// </summary>
        /// <param name="MessageType">The message type to which the subscriber is presumably observing</param>
        /// <param name="subscriber">The subscriber to be removed</param>
        void Unsubscribe(string MessageType, AppMessageSubscriber subscriber)
            => subscribers[MessageType].TryTake(out subscriber);

        public SqlConnectionString TargetConnector { get; }

        public IDisposable Listen(AppMessageObserver Observer, string messageTypeName)
        {
            var mtn = messageTypeName ?? nameof(IAppMessage);
            var subscriber = new AppMessageSubscriber(mtn, Observer, Unsubscribe);
            subscribers.GetOrAdd(mtn, t => new ConcurrentBag<AppMessageSubscriber>())
                        .Add(subscriber);
            return subscriber;
        }

        static string FormatMessage(IAppMessage message)
        {
            var text = message.Format(false);
            return text.Replace('%', 'π');
        }

        static SqlScript ToSqlMessage(IAppMessage message)
            => raiserror(FormatMessage(message), WITH, NOWAIT).FormatSyntax();

        public CorrelationToken? Route(IAppMessage message, bool immediate)
        {

            if (!RoutedMessages.TryAdd(message.MessageId, message.MessageId))
                return message.CT;

            TargetBroker.ExecuteNonQuery(ToSqlMessage(message)).OnNone(m => Console.WriteLine(m.Format()));

            Sentinel?.Invoke(message);

            foreach (var mtn in subscribers.Keys)
            {
                if (mtn == message.MessageType || mtn == nameof(IAppMessage))
                {
                    foreach (var subscriber in subscribers[mtn])
                        subscriber.Observer(message);
                }
            }
           
            return message.CT;
        }

        public void Dispose() { }
    }
}