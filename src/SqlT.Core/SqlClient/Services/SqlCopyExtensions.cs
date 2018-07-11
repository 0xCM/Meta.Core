//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Data;
    using System.Data.SqlClient;

    public static class SqlCopyExtensions
    {

        static FieldInfo _rowsCopied
            = typeof(SqlBulkCopy).GetField("_rowsCopied", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);

        /// <summary>
        /// Hack that inspects the private state of <see cref="SqlBulkCopy"/> to determine how many
        /// rows of data were migrated to the server
        /// </summary>
        /// <param name="bcp"></param>
        /// <returns></returns>
        public static int RowsCopied(this SqlBulkCopy bcp)
            => (int)_rowsCopied.GetValue(bcp);

        public static SqlBulkCopyColumnMapping ToBcpMapping(this SqlColumnAssociation association)
        {
            var src = association.SourceColumn;
            var dst = association.TargetColumn;
            switch (src.IdentifierKind)
            {
                case SqlColumnIdentifierKind.ColumnName:
                case SqlColumnIdentifierKind.NameAndPosition:
                    switch (dst.IdentifierKind)
                    {
                        case SqlColumnIdentifierKind.ColumnName:
                        case SqlColumnIdentifierKind.NameAndPosition:
                            return new SqlBulkCopyColumnMapping(src.ColumnName, dst.ColumnName);
                        case SqlColumnIdentifierKind.ColumnPosition:
                            return new SqlBulkCopyColumnMapping(src.ColumnName, dst.ColumnPosition.Value);
                        default:
                            throw new NotSupportedException();
                    }
                case SqlColumnIdentifierKind.ColumnPosition:
                    switch (dst.IdentifierKind)
                    {
                        case SqlColumnIdentifierKind.ColumnName:
                        case SqlColumnIdentifierKind.NameAndPosition:
                            return new SqlBulkCopyColumnMapping(src.ColumnPosition.Value, dst.ColumnName);
                        case SqlColumnIdentifierKind.ColumnPosition:
                            return new SqlBulkCopyColumnMapping(src.ColumnPosition.Value, dst.ColumnPosition.Value);
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }


    }



}
 