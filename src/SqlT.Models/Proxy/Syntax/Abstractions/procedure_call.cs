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
    using SqlT.Core;
    using SqlT.Models;

    using sxc = SqlT.Syntax.contracts;
    using static Syntax.SqlSyntax;
    using static SqlT.Syntax.SqlProxySyntax;

    using static metacore;

    partial class SqlProxySyntax
    {
        /// <summary>
        /// Represents a function call over a table or view represented by a proxy of type <typeparamref name="r"/>
        /// </summary>
        /// <typeparam name="p">The function type</typeparam>
        /// <typeparam name="r">The proxy representation of the rowset return result</typeparam>
        /// <typeparam name="M">The derived subtype</typeparam>
        public abstract class procedure_call<M, p, r> : proxy_expression<p, r>, ISqlProxyProcedureCall<p, r>
            where M : procedure_call<M, p, r>
            where p : sxc.procedure<r>, ISyntaxExpression
            where r : ISqlTabularProxy, new()
        {

            public static implicit operator p(procedure_call<M, p, r> x)
                => x.Operand;

            protected procedure_call(p p, routine_argument_list args)
                : base(p)
            {
                this.Arguments = args;
            }

            public p Procedure { get; }

            public routine_argument_list Arguments { get; }

            public SqlProcedureName procedure_name
                => Procedure.Name;

            sxc.routine_argument_list sxc.routine_call.args
                => Arguments;

            sxc.keyword_list sxc.routine_call.options
                => throw new NotImplementedException();

            public override string ToString()
                => $"{procedure_name}({Arguments})";

        }
    }



}