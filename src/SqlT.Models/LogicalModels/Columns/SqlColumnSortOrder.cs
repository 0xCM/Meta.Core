//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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