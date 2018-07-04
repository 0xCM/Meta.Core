//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class column_alias_list : SyntaxList<column_alias>
        {

            public static implicit operator column_alias_list(column_alias[] aliases)
                => new column_alias_list(aliases);

            public column_alias_list(params column_alias[] aliases)
                : base(aliases)
            { }
        }

    }
}