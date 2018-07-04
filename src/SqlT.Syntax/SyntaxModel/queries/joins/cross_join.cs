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

        public sealed class cross_join : table_join<cross_join>
        {
            public cross_join(table_source left_table, table_source right_table)
                : base(left_table, right_table)
            { }

        }


        public sealed class cross_join<l, r> : table_join<l, r>
            where l : sxc.table_source
            where r : sxc.table_source
        {

            public cross_join(l Left, r Right)
                : base(Left, Right)
            {


            }

        }


    }
}