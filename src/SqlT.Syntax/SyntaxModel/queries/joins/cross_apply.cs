//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    partial class SqlSyntax
    {


        public sealed class cross_apply : table_join<cross_apply>
        {

            public cross_apply(table_source left_table, table_source right_table)
                : base(left_table, right_table)
            {

            }

        }

    }
}