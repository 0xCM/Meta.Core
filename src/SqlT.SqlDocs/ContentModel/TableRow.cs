//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TableRow : SqlDocPartContent<TableRow, TableRowPart>
    {
        List<string> _ColumnValues { get; } 
            = new List<string>();

        public int RowPosition { get; }

        public IReadOnlyList<string> ColumnValues
            => _ColumnValues;

        public int ColumnCount
            => _ColumnValues.Count;

        public TableRow()
            : this(string.Empty, 0)
        {

        }

        public TableRow(string Text, int RowPostion)
            : base(Text)
        {
            this.RowPosition = RowPostion;
        }

        public void AddValue(string value)
            => _ColumnValues.Add(value);

        public string this[int colidx]
            => ColumnValues.Count > colidx 
            ? ColumnValues[colidx] 
            : null;

        public override string ToString()
            => string.Join(", ", ColumnValues.Select(v => $"\"{v}\""));
    }

}
