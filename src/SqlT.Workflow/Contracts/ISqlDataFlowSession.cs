//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using static metacore;

    using N = SystemNode;
    using Db = SqlT.Core.SqlDatabaseName;

    public interface ILinkedSqlSession
    {
        /// <summary>
        /// Returns source broker for active node/active database
        /// </summary>
        /// <returns></returns>
        ISqlClientBroker SourceBoker();

        /// <summary>
        /// Returns source broker for specified node/active database
        /// </summary>
        /// <param name="Host"></param>
        /// <returns></returns>
        ISqlClientBroker SourceBroker(N Host);

        /// <summary>
        ///  Returns source broker for specified node/specified database
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
        ISqlClientBroker SourceBroker(N Host, Db Database);

        /// <summary>
        /// Returns target broker for active node/active database
        /// </summary>
        /// <returns></returns>
        ISqlClientBroker TargetBroker();

        /// <summary>
        /// Returns target broker for specified node/active database
        /// </summary>
        /// <param name="Host"></param>
        /// <returns></returns>
        ISqlClientBroker TargetBroker(N Host);

        /// <summary>
        ///  Returns target broker for specified node/specified database
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
        ISqlClientBroker TargetBroker(N Host, Db Database);
    }

}