//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Templates
{
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;
    using System.Reflection;

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