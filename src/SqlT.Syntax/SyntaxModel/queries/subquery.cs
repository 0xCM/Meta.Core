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
    using sxc = contracts;

    using static metacore;

    partial class SqlSyntax
    {
        public class subquery : Model<subquery>
        {
            public subquery(ISyntaxExpression query_expression)
            {
                this.query_expression = query_expression;
            }

            public ISyntaxExpression query_expression { get; }

        }




    }

}