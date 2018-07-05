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

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;

    /// <summary>
    /// Defines operations that manipulate and project parameter specification information between alternate representations
    /// </summary>
    static class SqlParameterTranslation
    {
        [SqlTBuilder]
        public static IReadOnlyList<SqlRoutineParameter> SpecifyParameters(this IEnumerable<DacX.TSqlParameter> parameters) 
            => parameters.Map(p =>
                new SqlRoutineParameter
                (
                    ParameterName: p.GetLocalName(),
                    TypeReference: new typeref(SqlDataTypes.Find(p.DataType.Single().Name.SpecifyDataTypeName()), false)
                ));
    }
}
