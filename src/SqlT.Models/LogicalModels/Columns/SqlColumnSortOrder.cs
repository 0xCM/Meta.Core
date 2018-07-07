//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;
    using sxc = Syntax.contracts;

    using SqlT.Core;
    using SqlT.Syntax;
    
    public class SqlColumnSortOrder : ValueObject<SqlColumnSortOrder>
    {

        public SqlColumnSortOrder(SqlColumnName ColumnName, int SortPosition, sort_direction_kind SortDirection)
        {
            this.ColumnName = ColumnName;
            this.SortPosition = SortPosition;
            this.SortDirection = SortDirection;
        }


        public SqlColumnName ColumnName { get; }

        public sort_direction_kind SortDirection { get; }

        public int SortPosition { get; }

        public override string ToString()
            => $"{SortPosition} {ColumnName}({SortDirection})";
    }


}