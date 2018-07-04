//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = Syntax.contracts;

    partial class SqlSyntax
    {

        public sealed class left_join : table_join<left_join>
        {
            public left_join(table_source left_table, table_source right_table, search_condition join_criteria)
                : base(left_table, right_table, join_criteria)
            {

            }
        }

        public sealed class left_join<l, r> : table_join<l, r>
            where l : sxc.table_source
            where r : sxc.table_source
        {

            public left_join(l left, r right, search_condition join_criteria)
                : base(left, right, join_criteria)
            {


            }

        }


    }
}