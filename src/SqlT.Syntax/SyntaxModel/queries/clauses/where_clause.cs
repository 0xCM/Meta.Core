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
    

    partial class SqlSyntax
    {
        public sealed class where_clause : Clause<where_clause>
        {

            public where_clause(search_condition search_condition)
                : base(WHERE)
            {
                this.search_condition = search_condition;
            }

            public search_condition search_condition { get; }
        }
    }

}
