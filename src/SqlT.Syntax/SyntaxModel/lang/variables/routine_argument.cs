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

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;        
    using static metacore;

    partial class SqlSyntax
    {

        public sealed class routine_argument : SyntaxExpression<routine_argument>, sxc.routine_argument
        {

            public static implicit operator routine_argument(date_literal argument_value)
                => new routine_argument(argument_value);

            public static implicit operator routine_argument(string_literal argument_value)
                => new routine_argument(argument_value);

            public static implicit operator routine_argument(routine_argument_value argument_value)
                => new routine_argument(argument_value);

            public static implicit operator routine_argument(CoreDataValue argument_value)
                => new routine_argument(new scalar_value(argument_value));

            public static implicit operator routine_argument((routine_arg_name name, routine_argument_value value) arg)
                => new routine_argument(arg);


            public routine_argument(SqlVariableName argument_value)
            {
                this.argument_value = argument_value;
            }

            public routine_argument(date_literal argument_value)
            {
                this.argument_value = argument_value;
            }

            public routine_argument(string_literal argument_value)
            {
                this.argument_value = argument_value;
            }

            public routine_argument(routine_argument_value argument_value, routine_arg_name arg_name = null)
            {
                this.argument_value = argument_value;
                this.arg_name = arg_name;
            }

            public routine_argument((routine_arg_name name, routine_argument_value value) arg)
            {
                this.argument_value = arg.value;
                this.arg_name = arg.name;
            }

            public routine_argument(ISyntaxExpression argument_value, routine_arg_name arg_name = null)
            {
                this.argument_value = new routine_argument_value(argument_value);
                this.arg_name = arg_name;
            }

            public ModelOption<routine_arg_name> arg_name { get; }

            public routine_argument_value argument_value { get; }

            sxc.routine_argument_value sxc.routine_argument.argument_value
                => argument_value;

            public override string ToString()
                => arg_name.map(
                    name => $"{name.v2} = {argument_value}", 
                    () => argument_value.ToString());

        }



    }


}