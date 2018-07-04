//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;
    using Meta.Syntax;

    using sxc = contracts;
    partial class SqlSyntax
    {

        public sealed class parameter_declaration_list : SyntaxList<sxc.parameter_declaration>
        {           
            public parameter_declaration_list(IEnumerable<sxc.parameter_declaration> items)
                : base(items)
            {
                
            }

        }

    }




}