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
    using System.Text;

    using SqlT.SqlDocs.Proxies;


    using static metacore;



    public class DocumentTable : SqlDocPartContent<DocumentTable, TablePart>
    {
        Dictionary<int, TableRow> RowIndex { get; }

        public DocumentTable()
            : base(string.Empty)
        {
            RowIndex = new Dictionary<int, TableRow>();
        }

        public int TablePosition { get; set; }

        public IEnumerable<TableRow> Rows
            => RowIndex.Values.OrderBy(x => x.RowPosition);


        public int ColCount
            => RowIndex.Values.Select(x => x.ColumnCount).Max();


        public string this[int rowPos, int colIdx]
        {
            get
            {

                if (RowIndex.TryGetValue(rowPos, out TableRow rowData))
                {
                    if (rowData.ColumnValues.Count > rowPos)
                        return rowData.ColumnValues[rowPos];
                }
                return string.Empty;
            }
            set
            {

                if (RowIndex.TryGetValue(rowPos, out TableRow rowData))
                {
                    rowData.AddValue(value);
                }
                else
                {
                    RowIndex[rowPos] = new TableRow(value, rowPos);
                    RowIndex[rowPos].AddValue(value);

                }

            }
        }

        public string ToCsv()
        {
            var sb = new StringBuilder();
            foreach (var row in Rows)
            {
                sb.AppendLine(row.ToString());
            }
            return sb.ToString();
        }

        string CellValue(TableRow row, int idx)
            => left(row[idx], 250);

        static string nullify(string input)
            => ifBlank(trim(input), null);

        MarkdownTableRow ToDataRow(TableRow row, string SegmentName, string DocumentTitle)
        {
            int colidx = 0;
            return new MarkdownTableRow
                (
                    SegmentName: SegmentName,
                    DocumentTitle: DocumentTitle,
                    TablePosition: TablePosition,
                    TableNumber: null,
                    RowNumber: row.RowPosition,
                    CellValue01: nullify(CellValue(row, colidx++)),
                    CellValue02: nullify(CellValue(row, colidx++)),
                    CellValue03: nullify(CellValue(row, colidx++)),
                    CellValue04: nullify(CellValue(row, colidx++)),
                    CellValue05: nullify(CellValue(row, colidx++)),
                    CellValue06: nullify(CellValue(row, colidx++)),
                    CellValue07: nullify(CellValue(row, colidx++)),
                    CellValue08: nullify(CellValue(row, colidx++)),
                    CellValue09: nullify(CellValue(row, colidx++))

                 );
        }

        public DocumentRowset ToRowset(string SegmentName, string DocumentTitle)
            => new DocumentRowset
                (
                    Table: new MarkdownTableInfo
                    (
                        SegmentName: SegmentName,
                        DocumentTitle: DocumentTitle,
                        TablePosition: TablePosition,
                        ColumnCount: ColCount,
                        RowCount: RowIndex.Keys.Count
                    ),
                    Rows: map(Rows, row =>  ToDataRow(row, SegmentName, DocumentTitle))
                );

        public override string ToString()
            => ToCsv();


    }




}
