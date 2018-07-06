//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;

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