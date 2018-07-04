//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;


    partial class SqlSyntax
    {

        public class routine_argument_value 
            : Meta.Models.du<
                scalar_value, 
                date_literal,
                string_literal,
                routine_argument_variable, 
                SqlVariableName, 
                kwt.DEFAULT, 
                ISyntaxExpression
                >, sxc.routine_argument_value
        {
            
            public static implicit operator routine_argument_value(scalar_value value)
                => new routine_argument_value(value);

            public static implicit operator routine_argument_value(date_literal value)
                => new routine_argument_value(value);

            public static implicit operator routine_argument_value(string_literal value)
                => new routine_argument_value(value);

            public static implicit operator routine_argument_value(SqlVariableName value)
                => new routine_argument_value(value);

            public static implicit operator routine_argument_value(routine_argument_variable variable)
                => new routine_argument_value(variable);

            public static implicit operator routine_argument_value(kwt.DEFAULT DEFAULT)
                => new routine_argument_value(DEFAULT);


            public routine_argument_value(SqlVariableName value)
                : base(value)
            {


            }


            public routine_argument_value(scalar_value value)
                : base(value)
            {


            }

            public routine_argument_value(date_literal value)
                : base(value)
            {


            }

            public routine_argument_value(string_literal value)
                : base(value)
            {


            }

            public routine_argument_value(routine_argument_variable variable)
                : base(variable)
            {


            }

            public routine_argument_value(kwt.DEFAULT DEFAULT)
                : base(DEFAULT)
            {


            }

            public routine_argument_value(ISyntaxExpression value)
                : base(value)
            {


            }

        }

    }


}