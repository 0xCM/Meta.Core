//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;

    /// <summary>
    /// Describes a <see cref="IDataFrame"/> column
    /// </summary>
    public class DataFrameColumnInfo
    {
        public DataFrameColumnInfo(string ColumnName, int Position, Type DataType)
        {
            this.ColumnName = ColumnName;
            this.Position = Position;
            this.DataType = this.DataType;
        }

        /// <summary>
        /// The column name
        /// </summary>
        public string ColumnName { get; }

        /// <summary>
        /// The column position
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// The column's data type
        /// </summary>
        public Type DataType { get; }

        public override string ToString()
            => concat(Position.ToString().PadLeft(2, '0'), space(),
                    ColumnName, space(), DataType.Name);
    }
}