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

        public sealed class try_block : statement_block<try_block>
        {
            public static implicit operator try_block(sxc.statement[] x)
                => define(x);

            public try_block()
            {

            }

            public try_block(IEnumerable<sxc.statement> Statements)
                : base(Statements)
            {
                

            }


        }
    }
}
