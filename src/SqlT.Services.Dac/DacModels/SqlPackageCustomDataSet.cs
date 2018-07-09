//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    using static SqlT.Syntax.SqlSyntax;

    public class SqlPackageCustomDataSet : IEnumerable<SqlPackageCustomData>
    {
        IEnumerator<SqlPackageCustomData> IEnumerable<SqlPackageCustomData>.GetEnumerator()
           => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Items.GetEnumerator();

        public SqlPackageCustomDataSet(SqlPackageName SourcePackageName, IEnumerable<SqlPackageCustomData> Items)
        {
            this.SourcePackageName = SourcePackageName;
            this.Items = Items.ToList();
        }

        public SqlPackageName SourcePackageName { get; }

        IReadOnlyList<SqlPackageCustomData> Items { get; }

        public IReadOnlyList<SqlPackageReference> References
        => (from cd in this
            where cd.Category == "Reference" && cd.Type == "SqlSchema"
            select new SqlPackageReference(cd.Properties)).ToList();

        public IReadOnlyList<sql_cmd_variable> SqlCmdVariables
            => (from cd in this
                where cd.Category == "SqlCmdVariables" && cd.Type == "SqlCmdVariable"
                from p in cd.Properties
                select new sql_cmd_variable(p.Name, (string)p.Value)).ToList();
    }
}