//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;
    using SqlT.Models;
    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;

    using static metacore;

    partial class SqlProxySyntax
    {
        public abstract class proxy_function_call<M, f, p> : proxy_expression<f, p>, sxc.proxy_function_call<f, p>
            where M : proxy_function_call<M, f, p>
            where f : sxc.function<p>, ISyntaxExpression
            where p : ISqlTabularProxy, new()
        {

            public static implicit operator f(proxy_function_call<M, f, p> x)
                => x.Operand;

            protected proxy_function_call(f f, params ValueMember[] args)
                : base(f)
            {

                this.Arguments = map(args, a => tabular.FindColumnByRuntimeName(a.Name));
            }

            public f Function { get; }

            public ReadOnlyList<SqlColumnProxyInfo> Arguments { get; }

            public SqlFunctionName function_name
                => Function.Name;

            sxc.routine_argument_list sxc.routine_call.args
                => throw new NotImplementedException();

            sxc.keyword_list sxc.routine_call.options
                => throw new NotImplementedException();

            public override string ToString()
            {
                var paramValues = string.Join(",", Arguments.Map(p => p.ColumnName));
                var description = $"{function_name}({paramValues})";
                return description;

            }
        }

    }
}