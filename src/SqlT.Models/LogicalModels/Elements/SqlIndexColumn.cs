//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    /// <summary>
    /// Characterizes a SQL Index Column
    /// </summary>
    [SqlElementType(SqlElementTypeNames.IndexColumn)]
    public sealed class SqlIndexColumn : SqlElement<SqlIndexColumn>
    {


        public SqlIndexColumn
            (
                SqlColumnName ColumnName, 
                bool Ascending = true,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null
            ) : base(ColumnName, Documentation, Properties)
        {
            this.Ascending = Ascending;
        }


        public SqlColumnName ColumnName
            => (SqlColumnName)ElementName;

        public bool Ascending { get; }

        public override string ToString()
            => ColumnName.ToString();
    }

}
