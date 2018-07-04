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
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public sealed class catch_block : statement_block<catch_block>
        {
            public static implicit operator catch_block(sxc.statement[] x)
                => define(x);


            public catch_block()
            {

            }

            public catch_block(IEnumerable<sxc.statement> statements)
                : base(statements)
            {
                

            }            
        }
    }
}
