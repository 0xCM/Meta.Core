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
    using SqlT.SqlDocs.Proxies;

    using static metacore;

    public class DocumentRowset
    {
        

        public DocumentRowset(MarkdownTableInfo Table, IEnumerable<MarkdownTableRow> Rows)
        {
            this.Table = Table;
            this.Rows = Rows.ToReadOnlyList();
        }

        public MarkdownTableInfo Table { get; }  

        public IReadOnlyList<MarkdownTableRow> Rows { get; }


        public override string ToString()
            => $"{Table.DocumentTitle} Table({Table.TablePosition},{Table.RowCount},{Table.ColumnCount})";
    }



}