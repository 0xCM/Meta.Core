//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Codifies a relationship between two columns
    /// </summary>
    public class SqlColumnAssociation
    {
        public static IEnumerable<SqlColumnAssociation> Symmetric(IEnumerable<SqlColumnIdentifier> ColumnIdentifiers)
            => ColumnIdentifiers.Select(n => new SqlColumnAssociation(n, n));

        public static IEnumerable<SqlColumnAssociation> Symmetric(IEnumerable<SqlColumnName> ColumnNames)
            => ColumnNames.Select(n => new SqlColumnAssociation(n, n));

        public static IEnumerable<SqlColumnAssociation> Symmetric(IEnumerable<int> ColumnPositions)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n, n));

        public static IEnumerable<SqlColumnAssociation> TargetOffset(IEnumerable<int> ColumnPositions, int Offset)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n, n + Offset));

        public static IEnumerable<SqlColumnAssociation> TargetOffset(IEnumerable<SqlColumnIdentifier> ColumnIdentifiers, int Offset)
        {
            foreach(var sourceCol in ColumnIdentifiers)
            {
                var targetCol = new SqlColumnIdentifier(sourceCol.ColumnName, (sourceCol.ColumnPosition ?? 0) + Offset);
                yield return new SqlColumnAssociation(sourceCol, targetCol);
            }
        }

        public static IEnumerable<SqlColumnAssociation> SourceOffset(IEnumerable<int> ColumnPositions, int Offset)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n + Offset, n));

        public static IEnumerable<SqlColumnAssociation> SourceOffset(IEnumerable<SqlColumnIdentifier> ColumnIdentifiers, int Offset)
        {
            foreach (var targetCol in ColumnIdentifiers)
            {
                var sourceCol = new SqlColumnIdentifier(targetCol.ColumnName, (targetCol.ColumnPosition ?? 0) + Offset);
                yield return new SqlColumnAssociation(sourceCol, targetCol);
            }
        }

        public SqlColumnAssociation(SqlColumnIdentifier SourceColumn, SqlColumnIdentifier TargetColumn)
        {
            this.SourceColumn = SourceColumn;
            this.TargetColumn = TargetColumn;
        }

        /// <summary>
        /// The client column in the assoication
        /// </summary>
        public SqlColumnIdentifier SourceColumn { get; }

        /// <summary>
        /// The target column in the assoication
        /// </summary>
        public SqlColumnIdentifier TargetColumn { get; }

        public override string ToString()
           => $"{SourceColumn} --> {TargetColumn}";

        internal SqlBulkCopyColumnMapping ToBcpMapping()
        {
            var association = this;
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
