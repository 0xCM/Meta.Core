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



    using sxc = SqlT.Syntax.contracts;


    [SqlElementType(SqlElementTypeNames.TableValuedFunction)]
    public sealed class SqlTableFunction : SqlFunction<SqlTableFunction>, sxc.table_function<ISqlDataTable>
    {

        public SqlTableFunction
            (
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlRoutineParameter> Parameters,
                IReadOnlyList<SqlColumnName> ResultColumnNames,
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

            this.ResultColumnNames = ResultColumnNames;

        }


        public IReadOnlyList<SqlColumnName> ResultColumnNames { get; }

    }


    public abstract class SqlTableFunction<T> : SqlFunction<T>
        where T : SqlTableFunction<T>
    {
        protected SqlTableFunction(SqlFunctionName FunctionName = null)
            : base(FunctionName ?? SqlFunctionName.Parse(typeof(T).Name))
        {
        }


    }

    public abstract class SqlTableFunction<T, R> : SqlTableFunction<T>, sxc.table_function<R>
        where T : SqlTableFunction<T, R>
        where R : ISqlDataTable
    {
        protected SqlTableFunction(SqlFunctionName FunctionName = null)
            : base(FunctionName)
        {
            
        }

        

    }


    public abstract class SqlTableFunction<T, A, R> : SqlTableFunction<T, R>, sxc.table_function<R>
        where T : SqlTableFunction<T, A, R>
        where R : ISqlDataTable
    {
        protected SqlTableFunction(SqlFunctionName FunctionName = null)
                : base(FunctionName)
        {

        }

    }


}