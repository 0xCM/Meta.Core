//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
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