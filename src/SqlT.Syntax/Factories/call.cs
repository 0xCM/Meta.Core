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
    using SqlT.Models;

    using static SqlSyntax;
    using static metacore;
 
    using sxc = Syntax.contracts;
    using kwt = SqlKeywordTypes;
 
    partial class sql
    {
        public static function_call<F> call<F>(F f)
            where F : sxc.function => new function_call<F>(f);

        public static function_call<F> call<F>(F f, params scalar_value[] args)
            where F : sxc.function => new function_call<F>(f, sql.args(args));

        public static function_call<F> call<F>(F f, params ISyntaxExpression[] args)
            where F : sxc.function => new function_call<F>(f, sql.args(args));

        public static scalar_function_call<v> call<v>(sxc.scalar_function f, params ISyntaxExpression[] args)
            where v : sxc.scalar_type => new scalar_function_call<v>(f, sql.args(args));

        public static sxc.scalar_function_call call(sxc.function f, sxc.routine_argument arg, params sxc.routine_argument[] args)
            => new scalar_function_call(f.Name, arg, args);

        public static sxc.scalar_function_call call(sxc.function f, routine_argument_list args, params IKeyword[] options)
            => new scalar_function_call(f.Name, args, options);

        static function_call<F> call<F>(F f, sxc.routine_argument arg, params sxc.routine_argument[] args)
            where F : sxc.function => new function_call<F>(f, arg, args);

        static sxc.scalar_function_call call(sxc.function f, params sxc.routine_argument[] args)
            => new scalar_function_call(f.Name, args);

        static sxc.scalar_function_call call(sxc.function f, IEnumerable<sxc.routine_argument> args, keyword_list options)
            => new scalar_function_call(f.Name, args, options);

        static sxc.function_call call(sxc.function f, routine_argument_list args, keyword_list options)
            => new scalar_function_call(f.Name, args, options);

        static sxc.scalar_function_call<v> call<v>(sxc.scalar_function f, routine_argument_list args, params IKeyword[] options)
            where v : sxc.scalar_type
                => new scalar_function_call<v>(f, args, options);

        static function_call<F> call_func<F>(F f, IEnumerable<sxc.routine_argument> args, keyword_list options)
            where F : sxc.function => new function_call<F>(f, args, options);

    }

}