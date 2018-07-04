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
        public sealed class order_by_clause : Clause<order_by_clause>
        {
            public order_by_clause(params sxc.order_by_expression[] expressions)
                : base(new KeyPhrase(rolist<IKeyword>(ORDER, BY)))
                    => this.expressions = new SyntaxList<sxc.order_by_expression>(expressions);

            public order_by_clause(column_list columns)
                : base(new KeyPhrase(rolist<IKeyword>(ORDER, BY)))
                    => this.expressions = SyntaxList.create(columns, column => column.OrderBy());

            public order_by_clause(column_list columns, kwt.ASC asc)
                : base(new KeyPhrase(rolist<IKeyword>(ORDER, BY)))
                    => this.expressions = SyntaxList.create(columns, column => column.OrderBy(asc));

            public order_by_clause(column_list columns, kwt.DESC desc)
                : base(new KeyPhrase(rolist<IKeyword>(ORDER, BY)))
                    => this.expressions = SyntaxList.create(columns, column => column.OrderBy(desc));

            public SyntaxList<sxc.order_by_expression> expressions { get; }
        }
    }
}