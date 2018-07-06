//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;

    using static metacore;

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    /// <summary>
    /// Defines operations that convert dac-modeled routines into sqlt-modled routines
    /// </summary>
    public static class SqlRoutineTranslation
    {
        public static IEnumerable<SqlProjector> ModelProjectors(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {
            var functions = dsql.FindMarkedElements<DacX.TSqlTableValuedFunction>(SqlPropertyNames.QueryType);
            foreach (var function in functions)
            {
                var queryType = second(function);
                if (
                        queryType == SqlQueryTypes.SequentialProjector ||
                        queryType == SqlQueryTypes.ChangeProjector
                    )
                {
                    var functionName = function.Item1.Name.FormatName();
                    var documentation = xpidx.FindValue<string>(functionName, SqlPropertyNames.Documentation);
                    var peer = xpidx.FindValue<string>(functionName, SqlPropertyNames.QueryPeer);
                    var properties = xpidx.GetProperties(functionName);
                    yield return SqlScript.FromText(first(function).GetScript()).ParseSimpleProjector
                        (
                            queryType,
                            documentation.ValueOrDefault(),
                            peer.ValueOrDefault(),
                            properties
                        );
                }
            }
        }

        [SqlTBuilder]
        public static IEnumerable<SqlProcedure> ModelProcedures(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {
            foreach (var source in dsql.GetDacObjects<DacX.TSqlProcedure>())
            {
                var documentation = xpidx.FindValue<string>(source.Name.FormatName(), SqlPropertyNames.Documentation);
                var statements = source.ModelStatements().Require();

                yield return new SqlProcedure
                    (
                        Name: source.SpecifyProcedureName(),
                        Parameters: source.Parameters.SpecifyParameters(),
                        Statements: source.ModelStatements().Require(),
                        Documentation: documentation.ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(source)
                    );
            }
        }

        [SqlTBuilder]
        public static IEnumerable<SqlScalarFunction> ModelScalarFunctions(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
            => dsql.GetDacObjects<DacX.TSqlScalarFunction>().Select(source =>
                new SqlScalarFunction
                    (
                        FunctionName: source.Name.SpecifyFunctionName(),
                        Parameters: source.Parameters.SpecifyParameters(),
                        Statements: source.ModelStatements().Require(),
                        Documentation: xpidx.FindValue<string>(source.GetFullNameText(),
                            SqlPropertyNames.Documentation).ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(source.Name)
                    ));

        public static IEnumerable<SqlTableFunction> ModelTableFunctions(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {

            foreach (var source in dsql.GetDacObjects<DacX.TSqlTableValuedFunction>())
            {
                var queryType = xpidx.FindValue<string>(source.Name.FormatName(), SqlPropertyNames.QueryType)
                                     .Map(x => x, () => String.Empty);

                if (queryType == SqlQueryTypes.SequentialProjector ||
                    queryType == SqlQueryTypes.ChangeProjector)
                    continue;

                var documentation = xpidx.FindValue<string>(source.GetFullNameText(), SqlPropertyNames.Documentation);
                var statememnts = source.ModelStatements().Require();
                yield return new SqlTableFunction
                    (
                        FunctionName: source.SpecifyFunctionName(),
                        Parameters: source.Parameters.SpecifyParameters(),
                        ResultColumnNames: map(source.FormatNames(), n => new SqlColumnName(n)),
                        Statements: statememnts,
                        Documentation: documentation.ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(source.Name)
                    );
            }
        }

    }
}
