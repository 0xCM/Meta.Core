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
    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {

        public class statement_or_block : du<sxc.statement, sxc.statement_block>
        {
            public static statement_or_block define(sxc.statement x)
                => new statement_or_block(x);

            public static statement_or_block define(sxc.statement_block x)
                => new statement_or_block(x);


            public statement_or_block(sxc.statement statement)
                : base(statement)
            { }

            public statement_or_block(sxc.statement_block block)
                : base(block)
            { }

        }
    }

}