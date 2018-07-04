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
    using System.Linq.Expressions;
    using SqlT.Core;
    using SqlT.Models;
    using static SqlSyntax;

    using static SqlT.Core.SqlProxyMetadataProvider;
    using sxc = contracts;

    partial class sql
    {

        public static column_alias column((string column, string alias) xy)
            => new column_alias(xy.column, xy.alias);

        public static column_list columns(params string[] cols)
           => cols;

        public static column_alias_list columns(params (string column, string alias)[] cols)
            => cols.ToArray(x => column(x));

        public static column_alias_list columns(params column_alias[] cols)
            => cols;
    }

}