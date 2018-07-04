//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
   
    using static metacore;

    public sealed class SqlProcedureInvocation<T> : SqlActionInvocation<T>, ISqlProcedureInvocation
         where T : SqlProcedureCall<T>
    {
        public SqlProcedureInvocation(IReadOnlyDictionary<string,object> ArgumentIndex, SqlProcedureCall<T> action)
            : base(ArgumentIndex, action)
        { }

        SqlProcedureName ISqlProcedureInvocation.ProcedureName
            => Action.ActionName;
    }
}