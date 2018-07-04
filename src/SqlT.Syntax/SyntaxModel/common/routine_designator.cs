//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class routine_designator : du<SqlProcedureName, SqlFunctionName, SqlVariableName>
        {

            public static implicit operator routine_designator(SqlFunctionName routine_name)
                => new routine_designator(routine_name);

            public static implicit operator routine_designator(SqlProcedureName routine_name)
                => new routine_designator(routine_name);

            public static implicit operator routine_designator(SqlVariableName routine_variable)
                => new routine_designator(routine_variable);

            public routine_designator(SqlFunctionName routine_name)
                : base(routine_name)
            {

            }

            public routine_designator(SqlVariableName routine_variable)
                : base(routine_variable)
            {

            }

            public routine_designator(SqlProcedureName routine_name)
                : base(routine_name)
            {

            }
        }

    }


}