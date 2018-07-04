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
    using Meta.Models;

    using kwt = SqlKeywordTypes;
    
    using static metacore;

    partial class SqlSyntax
    {

        public class search_junction : BooleanExpression<search_junction>
        {
            public search_junction(kwt.AND AND, predicate predicate)
            {
                this.junction = AND;
                this.subject = predicate;
            }

            public search_junction(kwt.OR OR, predicate predicate)
            {
                this.junction = OR;
                this.subject = predicate;
            }

            public search_junction(kwt.AND AND, kwt.NOT NOT, predicate predicate)
            {
                this.junction = AND;
                this.subject = predicate;
                this.NOT = NOT;
            }

            public search_junction(kwt.OR OR, search_condition search_condition)
            {
                this.junction = OR;
                this.subject = subject;

            }

            public search_junction(kwt.OR OR, kwt.NOT NOT, search_condition search_condition)
            {
                this.junction = OR;
                this.subject = subject;
                this.NOT = NOT;
            }

            public du<kwt.AND, kwt.OR> junction { get; }

            public du<predicate, search_condition> subject { get; }

            public ModelOption<kwt.NOT> NOT { get; }

        }

    }

}