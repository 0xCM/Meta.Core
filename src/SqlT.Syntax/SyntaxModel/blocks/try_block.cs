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

        public sealed class try_block : statement_block<try_block>
        {
            public static implicit operator try_block(sxc.statement[] x)
                => define(x);

            public try_block()
            {

            }

            public try_block(Seq<sxc.statement> Statements)
                : base(Statements)
            {
                
            }
        }
    }
}
