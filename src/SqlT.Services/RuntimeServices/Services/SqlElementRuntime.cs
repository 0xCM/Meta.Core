//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

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
            => Broker.ExecuteNonQuery(SqlGenerator.GenerateScript(element).ScriptText);

    }



}