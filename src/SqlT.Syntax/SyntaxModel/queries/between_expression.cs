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

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public sealed class between_expression : Model<between_expression>, IBooleanExpression
        {

            public static implicit operator between_predicate(between_expression x)
                => new between_predicate(x);

            public between_expression(ISyntaxExpression test_expression, ISyntaxExpression begin_expression, ISyntaxExpression end_expression)
            {
                this.test_expression = test_expression;
                this.begin_expression = begin_expression;
                this.end_expression = end_expression;
            }

            public between_expression(ISyntaxExpression test_expression, kwt.NOT NOT, ISyntaxExpression begin_expression, ISyntaxExpression end_expression)
            {
                this.test_expression = test_expression;
                this.begin_expression = begin_expression;
                this.end_expression = end_expression;
                this.NOT = NOT;
            }

            public ModelOption<kwt.NOT> NOT { get; }

            public ISyntaxExpression test_expression { get; }

            public ISyntaxExpression begin_expression { get; }

            public ISyntaxExpression end_expression { get; }

        }


    }

}