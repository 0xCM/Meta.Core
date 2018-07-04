//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;

    using SqlT.Core;
    using SqlT.Models;



    public class SqlWorkflowProcStep : SqlWorkflowRoutineStep<SqlProcedureName>
    {
        public SqlWorkflowProcStep(SqlProcedureName Name, Type ProcedureType, Type ResultType)
            : base(Name, ProcedureType, ResultType)
        {
        }

        public SqlWorkflowProcStep(SqlProcedureProxyInfo info)
            : base(info.ObjectName, info.RuntimeType, info.ResultProxy?.RuntimeType)
        {
        }


    }

    public class SqlWorkflowProcStep<P, R> : SqlWorkflowProcStep
        where P : class, ISqlProcedureProxy<P, R>, new()
        where R : class, new()

    {


        static SqlProcedureProxyInfo Describe()
            => SqlProxy.DescribeProcedure<P>();


        public SqlWorkflowProcStep()
            : base(Describe())
        {

        }

    }



}
