//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    public static partial class contracts
    {
        public interface function_call : routine_call
        {
            SqlFunctionName function_name { get; }
        }

        public interface function_call<v> : function_call { }

        public interface function_call<f, v> : function_call<v>
            where f : function { }

        public interface procedure_call : routine_call
        {
            SqlProcedureName procedure_name { get; }
        }

        public interface procedure_call<p> : procedure_call
            where p : procedure { }

        public interface procedure_call<p, v> : procedure_call<p>
            where p : procedure { }

        public interface scalar_function_call : function_call, scalar_expression { }

        public interface scalar_function_call<v> : scalar_function_call { }

        public interface scalar_function_call<f, v> : scalar_function_call<v>
            where f : scalar_function { }

        public interface routine_argument_value : ISyntaxExpression { }

        public interface routine_argument : ISyntaxExpression
        {
            ModelOption<routine_arg_name> arg_name { get; }

            routine_argument_value argument_value { get; }
        }


        public interface routine_call : ISyntaxExpression
        {
            routine_argument_list args { get; }

            keyword_list options { get; }

        }
    }
}

