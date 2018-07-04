//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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


        public IReadOnlyList<SqlPackageReference> GetReferences()
        => (from cd in this
            where cd.Category == "Reference" && cd.Type == "SqlSchema"
            select new SqlPackageReference(cd.Properties)).ToList();


        public IReadOnlyList<sql_cmd_variable> GetSqlCmdVariables()
        => (from cd in this
            where cd.Category == "SqlCmdVariables" && cd.Type == "SqlCmdVariable"
            from p in cd.Properties
            select new sql_cmd_variable(p.Name, (string)p.Value)).ToList();

    }
}