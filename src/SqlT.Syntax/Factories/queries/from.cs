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

    using SqlT.Core;

    using static metacore;

    using sx = SqlSyntax;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class sql
    {

        public static sx.from_clause from(sx.from_table_or_view source)
            => new sx.from_clause(source);


        public static sx.from_clause from(params sx.table_source[] sources)
            => new sx.from_clause(sources);


    }

}