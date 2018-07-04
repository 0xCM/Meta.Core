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
    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    static class SqlTableFunctionTranslation
    {
     
        public static IEnumerable<SqlTableFunction> ModelTableFunctions(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {

            foreach (var source in dsql.GetDacObjects<DacX.TSqlTableValuedFunction>())
            {
                var queryType = xpidx.FindValue<string>(source.Name.FormatName(), SqlPropertyNames.QueryType)
                                     .Map(x => x, () => String.Empty);

                if( queryType == SqlQueryTypes.SequentialProjector ||
                    queryType == SqlQueryTypes.ChangeProjector)                                                                       
                    continue;

                var documentation = xpidx.FindValue<string>(source.GetFullNameText(), SqlPropertyNames.Documentation);
                var statememnts = source.ModelStatements().Require();
                yield return new SqlTableFunction
                    (
                        FunctionName: source.SpecifyFunctionName(),
                        Parameters: source.Parameters.SpecifyParameters(),
                        ResultColumnNames: map(source.FormatNames(), n => new SqlColumnName(n)),
                        Statements:   statememnts, 
                        Documentation: documentation.ValueOrDefault(),
                        Properties: xpidx.ModelExtendedProperties(source.Name)
                    );
            }
        }

    }
}
