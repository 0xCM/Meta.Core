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

    using Meta.Models;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        /// <summary>
        /// Optional component of FROM
        /// </summary>
        /// <remarks>
        /// table_or_view_name [ [ AS ] table_alias ] [ <tablesample_clause> ] [ WITH ( < table_hint > [ [ , ]...n ] ) ]   
        /// </remarks>
        public class from_table_or_view : Model<from_table_or_view> 
        {

            public static implicit operator from_table_or_view(SqlTableName table)
                => new from_table_or_view(table);

            public static implicit operator from_table_or_view(SqlViewName view)
                => new from_table_or_view(view);

            public static implicit operator from_table_or_view(table_alias table_alias)
                => new from_table_or_view(table_alias.table, table_alias);

            public from_table_or_view(table_source_name source_name, table_alias table_alias = null)
            {
                this.source_name = source_name;
                this.table_alias = table_alias;
            }

            public table_source_name source_name { get; }

            public ModelOption<table_alias> table_alias { get; }

            public override string ToString()
                => table_alias.map(alias => $"{source_name} as {alias}", () => $"{source_name}");
        }

    }
}