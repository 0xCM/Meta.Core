//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using Meta.Syntax;
    using System.Collections.Generic;

    partial class SqlSyntax
    {


        public sealed class argument_list : SyntaxList<sxc.routine_argument>, sxc.routine_argument_list
        {
            public argument_list(IEnumerable<sxc.routine_argument> items)
                : base(items)
            {
                
            }

        }

    }




}