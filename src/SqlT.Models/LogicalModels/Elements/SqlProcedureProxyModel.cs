//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using static metacore;
    using SqlT.Core;



    public abstract class SqlProcedureProxyModel<P, X, Y> : SqlProcedure<P, X, Y>
        where P : SqlProcedureProxyModel<P, X, Y>
        where X : ISqlTabularProxy, new()
        where Y : ISqlTabularProxy, new()
    {
        protected SqlProcedureProxyModel()
            : base(SqlProcedureName.Empty, rolist<SqlRoutineParameter>())
        {

        }

        

    }



}