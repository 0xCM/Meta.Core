//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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