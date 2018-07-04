//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static SqlSyntax;

    partial class SqlSyntax
    {
        public abstract class alter_index_choice_item<m> : Model<m>, alter_index_choice_item
            where m : alter_index_choice_item<m>
        {
            protected alter_index_choice_item(IKeyword choice_type)
            {
                this.choice_type = choice_type;
            }

            public IKeyword choice_type { get; }

            public override string ToString()
                => choice_type.ToString();
        }

    }
}