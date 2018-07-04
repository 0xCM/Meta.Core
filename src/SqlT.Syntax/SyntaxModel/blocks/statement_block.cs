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
        public sealed class statement_block : statement_block<statement_block>
        {
            public static implicit operator statement_block(sxc.statement[] x)
                => define(x);

            public statement_block(){}

            public statement_block(IEnumerable<sxc.statement> Statements)
                : base(Statements){}            
        }
    }
}
