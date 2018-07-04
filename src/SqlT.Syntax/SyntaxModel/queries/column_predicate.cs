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
    using SqlT.Models;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlT.Syntax.SqlSyntax;

    partial class SqlSyntax
    {
        public class column_predicate : SyntaxExpression<column_predicate>, sxc.column_predicate
        {

            public column_predicate(SqlColumnName Column, IBooleanExpression Condition)
            {
                this.column = Column;
                this.condition = Condition;
            }

            public IBooleanExpression condition { get; }

            public SqlColumnName column { get; }

            public override string ToString()
                => $"{column} {condition}";


        }

        public class column_predicate<t> : column_predicate, sxc.column_predicate<t>
        {
            public column_predicate(SqlColumnName Column, IBooleanExpression Condition)
                : base(Column, Condition){}
        }
    }


}
