//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SqlT.Core;
    using SqlT.Models;

    abstract class SqlElementRuntime<T, H> : ApplicationComponent, ISqlElementRuntime
        where T : SqlElementRuntime<T, H>
        where H : ISqlHandle
    {
        protected H Handle { get; }

        public ISqlClientBroker Broker
            => Handle.Broker;

        
        protected ISqlRuntimeProvider SqlRuntime { get; }

        protected ISqlGenerator SqlGenerator { get; }

        

        protected SqlElementRuntime(IApplicationContext C, H Handle)
            : base(C)
        {
            this.Handle = Handle;
            this.SqlRuntime = C.SqlRuntimeProvider();
            this.SqlGenerator = C.SqlGenerator();
            
        }

        public override string ToString()
            => Handle.ToString();

        public ISqlDatabaseRuntime Database
            => SqlRuntime.Database(Handle.Database());

        protected virtual void OnSqlNotification(SqlNotification Message)
            => Notify(Message.ToApplicationMessage());

        protected Option<int> CreateElement(ISqlElement element)
            => Broker.ExecuteNonQuery(SqlGenerator.GenerateScript(element).ScriptText).ToOption();

    }



}