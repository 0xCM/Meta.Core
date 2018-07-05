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

    static class SqlTableTypeTranslation
    {

        [SqlTBuilder]
        public static IEnumerable<SqlTableType> SpecifyTableTypes(this DacX.TSqlTypedModel dsql, SqlPropertyIndex xpidx)
        {
            var objects = dsql.GetDacObjects<DacX.TSqlTableType>();
            foreach (var o in objects)
            {
                yield return new SqlTableType
                    (
                        TypeName: o.SpecifyTableTypeName(),
                        Columns: o.SpecifyColumns(),
                        Properties: xpidx.ModelExtendedProperties(o)
                    );
            }

        }



    }

}