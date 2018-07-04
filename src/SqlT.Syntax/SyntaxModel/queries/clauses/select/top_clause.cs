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
    using SqlT.Core;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class top_clause : Clause<top_clause>
        {
            public top_clause(sxc.scalar_expression expression, bool percent = false, bool with_ties = false)
                : base(TOP)
            {
                this.expression = expression;
                this.percent = percent;
                this.with_ties = with_ties;
            }

            public sxc.scalar_expression expression { get; }

            public bool percent { get; }

            public bool with_ties { get; }

            public override string ToString()
                => $"{designator}({expression})";
        }
    }
}