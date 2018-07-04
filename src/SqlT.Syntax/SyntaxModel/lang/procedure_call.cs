namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;
    using static SqlT.Syntax.SqlSyntax;

    partial class SqlSyntax
    {
        public sealed class procedure_call : SyntaxExpression<procedure_call>, sxc.procedure_call
        {

            public procedure_call(SqlProcedureName procedure_name, routine_argument_list args = null, keyword_list options = null)
            {
                this.procedure_name = procedure_name;
                this.args = args ?? routine_argument_list.empty;
                this.options = options ?? keyword_list.empty;
            }


            public SqlProcedureName procedure_name { get; }

            public routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;

            sxc.routine_argument_list sxc.routine_call.args
                => args;



            public override string ToString()
                => $"{procedure_name}({args}) as {procedure_name.UnqualifiedName}";

        }


        

        public class procedure_call<P> : SyntaxExpression<procedure_call<P>>, sxc.procedure_call<P>
            where P : sxc.procedure
        {
            static ReadOnlyList<ValueMember> parameters = typeof(P).GetValueMembers();

            public procedure_call(P procedure, params sxc.routine_argument[] Arguments)
            {
                this.procedure = procedure;
                this.args = Arguments.ToRoutineArgList();
                this.options = keyword_list.empty;

            }

            public procedure_call(P F, IEnumerable<sxc.routine_argument> args, keyword_list options)
            {
                this.procedure = F;
                this.args = args.ToRoutineArgList();
                this.options = options;
            }

            public P procedure { get; }

            public sxc.routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;

            public SqlProcedureName procedure_name
                => procedure.Name;


            public override string ToString()
            {
                var name = procedure.Name;
                var paramValues = string.Join(",", parameters.Map(p => p.GetValue(this)));
                var description = $"{name}({paramValues})"
                    + (name.IsEmpty()
                    ? string.Empty : $"as {name}");
                return description;
            }
        }

        public class procedure_call<P, R> : SyntaxExpression<procedure_call<P,R>>, 
            sxc.procedure_call<P, R>, ISyntaxExpression
                where P : sxc.procedure<R>
        {
            static ReadOnlyList<ValueMember> parameters = typeof(P).GetValueMembers();

            public procedure_call(P Procedure, routine_argument_list args, keyword_list options = null)
            {
                this.Procedure = Procedure;
                this.args = args;
                this.options = options ?? keyword_list.empty;

            }

            public P Procedure { get; }

            public sxc.routine_argument_list args { get; }

            public keyword_list options { get; }

            sxc.keyword_list sxc.routine_call.options
                => options;


            SqlProcedureName sxc.procedure_call.procedure_name
                => Procedure.Name;


            public override string ToString()
            {
                var name = Procedure.Name;
                var paramValues = string.Join(",", parameters.Map(p => p.GetValue(this)));
                var description = $"{name}({paramValues})"
                    + (name.IsEmpty()
                    ? string.Empty : $"as {name}");
                return description;
            }
        }

    }
}
