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

    using static metacore;
    using sxc = contracts;

    partial class SqlSyntax
    {
        public class function_call : Model<function_call>, sxc.function_call
        {
            public function_call(SqlFunctionName function_name, params sxc.routine_argument[] args)
            {
                this.function_name = function_name;
                this.args = args.ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public function_call(SqlFunctionName function, IEnumerable<sxc.routine_argument> args, keyword_list options)
            {
                this.function_name = function;
                this.args = args.ToRoutineArgList();
                this.options = options;
            }

            public function_call(SqlFunctionName function, IEnumerable<sxc.routine_argument> args, params IKeyword[] options)
            {
                this.function_name = function;
                this.args = args.ToRoutineArgList(); 
                this.options = options;
            }

            public function_call(SqlFunctionName function, sxc.routine_argument arg, params sxc.routine_argument[] args)
            {
                this.function_name = function;
                this.args = stream(arg, args).ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public SqlFunctionName function_name { get; }

            public routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;

            sxc.routine_argument_list sxc.routine_call.args 
                => args;

            public override string ToString()
                => this.Describe();
        }

        public class function_call<f, v> : SyntaxExpression<function_call<f, v>>, sxc.function_call<f, v>
            where f : sxc.function
        {
            public function_call(f function, params sxc.routine_argument[] args)
            {
                this.function = function;
                this.args = args.ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public function_call(f function, routine_argument_list args)
            {
                this.function = function;
                this.args = args;
                this.options = keyword_list.empty;
            }

            public function_call(f function, IEnumerable<sxc.routine_argument> args, keyword_list options)
            {
                this.function = function;
                this.args = args.ToRoutineArgList();
                this.options = options;
            }

            public f function { get; }

            public routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;

            sxc.routine_argument_list sxc.routine_call.args
                => args;

            public SqlFunctionName function_name
                => function.Name;

            public override string ToString()
                => this.Describe();
        }

        public class function_call<F> : SyntaxExpression<function_call<F>>, sxc.function_call
            where F : sxc.function
        {

            public function_call(F F, params sxc.routine_argument[] Arguments)
            {
                this.function = F;
                this.args = Arguments.ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public function_call(F F, routine_argument_list args)
            {
                this.function = F;
                this.args = args.ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public function_call(F F, IEnumerable<sxc.routine_argument> args, keyword_list options)
            {
                this.function = F;
                this.args = args.ToRoutineArgList();
                this.options = options;
            }

            public function_call(F F, sxc.routine_argument arg, params sxc.routine_argument[] args)
            {
                this.function = F;
                this.args = stream(arg, args).ToRoutineArgList();
                this.options = keyword_list.empty;
            }

            public F function { get; }

            public routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;

            sxc.routine_argument_list sxc.routine_call.args
                => args;

            public SqlFunctionName function_name
                => function.Name;

            public override string ToString()
                => this.Describe();
        }
    }
}
