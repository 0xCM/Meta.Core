//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public class routine_argument_variable : SyntaxExpression<routine_argument_variable>
        {
            public routine_argument_variable(routine_arg_name variable_name)
            {
                this.variable_name = variable_name;
            }

            public routine_argument_variable(routine_arg_name variable_name, kwt.OUTPUT OUTPUT)
            {
                this.variable_name = variable_name;
                this.OUTPUT = OUTPUT;
            }

            public ModelOption<kwt.OUTPUT> OUTPUT { get; }

            public routine_arg_name variable_name { get; }
        }


    }

}