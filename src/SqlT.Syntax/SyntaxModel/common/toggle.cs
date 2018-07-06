//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class toggle : du<kwt.ON,kwt.OFF>
        {

            public static implicit operator toggle(kwt.ON ON)
                => new toggle(ON);

            public static implicit operator toggle(kwt.OFF OFF)
                => new toggle(OFF);

            public toggle(kwt.ON ON)
                : base(ON)
            { }

            public toggle(kwt.OFF OFF)
                : base(OFF)
            { }

        }
    }
}