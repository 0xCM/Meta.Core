//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Models;
    using Meta.Syntax;

    using static metacore;
    using kwt = SqlKeywordTypes;
    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class sort_direction : cdu<IKeyword, kwt.ASC, kwt.DESC>, sxc.literal_value<IKeyword>
        {

            public static implicit operator sort_direction(kwt.ASC asc)
                => new sort_direction(asc);

            public static implicit operator sort_direction(kwt.DESC desc)
                => new sort_direction(desc);

            public sort_direction(kwt.ASC asc)
                : base(asc){}

            public sort_direction(kwt.DESC desc)
                : base(desc){}

            IKeyword sxc.literal_value<IKeyword>.value
                => selected_value;

            object sxc.literal_value.value
                => selected_value;
        }
    }
}