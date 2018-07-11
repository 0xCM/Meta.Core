//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;

    using Meta.Core;

    /// <summary>
    /// Codifies a relationship between two columns
    /// </summary>
    public class SqlColumnAssociation
    {
        public static Seq<SqlColumnAssociation> Symmetric(Seq<SqlColumnIdentifier> ColumnIdentifiers)
            => ColumnIdentifiers.Select(n => new SqlColumnAssociation(n, n));

        public static Seq<SqlColumnAssociation> Symmetric(Seq<SqlColumnName> ColumnNames)
            => ColumnNames.Select(n => new SqlColumnAssociation(n, n));

        public static Seq<SqlColumnAssociation> Symmetric(Seq<int> ColumnPositions)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n, n));

        public static Seq<SqlColumnAssociation> TargetOffset(Seq<int> ColumnPositions, int Offset)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n, n + Offset));

        public static Seq<SqlColumnAssociation> TargetOffset(Seq<SqlColumnIdentifier> columns, int offset)
            => from source in columns
               let target = new SqlColumnIdentifier(source.ColumnName, (source.ColumnPosition ?? 0) + offset)
               select new SqlColumnAssociation(source, target);

        public static Seq<SqlColumnAssociation> SourceOffset(Seq<int> ColumnPositions, int Offset)
            => ColumnPositions.Select(n => new SqlColumnAssociation(n + Offset, n));

        public static Seq<SqlColumnAssociation> SourceOffset(Seq<SqlColumnIdentifier> columns, int offset)
            => from target in columns
               let source = new SqlColumnIdentifier(target.ColumnName, (target.ColumnPosition ?? 0) + offset)
               select new SqlColumnAssociation(source, target);

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
    }
}
