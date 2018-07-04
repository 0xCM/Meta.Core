//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;

    using static contracts;

    partial class SqlSyntax
    {

        public sealed class predicate_list : SyntaxList<predicate>
        {
            public predicate_list(params predicate[] predicates)
                : base(predicates)
            { }
        }



    }

}