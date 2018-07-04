//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using N = SystemNode;


    sealed class SqlSessionManager : ApplicationService<SqlSessionManager, ISqlSessionManager>, ISqlSessionManager
    {

        IDictionary<string, ILinkedSqlSession> SessionIdx { get; }
            = new Dictionary<string, ILinkedSqlSession>();


        static string SessionName(N Host, Type SessionType)
            => $"{Host.NodeIdentifier}/{SessionType}";


        public SqlSessionManager(IApplicationContext C)
            : base(C)
        {

        }


        public ILinkedSqlSession GetSession(Type SessionType, N Host, SqlDatabaseName DbName)
        {
            var name = SessionName(Host, SessionType);
            if (SessionIdx.ContainsKey(name))
                return SessionIdx[name];

            var session = (ILinkedSqlSession)Activator.CreateInstance(SessionType, array<object>(C, DbName));
            SessionIdx.Add(name, session);
            return session;
        }

        public ILinkedSqlSession GetSession<T>(N Host, SqlDatabaseName DbName)
            where T : ILinkedSqlSession
            => GetSession(typeof(T), Host, DbName);


    }

}