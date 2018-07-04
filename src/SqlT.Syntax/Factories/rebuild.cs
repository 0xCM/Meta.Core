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

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;
    using static SqlSyntax;

    public static partial class sql
    {
        public static alter_index rebuild(kwt.INDEX INDEX, SqlIndexName index_name, table_or_view_name parent_object)
           => new alter_index(index_name, parent_object,
                  new alter_index_choice(new alter_index_rebuild()));

    }

}