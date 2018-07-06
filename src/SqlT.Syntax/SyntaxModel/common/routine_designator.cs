//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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