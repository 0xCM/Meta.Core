﻿//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;

    using Meta.Models;
    using Meta.Syntax;

    partial class SqlSyntax
    {
        public sealed class parameter_sniffing : cdu<IKeyword, kwt.ON, kwt.OFF>, sxc.dboption
        {
            public static implicit operator parameter_sniffing(kwt.ON ON)
                => new parameter_sniffing(ON);

            public static implicit operator parameter_sniffing(kwt.OFF OFF)
                => new parameter_sniffing(OFF);

         
            public parameter_sniffing(kwt.ON ON)
                : base(ON)
            { }

            public parameter_sniffing(kwt.OFF OFF)
                : base(OFF)
            { }

            public bool IsOn
                => v1.value == ON;
        }

        public sealed class parameter_sniffings : SyntaxList<parameter_sniffings, parameter_sniffing>
        {
            public static readonly parameter_sniffing ON = sx.ON;
            public static readonly parameter_sniffing OFF = sx.OFF;
        }
    }
}