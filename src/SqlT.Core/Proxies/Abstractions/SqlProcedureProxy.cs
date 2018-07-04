//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public abstract class SqlProcedureProxy : SqlRoutineProxy, ISqlProcedureProxy
    {

    }

    public abstract class SqlProcedureProxy<P> : SqlProcedureProxy
        where P : class, ISqlProcedureProxy, new()
    {
        public SqlProcedureProxyInfo Description
            => SqlProxy.DescribeProcedure<P>();

        public P Subject
            => this as P;

    }

    public abstract class SqlProcedureProxy<P, TResult> : SqlRoutineProxy<P, TResult>, ISqlProcedureProxy<P, TResult>
        where P : class, ISqlProcedureProxy<P, TResult>, new()
        where TResult : class, ISqlTabularProxy, new()

    {
        public SqlProcedureProxyInfo Description
            => SqlProxy.DescribeProcedure<P>();

        public P Subject
            => this as P;

    }
}
