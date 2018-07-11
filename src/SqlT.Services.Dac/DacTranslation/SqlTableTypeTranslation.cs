//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    public static class SqlTableTypeTranslation
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
                        Properties: xpidx.ModelExtendedProperties(o).Stream()
                    );
            }
        }
    }

}