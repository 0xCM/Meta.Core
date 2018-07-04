//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Specifies documentation for a table
    /// </summary>
    public class SqlTableDocumentation : SqlTabularDocumentation<SqlTableName>, ISqlTableDocumentation
    {

        public static new readonly SqlTableDocumentation Empty = new SqlTableDocumentation();

        public SqlTableDocumentation()
        {
            this.Label = string.Empty;
            this.Description = string.Empty;
            this.Identifier = Name.UnqualifiedName;
        }

        internal SqlTableDocumentation(SqlTableName Name, string Label, string Description, string Identifier)
            : base(Name, Label, Description, 
                  string.IsNullOrEmpty(Identifier)
                ? Name.UnqualifiedName
                : Identifier)
        {
        }

        public SqlTableDocumentation DocumentColumn(SqlColumnDocumentation column)
        {
            DocumentedColumns[column.Name] = column;
            return this;
        }

        public SqlTableDocumentation DocumentColumns(params SqlColumnDocumentation[] columns)
        {
            foreach(var column in columns)
                DocumentedColumns[column.Name] = column;
            return this;
        }


        public bool IsReferenceTable { get; set; }

        public bool ReferenceDataInModel { get; set; }


        public SqlTableName IdentifiedTableName
            => Name.Rename(Identifier);



    }

    


}