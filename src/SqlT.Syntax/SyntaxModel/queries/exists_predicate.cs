//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using SqlT.Core;
    using sxc = contracts;


    partial class SqlSyntax
    {


        public sealed class exists_predicate : predicate<exists_expression>
        {
            public static implicit operator exists_predicate(exists_expression e)
                => new exists_predicate(e);

            public exists_predicate(exists_expression e)
                : base(e)
            {


            }

        }

    }
}
