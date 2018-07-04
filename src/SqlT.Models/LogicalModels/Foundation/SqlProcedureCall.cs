//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    

    public abstract class SqlProcedureCall<T> : SqlCommandAction<T>
        where T : SqlProcedureCall<T>
    {

        protected SqlProcedureCall(SqlObjectName ProcedureName, params SqlRoutineParameter[] Parameters)
            : base(ProcedureName, Parameters)
        {
            

        }
    }






}
