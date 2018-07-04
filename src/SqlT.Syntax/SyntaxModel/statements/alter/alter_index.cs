//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class alter_index : alter_statement<alter_index>
        {

            public alter_index(SqlIndexName index_name, table_or_view_name parent_object, alter_index_choice choice)
                : base(INDEX)
            {
                this.index_name = index_name;
                this.parent_object = parent_object;
                this.choice = choice;
            }


            public SqlIndexName index_name { get; }

            public table_or_view_name parent_object { get; }

            public alter_index_choice choice { get; }

            public override string ToString()
                => $"alter index {index_name} on {parent_object} {choice}";
        }

    }


}