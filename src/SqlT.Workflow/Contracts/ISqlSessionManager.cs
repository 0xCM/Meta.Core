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

    public interface ISqlSessionManager
    {
        ILinkedSqlSession GetSession(Type SessionType, N Host, SqlDatabaseName DbName);

        ILinkedSqlSession GetSession<T>(N Host, SqlDatabaseName DbName)
            where T : ILinkedSqlSession;

    }
}
