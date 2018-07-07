//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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