//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;


    public class PartitionRowsByCount : ScriptTemplate<PartitionRowsByCount>
    {
        public static SqlScript CreateScript(SqlTableName Table, SqlColumnName KeyColumn)
            => new PartitionRowsByCount(
                    Table.SchemaNamePart, 
                    Table.UnquotedLocalName, 
                    KeyColumn.UnquotedLocalName
                ).Expand();

        public PartitionRowsByCount(string TableSchema, string TableName, string KeyColumn)
        {
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.KeyColumn = KeyColumn;
        }

        public string TableSchema { get; }

        public string TableName { get; }

        public string KeyColumn { get; }
        

    }



}