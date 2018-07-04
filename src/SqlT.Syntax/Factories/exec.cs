//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using static SqlSyntax;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using sxc = contracts;
    
    partial class sql
    {

        public static procedure_call exec(SqlProcedureName procedure_name, params routine_argument[] proc_args)
            => new procedure_call(procedure_name, new routine_argument_list(proc_args));

        public static sxc.procedure_call exec<P>(P p, params sxc.routine_argument[] args)
            where P : sxc.procedure => new procedure_call<P>(p, args);


    }

}