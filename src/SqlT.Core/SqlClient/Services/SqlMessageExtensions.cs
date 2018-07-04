//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Transactions;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Collections.Generic;

    static class SqlMessageExtensions
    {
        static void Relay(SqlNotification n, SqlNotificationObserver o)
            => o(n);

        public static void Observe(this Action<SqlNotification> observer, SqlCommand command)
        {
            void OnStatementCompeted(object sender, StatementCompletedEventArgs e)
            {
                observer(new SqlNotification(sender.ToString(),
                    $"{e.RecordCount} records affected", new SqlNotificationMessage[] { }));
            }

            command.StatementCompleted += OnStatementCompeted;
        }

        public static void Relay(this SqlNotificationObserver observer, SqlConnection connection, bool observeLifecycle = false)
            => Observe(n => Relay(n, observer), connection, observeLifecycle);

        public static void Observe(this Action<SqlNotification> observer, SqlConnection connection, bool observeLifecycle = false)
        {
            void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
            {
                var notification = new SqlNotification
                    (
                        args.Source,
                        args.Message,
                        args.Errors.Cast<SqlError>().Select(e => new SqlNotificationMessage
                        {
                            LineNumber = e.LineNumber,
                            MessageContent = e.Message,
                            MessageId = e.Number,
                            MessageSeverity = e.Class,
                            Procedure = e.Procedure,
                            Provider = e.Source,
                            Server = e.Server,
                            State = e.State
                        })
                    );
                observer(notification);
            }

            void OnStateChanged(object sender, StateChangeEventArgs e)
                => observer(new SqlNotification(sender.ToString(),
                    $"Connection changed from {e.OriginalState} to {e.CurrentState}",
                    new SqlNotificationMessage[] { })
                    );
            
            void OnDisposed(object sender, EventArgs e)
                => observer(new SqlNotification(sender.ToString(),
                    $"Connection disposed",
                    new SqlNotificationMessage[] { })
                    );
            
            connection.InfoMessage += OnInfoMessage;

            if (observeLifecycle)
            {
                connection.StateChange += OnStateChanged;
                connection.Disposed += OnDisposed;
            }
        }

    }



}