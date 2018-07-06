//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;    
    using System.Linq;

    using Meta.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {

        public sealed class catch_block : statement_block<catch_block>
        {
            public static implicit operator catch_block(sxc.statement[] x)
                => define(x);


            public catch_block()
            {

            }

            public catch_block(Seq<sxc.statement> statements)
                : base(statements)
            {
                

            }            
        }
    }
}
