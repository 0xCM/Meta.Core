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

    using static metacore;


    /// <summary>
    /// Identifies a column by name and/or position
    /// </summary>
    public struct SqlColumnIdentifier : IEquatable<SqlColumnIdentifier>
    {
        public static bool operator ==(SqlColumnIdentifier x, SqlColumnIdentifier y)
            => x.Equals(y);

        public static bool operator !=(SqlColumnIdentifier x, SqlColumnIdentifier y)
            => not(x.Equals(y));

        public static implicit operator SqlColumnIdentifier(int ColumnPosition)
            => new SqlColumnIdentifier(ColumnPosition);

        public static implicit operator SqlColumnIdentifier(SqlColumnName ColumnName)
            => new SqlColumnIdentifier(ColumnName);

        public static implicit operator int(SqlColumnIdentifier x)
            => x.ColumnPosition ?? -1;

        public static implicit operator string(SqlColumnIdentifier x)
            => x.ColumnName;

        public SqlColumnIdentifier(int ColumnPosition)
        {
            this.ColumnName = SqlColumnName.Empty;
            this.ColumnPosition = ColumnPosition;
        }

        public SqlColumnIdentifier(SqlColumnName ColumnName)
        {
            this.ColumnName = ColumnName;
            this.ColumnPosition = null;
        }

        public SqlColumnIdentifier(SqlColumnName ColumnName, int ColumnPosition)
        {
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
        }

        /// <summary>
        /// The column name
        /// </summary>
        public SqlColumnName ColumnName { get; }

        /// <summary>
        /// The column's relative position
        /// </summary>
        public int? ColumnPosition { get; }

        public SqlColumnIdentifierKind IdentifierKind
        {
            get
            {
                if (not(ColumnName.IsEmpty()) && isNotNull(ColumnPosition))
                    return SqlColumnIdentifierKind.NameAndPosition;
                else if (not(ColumnName.IsEmpty()))
                    return SqlColumnIdentifierKind.ColumnName;
                else if (ColumnPosition != null)
                    return SqlColumnIdentifierKind.ColumnPosition;
                else
                    return SqlColumnIdentifierKind.None;
            }
        }

        public override string ToString()
        {
            return
              ((ColumnPosition != null ? ColumnPosition.Value.ToString().PadLeft(3, '0') + " " : string.Empty)
                +
              (ColumnName.IsEmpty() ? string.Empty : ColumnName.UnqualifiedName)).Trim();
        }

        public bool Equals(SqlColumnIdentifier other)
            => other.ColumnName == this.ColumnName
            && other.ColumnPosition == this.ColumnPosition;

        public override bool Equals(object other)
            => (other is SqlColumnIdentifier) 
            ? Equals(cast<SqlColumnIdentifier>(other)) 
            : false;

        public override int GetHashCode()
            => ToString().GetHashCode();
    }
}
