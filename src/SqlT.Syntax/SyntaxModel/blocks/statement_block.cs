//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class statement_block : statement_block<statement_block>
        {
            public static implicit operator statement_block(sxc.statement[] x)
                => define(x);

            public statement_block(){}

            public statement_block(Seq<sxc.statement> Statements)
                : base(Statements){}            
        }
    }
}
