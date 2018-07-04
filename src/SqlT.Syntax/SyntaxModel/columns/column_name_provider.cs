//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Models;
    using SqlT.Core;

    using static metacore;
    using sxc = contracts;


    public class column_name_provider : Model<column_name_provider>, sxc.column_name_provider
    {
        public column_name_provider(IEnumerable<SqlColumnName> ColumnNames)
            => this.ColumnNames = ColumnNames.ToList();

        public IReadOnlyList<SqlColumnName> ColumnNames { get; }
    }


}