//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using SqlT.Core;

    public class SqlMergeColumn<TSrc, TDst> : SqlMergeColumn
        where TSrc : class, ISqlTabularProxy, new()
        where TDst : class, ISqlTableProxy, new()
    {

        static SqlTabularProxyInfo SrcTable
            = PXM.Tabular<TSrc>();

        static SqlTableProxyInfo DstTable
            = PXM.Table<TDst>();

        public SqlMergeColumn(Expression<Func<TSrc, object>> src, Expression<Func<TDst, object>> dst, bool match = false)
            : base
            (

                  SrcTable.Columns.Single(c => c.ColumnName == src.GetValueMember().Name).Selection(),
                  DstTable.Columns.Single(c => c.ColumnName == dst.GetValueMember().Name).Selection(),
                  match
            )
        {

        }
    }
}
