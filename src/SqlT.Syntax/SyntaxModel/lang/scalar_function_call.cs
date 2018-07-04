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

    using static metacore;
    using sxc = contracts;

    partial class SqlSyntax
    {
        public class scalar_function_call : function_call, sxc.scalar_function_call
        {
            public scalar_function_call(SqlFunctionName function_name, params sxc.routine_argument[] args)
                : base(function_name, args)
            {
            }

            public scalar_function_call(SqlFunctionName function, IEnumerable<sxc.routine_argument> args, keyword_list options)
                : base(function,args,options)
            {
            }

            public scalar_function_call(SqlFunctionName function, IEnumerable<sxc.routine_argument> args, params IKeyword[] options)
                : base(function,args,options)
            {
            }

            public scalar_function_call(SqlFunctionName function, sxc.routine_argument arg, params sxc.routine_argument[] args)
                : base(function,arg,args)
            {

            }

        }

        public class scalar_function_call<v> : function_call<sxc.scalar_function,v>, sxc.scalar_function_call<v>
            where v : sxc.scalar_type
        {
            public scalar_function_call(sxc.scalar_function function, params sxc.routine_argument[] args)
                : base(function, args)
            { }

            public scalar_function_call(sxc.scalar_function function, routine_argument_list args, params IKeyword[] options)
                : base(function, args,options)
            { }

            public scalar_function_call(sxc.scalar_function function, IEnumerable<sxc.routine_argument> args, params IKeyword[] options)
                : base(function, args, options)
            { }
        }

        public class scalar_function_call<f,v> : function_call<f,v>, sxc.scalar_function_call<f,v>
            where f : sxc.scalar_function

        {
            public scalar_function_call(f function, params sxc.routine_argument[] args)
                : base(function,args)
            { }

            public scalar_function_call(f function, routine_argument_list args)
                : base(function, args)
            { }

            public scalar_function_call(f function, IEnumerable<sxc.routine_argument> args, keyword_list options)
                : base(function,args,options)
            { }


        }
        

    }

}