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
    using Meta.Core;

    using static metacore;

    using sxc = contracts;    

    partial class SqlSyntax
    {

        public static statement_list to_statement_list(this IEnumerable<sxc.statement> statements)
            => new statement_list(statements);

        public static statement_list to_statement_list(this Seq<sxc.statement> statements)
            => new statement_list(statements.Stream());


        public sealed class statement_list : SyntaxList<statement_list, sxc.statement>, sxc.statement_list
        {
            public static implicit operator statement_list(sxc.statement[] x)
                => define(x);


            public statement_list()
            {

            }

            public statement_list(IEnumerable<sxc.statement> items)
                : base(items)
            {
                
            }
        }
    }
}