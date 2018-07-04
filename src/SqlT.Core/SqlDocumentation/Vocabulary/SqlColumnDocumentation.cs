//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Specifies documentation for a column
    /// </summary>
    public class SqlColumnDocumentation : SqlElementDocumetation<SqlColumnName>, ISqlColumnDocumentation
    {

        public static readonly new SqlColumnDocumentation Empty 
            = new SqlColumnDocumentation();

        public SqlColumnDocumentation()
        {
            this.DataTypeName = string.Empty;
            this.DescriptionProperty = string.Empty;
            this.RoleType = SqlColumnRoleTypes.UnclassifiedRole;
                    
        }

        public SqlColumnDocumentation(SqlColumnName Name, SqlColumnRoleType RoleType)
            : base(Name, String.Empty, String.Empty, String.Empty)
        {
            this.RoleType = RoleType ?? throw new ArgumentNullException();
        }


        public SqlColumnDocumentation(SqlColumnName ColumnName, string Label, string Description, string Identifier = null)
            : base(ColumnName, Label, Description, Identifier ?? ColumnName.UnqualifiedName)
        {
            this.RoleType = SqlColumnRoleTypes.UnclassifiedRole;

        }

        public bool ValueRequired { get; set; }

        public int Position { get; set; }

        public string DataTypeName { get; set; }

        public string DescriptionProperty { get; set; }

        public SqlColumnRoleType RoleType { get; }

    }
}