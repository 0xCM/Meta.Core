//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;


    partial class SqlSyntax
    {
        public sealed class exists_expression : BooleanExpression<exists_expression>
        {
            public exists_expression(subquery subquery)
            {
                this.subquery = subquery;

            }

            public subquery subquery { get; }

            public override string ToString()
                => $"{EXISTS} ({subquery})";

        }



    }

}