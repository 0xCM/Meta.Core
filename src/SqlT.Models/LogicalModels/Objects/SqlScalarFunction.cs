//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;



    public abstract class SqlScalarFunction<F> : SqlFunction<F>, sxc.scalar_function
        where F : SqlScalarFunction<F>
    {


        protected SqlScalarFunction
            (
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlRoutineParameter> Parameters,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null
            )
            : base
                (
                  FunctionName: FunctionName,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation
                )
        {
        }

        protected SqlScalarFunction(SqlFunctionName FunctionName)
            : base(FunctionName)
        {

        }

        protected SqlScalarFunction(SqlFunctionName FunctionName, params SqlRoutineParameter[] Parameters)
            : this(FunctionName, Parameters.ToReadOnlyList())
        {

        }


    }


    public abstract class SqlScalarFunction<F, R> : SqlFunction<F, R>, sxc.scalar_function<R>
        where F : SqlScalarFunction<F, R>
        where R : sxc.scalar_type

    {
        protected SqlScalarFunction
            (
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlRoutineParameter> Parameters,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false
            )
            : base
                (
                  FunctionName: FunctionName,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation,
                  IsIntrinsic: IsIntrinsic
                )
        {
        }

        protected SqlScalarFunction(SqlFunctionName FunctionName, bool IsIntrinsic = false)
            : base(FunctionName, IsIntrinsic: IsIntrinsic)
        {

        }

        protected SqlScalarFunction(SqlFunctionName FunctionName, params SqlRoutineParameter[] Parameters)
            : this(FunctionName, Parameters.ToReadOnlyList())
        {

        }

    }


    [SqlElementType(SqlElementTypeNames.ScalarFunction)]
    public sealed class SqlScalarFunction : SqlScalarFunction<SqlScalarFunction> 
            
    {

        public SqlScalarFunction
            (
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlRoutineParameter> Parameters,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            )
            : base
                (
                  FunctionName: FunctionName,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation
                )
        {



        }

    }

    

}