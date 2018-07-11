//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Models;
    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    using sxc = contracts;

    using static metacore;

    public class SqlProxySelectInfo : SqlModel<SqlProxySelectInfo>, IModel
    {
        public SqlProxySelectInfo(SqlTabularProxyInfo Proxy,
                Seq<SqlColumnProxySelection> SelectedColumns,
                Seq<SqlColumnSortOrder>? SelectionOrders = null)
        {
            this.Source = Proxy;
            this.SelectedColumns = SelectedColumns;
            this.SelectionOrders = SelectionOrders ?? seq<SqlColumnSortOrder>();
        }

        public SqlTabularProxyInfo Source { get; }

        public sxc.tabular_name SourceName
            => Source.ObjectName;

        public Lst<SqlColumnProxySelection> SelectedColumns { get; }

        public Lst<SqlColumnSortOrder> SelectionOrders { get; }

        public override string ToString()
            => SelectedColumns.Count != 0
            ? ("select " + String.Join(",", SelectedColumns.Select(c => c.ToString())))
            : String.Empty;
    }
}
