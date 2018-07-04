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

    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    using SqlT.Models;
    using SqlT.Services;

    using SqlT.Core;
    using static metacore;

    static class SqlScalarFunctionTranslation
    {
        [SqlTBuilder]
        public static IEnumerable<SqlScalarFunction> ModelScalarFunctions(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {
            foreach (var source in dsql.GetDacObjects<DacX.TSqlScalarFunction>())
            {
                var documentation = xpidx.FindValue<string>(source.GetFullNameText(), SqlPropertyNames.Documentation);
                yield return new SqlScalarFunction
                    (
                        FunctionName: source.Name.SpecifyFunctionName(),
                        Parameters: source.Parameters.SpecifyParameters(),
                        Statements: source.ModelStatements().Require(),
                        Documentation: documentation.ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(source.Name)
                    );
            }

        }

    }
}