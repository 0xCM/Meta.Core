//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using SqlT.Core;
    using SqlT.Models;

    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class create_index : create_statement<create_index, SqlIndexName>
        {

            public create_index(SqlIndexName element_name, table_or_view_name parent_object, 
                column_list columns, column_list include = null)
                : base(INDEX, element_name)
            {
                this.parent_object = parent_object;
                this.columns = columns;
                this.include = include ?? column_list.empty;
            }


            public table_or_view_name parent_object { get; }

            public column_list columns { get; }

            public column_list include { get; }

            public override string ToString()
                => $"{CREATE} {INDEX} {element_name} on {parent_object}({columns})";
        }

    }



}