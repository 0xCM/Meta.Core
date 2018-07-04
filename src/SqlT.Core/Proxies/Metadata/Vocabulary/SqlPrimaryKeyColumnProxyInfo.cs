//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{


    public class SqlPrimaryKeyColumnProxyInfo : SqlColumnProxyInfo
    {
        public SqlPrimaryKeyColumnProxyInfo(object ClrElement, SqlColumnName ColumnName, int ColumnPosition, int KeyColumnPosition, SqlTypeInfo SqlType)
            : base(SqlProxyKind.IndexColumn, ClrElement, ColumnName, ColumnPosition, SqlType)
        {
            this.KeyColumnPosition = KeyColumnPosition;
        }

        /// <summary>
        /// The position of the column relative to other columns in the key
        /// </summary>
        public int KeyColumnPosition { get; }
    }



}