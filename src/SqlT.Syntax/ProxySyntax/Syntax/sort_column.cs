//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using SqlT.Core;
    using SqlT.Models;
    using System.Linq.Expressions;

    using Meta.Core;

    using static metacore;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    partial class SqlProxySyntax
    {
        public sealed class sort_column<p> : proxy_expression<sx.sort_column, p>
            where p : ISqlTabularProxy, new()
        {
            public sort_column(Expression<Func<p, object>> selection, sx.sort_direction direction)
                : base(new sx.sort_column(tabular.FindColumnByRuntimeName(selection.GetValueMember().Name).ColumnName, direction))
            {

            }
        }
    }
}