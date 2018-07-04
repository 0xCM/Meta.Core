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

    using static SqlSyntax;

    partial class SqlSyntax
    {


        public sealed class alter_index_reorganize : alter_index_choice_item<alter_index_reorganize>
        {
            public alter_index_reorganize()
                : base(REORGANIZE)
            {

            }
        }


    }

}