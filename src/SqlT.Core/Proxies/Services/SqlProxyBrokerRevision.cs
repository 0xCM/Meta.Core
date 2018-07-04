//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using System.Collections.Concurrent;

    using static metacore;

    using SqlClientParameter = System.Data.SqlClient.SqlParameter;

    partial class SqlProxyBroker
    {
        Option<int> Exec<P>(SqlConnectionCommand command)
            where P : class, ISqlProcedureProxy, new()
        {
            try
            {
                using (command)
                    return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return SqlOutcome<int>.Fail(error($"Call to {ProcName<P>()} failed: {e}"));
            }
        }

        Option<SqlConnectionCommand> CreateCommand(ISqlProcedureProxy proc, SqlDatabaseName db = null)
        {
            try
            {
                var _db = ifNull(db, () => new SqlDatabaseName(ConnectionString.DatabaseName));
                var proxyType = proc.GetType();
                var description = Metadata.Describe<SqlProcedureProxyInfo>(proc.GetType());
                var name = ScopeNameToDatabase(proxyType, _db).AsProcedureName();
                var command = CreateProcedureCommand(name);
                command.Parameters.AddRange(CreateClientParameters(description, proc).ToArray());
                return command;
            }
            catch (Exception e)
            {
                return none<SqlConnectionCommand>(e);
            }
        }

        Option<int> ISqlProxyBroker.Exec<P>(P proc)
            => from command in CreateCommand(proc)
               from result in Exec<P>(command)
               select result;

        Option<int> ISqlProxyBroker.Call(ISqlProcedureProxy proc)
        {
            try
            {
                var _command = CreateCommand(proc);
                if (!_command)
                    return SqlOutcome.Failure<int>(_command.Message);

                using (var cmd = _command.Require())
                    return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return none<int>(error($"Call to {ProcName(proc.GetType())} failed: {e}"));
            }

        }

    }

}