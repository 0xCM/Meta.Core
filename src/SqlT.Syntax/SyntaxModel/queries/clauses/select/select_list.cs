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
    using Meta.Models;

    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        static string toString(IEnumerable<IModel> items, char separator = ',')
            => string.Join(separator.ToString(), items);

        public class select_list : SyntaxList<selected_item>
        {
            public static implicit operator select_list(kwt.STAR x)
                => new select_list(x);

            public static implicit operator select_list(selected_item[] items)
                => new select_list(items);

            public static implicit operator select_list(column_list columns)
                => new select_list(columns.Select(c => new selected_item(c)));

            public static implicit operator select_clause(select_list l)
                => new select_clause(l);

            public select_list(params selected_item[] items)
                : base(items) {}

            public select_list(IEnumerable<selected_item> items)
                : base(items){ }

            public override string ToString()
                => toString(items);
        }
    }
}
