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

    partial class SqlSyntax
    {

        [url("https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql")]
        public class from_clause : Clause<from_clause>, sxc.from_clause
        {
            public static new readonly from_clause empty = new from_clause();


            public static implicit operator from_clause(table_source[] sources)
                => new from_clause(sources);


            public static implicit operator from_clause(table_source source)                
                => new from_clause(source);

            public from_clause(params table_source[] sources)
                : base(FROM)
            {
                this.sources = new table_source_list(sources);
            }

            public table_source_list sources { get; }

            public override string ToString()
                => string.Join(" ", sources);
        }
    }
}
