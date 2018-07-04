//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using static metacore;
    using static SqlSyntax;
    using sx = SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class select_statement : statement<select_statement>
        {

            public select_statement(select_clause selection, from_clause source = null, where_clause criteria = null)
                : base(SELECT)
            {
                this.selection = selection;
                this.source = source;
                this.criteria = criteria;
            }


            public select_clause selection { get; }

            public ModelOption<from_clause> source { get; }

            public ModelOption<where_clause> criteria { get; }


            public override string ToString()
                => $"{SELECT} {selection} {FROM} {source} {WHERE} {criteria}";

        }
    }

}