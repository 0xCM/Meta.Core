//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;
    using sxc = SqlT.Syntax.contracts;


    public class SqlProxySelectInfo : SqlModel<SqlProxySelectInfo>, IModel
    {
        public SqlProxySelectInfo
            (
                SqlTabularProxyInfo Proxy,
                IEnumerable<SqlColumnProxySelection> SelectedColumns,
                IEnumerable<SqlColumnSortOrder> SelectionOrders = null
            )
        {
            this.Source = Proxy;
            this.SelectedColumns = rolist(SelectedColumns);
            this.SelectionOrders = rovalues(SelectionOrders);
        }

        public SqlTabularProxyInfo Source { get; }

        public sxc.tabular_name SourceName
            => Source.ObjectName;

        public IReadOnlyList<SqlColumnProxySelection> SelectedColumns { get; }

        public IReadOnlyList<SqlColumnSortOrder> SelectionOrders { get; }

        public override string ToString()
            => SelectedColumns.Count != 0
            ? ("select " + String.Join(",", SelectedColumns.Select(c => c.ToString()).ToArray()))
            : String.Empty;
    }
}
