//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    /// <summary>
    /// Represents a FileTable object
    /// </summary>
    public sealed class SqlFileTable : SqlTable<SqlTable>
    {
        public static SqlFileTable Specify(SqlTableName table_name, string directory)
            => new SqlFileTable(table_name, directory);


        public SqlFileTable(SqlTableName TableName,string Directory) 
            : base(TableName)
        {
            this.Directory = Directory;
        }

        /// <summary>
        /// Specifies the file system directory associated with the filetable
        /// </summary>
        public string Directory { get; }

        public override bool IsFileTable
            => true;
    }


}