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

    using static SqlSyntax;
    using sxc = contracts;


    partial class sql
    {

        public static sxc.column_ref colref(SqlColumnName column, SqlAliasName alias)
            => new column_ref(column, alias);
    }
}