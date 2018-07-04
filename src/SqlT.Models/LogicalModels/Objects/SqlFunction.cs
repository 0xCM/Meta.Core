//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    using static metacore;


    public abstract class SqlFunction<F> : SqlObject<F>, sxc.function
        where F : SqlFunction<F>
    {
        protected static readonly SqlFunctionName DefaultName
            = SqlFunctionName.Parse(typeof(F).Name.ToLower());


        protected SqlFunction
            (
                SqlFunctionName FunctionName = null,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            ) : base
            (
                ObjectName: FunctionName,
                Documentation: Documentation,
                Properties: Properties,
                IsIntrinsic: IsIntrinsic
            )
        {
            this.Parameters =  Parameters?.ToReadOnlyList() ?? rolist<SqlRoutineParameter>();
            this.Statements = Statements?.ToReadOnlyList() ?? rolist<sxc.statement>();
        }

        public SqlFunctionName Name
            => (SqlFunctionName)ObjectName;

        public IReadOnlyList<SqlRoutineParameter> Parameters { get; }

        public readonly IReadOnlyList<sxc.statement> Statements;


    }


    public abstract class SqlFunction<F, R> : SqlFunction<F>, sxc.function<R>
        where F : SqlFunction<F, R>
    {

        protected SqlFunction
            (
                SqlFunctionName FunctionName = null,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            ) : base
            (
                FunctionName: FunctionName ?? typeof(F).Name.ToLower(),
                Parameters: Parameters,
                Statements: Statements,
                Documentation: Documentation,
                Properties: Properties,
                IsIntrinsic: IsIntrinsic
            )
        {

        }


    }

    public sealed class SqlFunction : SqlFunction<SqlFunction>
    {


        public SqlFunction
            (
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            ) : base
            (
                FunctionName: FunctionName,
                Parameters: Parameters,
                Statements: Statements,
                Documentation: Documentation,
                Properties: Properties,
                IsIntrinsic: IsIntrinsic
            )
        {

        }

    }

}


