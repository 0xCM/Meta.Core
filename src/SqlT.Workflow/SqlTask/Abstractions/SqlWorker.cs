//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;


    public abstract class SqlWorker : NodeComponent, ISqlWorker
    {
        protected SqlWorker(ISqlContext Context)
            : base(Context)
        {
            this.Broker = new SqlClientBroker(Context.SqlConnector, OnSqlNotification);            
        }

        ISqlRuntimeProvider RuntimeProvider
            => C.SqlRuntimeProvider();

        protected ISqlClientBroker Broker { get; }

        protected new ISqlContext C
            => base.C as ISqlContext;

        protected ISqlServerRuntime Server
            => RuntimeProvider.Server(new SqlServerInstanceHandle(Broker, C.SqlConnector.ServerName));

        protected ISqlDatabaseRuntime Database
            => RuntimeProvider.Database(new SqlDatabaseHandle(Broker, C.SqlConnector.DatabaseName));

        protected ISqlSequenceRuntime Sequence(SqlSequenceName SequenceName)
            => RuntimeProvider.Sequence(new SqlSequenceHandle(Broker, SequenceName));

        protected ISqlTableRuntime Table(SqlTableName TableName)
            => RuntimeProvider.Table(new SqlTableHandle(Broker, TableName));

        protected ISqlIndexRuntime Index(SqlTableName TableName, SqlIndexName IndexName)
            => RuntimeProvider.Index(new SqlIndexHandle(Broker, TableName,  IndexName));

        protected virtual void OnSqlNotification(SqlNotification message)
            => C.Notify(message.ToApplicationMessage());

        public abstract ISqlTaskResult Execute(ISqlTask task);

        public virtual IEnumerable<ISqlTaskResult> Execute(IEnumerable<ISqlTask> tasks)
            => tasks.Select(Execute);

    }

    public abstract class SqlWorker<T,R> : SqlWorker
        where T : ISqlTask
        where R : ISqlTaskResult
    {
        protected SqlWorker(ISqlContext C)
            : base(C)
        {

        }

        public abstract R Execute(T task);
    }

}