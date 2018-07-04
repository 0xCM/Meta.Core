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

    /// <summary>
    /// Manages a transaction scope
    /// </summary>
    class SqlBrokerSession : ISqlBrokerSession
    {
        protected static TransactionScope CreateScope(bool autonomous = false)
        {
            if (!autonomous)
            {
                //See http://blogs.msdn.com/b/dbrowne/archive/2010/06/03/using-new-transactionscope-considered-harmful.aspx for
                //the reasoning behind these options
                var options = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.MaximumTimeout
                };
                return new TransactionScope(TransactionScopeOption.Required, options);
            }
            else
            {
                return new
                    TransactionScope(TransactionScopeOption.RequiresNew, TransactionManager.MaximumTimeout);
            }
        }

        readonly ISqlClientBroker Broker;
        readonly SqlConnection Connection;
        readonly Guid SessionToken;
        readonly Action<Guid> SessionEnded;
        readonly Action<SqlNotification> Observer;
        TransactionScope Scope;

        public SqlConnection SessionConnection 
            => Connection;

        public SqlBrokerSession(ISqlClientBroker Broker, Action<Guid> SessionEnded, Action<SqlNotification> observer)
        {
            this.Broker = Broker;
            this.Observer = observer;
            this.Scope = CreateScope(false);
            this.Connection = new SqlConnection(Broker.ConnectionString);
            observer?.Observe(this.Connection);
            this.Connection.Open();           
            this.SessionToken = Guid.NewGuid();
            this.SessionEnded = SessionEnded;
        }

        public void CompleteSession(bool success)
        {
            if (Scope != null && success)
                Scope.Complete();
            else
            {
                if (Scope != null)
                {
                    Scope.Dispose();
                    Scope = null;
                }
            }
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Dispose();

            if (Scope != null)
                Scope.Dispose();

            SessionEnded(SessionToken);
        }


    }
}
