//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    partial class SqlSyntax
    {



        public sealed class joined_table : Model<joined_table>
        {
            public joined_table(join_type join_type, table_source left, table_source right)
            {
                this.join_type = join_type;
                this.left = left;
                this.right = right;
            }

            public table_source left { get; }

            public table_source right { get; }

            public join_type join_type { get; }
        }


    }
}