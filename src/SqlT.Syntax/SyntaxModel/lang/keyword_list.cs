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


        public sealed class keyword_list : SyntaxList<IKeyword>, sxc.keyword_list
        {
            public static new readonly keyword_list empty 
                = new keyword_list(new IKeyword[] { });

            public static implicit operator keyword_list(IKeyword[] keywords)
                => new keyword_list(keywords);

            public keyword_list(IEnumerable<IKeyword> items)
                : base(items)
            {

            }

            

        }

    }




}