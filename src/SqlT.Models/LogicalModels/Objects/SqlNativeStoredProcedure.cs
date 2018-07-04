//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Core;

    using System;

    using sxc = SqlT.Syntax.contracts;


    public abstract class SqlNativeProcedure<F> : SqlProcedure<F>, sxc.native_procedure
        where F : SqlNativeProcedure<F>
    {

        internal SqlNativeProcedure(SqlProcedureName ProcedureName)
            : base(ProcedureName.WithSystemSchema(), IsIntrinsic: true)
        {
        }


        internal SqlNativeProcedure(SqlProcedureName ProcedureName, params SqlRoutineParameter[] Parameters)
            : base(ProcedureName.WithSystemSchema(), Parameters, IsIntrinsic: true)
        {

        }


    }


    public class SqlNativeProcedure : SqlNativeProcedure<SqlNativeProcedure>, sxc.native_procedure
    {



        internal SqlNativeProcedure(SqlProcedureName ProcedureName, params SqlRoutineParameter[] Parameters)
            : base(ProcedureName, Parameters)
        {

        }

    }




   

}
