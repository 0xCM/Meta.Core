//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;
    using static SqlSyntax;

    partial class sql
    {
        public static routine_argument arg(ISyntaxExpression value)
            => new routine_argument(new routine_argument_value(value));

        public static routine_argument arg(integer_literal value)
            => new routine_argument(new routine_argument_value(value));

        public static routine_argument arg(string_literal value)
            => new routine_argument(new routine_argument_value(value));

        public static routine_argument arg(date_literal value)
            => new routine_argument(value);

        public static routine_argument arg(SqlVariableName value)
            => new routine_argument(value);

        public static routine_argument arg(routine_arg_name name, ISyntaxExpression value)
            => new routine_argument(new routine_argument_value(value), name);

        public static routine_argument arg(routine_arg_name name, scalar_value value)
            => new routine_argument(arg(value), name);

        public static routine_argument arg(routine_arg_name name, routine_argument_variable value)
            => new routine_argument(value, name);

        public static routine_argument arg(routine_argument_variable value)
            => new routine_argument(value);

        public static routine_argument_list args(params (routine_arg_name name, scalar_value value)[] x)
            => x;

        public static routine_argument_list args(IEnumerable<routine_argument> x)
            => new routine_argument_list(map(x, a => arg(a)));

        public static routine_argument_list args(params scalar_value[] x)
            => new routine_argument_list(map(x, a => arg(a)));

        public static routine_argument_list args(params ISyntaxExpression[] x)
            => new routine_argument_list(map(x, a => arg(a)));

        public static routine_argument_list args(IEnumerable<ISyntaxExpression> args)
            => new routine_argument_list(map(args, a => arg(a)));

        public static routine_argument_list args(ISyntaxExpression arg1, params ISyntaxExpression[] more)
            => args(stream(arg1, more));



    }

}