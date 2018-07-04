//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Represents a stored procedure
    /// </summary>
    public class SqlProcedureHandle : SqlRoutineHandle, ISqlProcedureHandle
    {

        public SqlProcedureHandle(ISqlClientBroker Broker, SqlProcedureName ProcedureName)
            : base(Broker, ProcedureName)
        {
            this.ElementName = ProcedureName;
        }

        public new SqlProcedureName ElementName { get; }
    }

    /// <summary>
    /// Represents a stored procedure with a fixed/known set of parameters that have been 
    /// encapsulated by a specified type
    /// </summary>
    /// <typeparam name="TParam">The type that encapsulates the parameters</typeparam>
    public class SqlProcedureHandle<TParam> : SqlProcedureHandle
        where TParam : class, ISqlProcedureProxy, new()
    {
        public SqlProcedureHandle(ISqlProxyBroker Broker)
            : base(Broker, PXM.ProcedureName<TParam>())
        {

        }
    }

    /// <summary>
    /// Represents a stored procedure with a specified set of parameters as well as a
    /// singular result set
    /// </summary>
    /// <typeparam name="TParam">The type that encapsulates the parameters</typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class SqlProcedureHandle<TParam, TResult> : SqlProcedureHandle<TParam>
        where TParam : class, ISqlProcedureProxy, new()
    {
        public SqlProcedureHandle(ISqlProxyBroker Broker)
            : base(Broker)
        {
        }

    }
}
