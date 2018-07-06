//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;
    using static metacore;

    using sxc = contracts;

    partial class SqlSyntax
    {
        public class file_growth : Model<file_size>
        {
            public file_growth(integer_literal value, file_growth_unit? unit = null)
            {
                this.value = value;
                this.unit = unit;
            }

            public integer_literal value { get; }

            public file_growth_unit? unit { get; }

            public override string ToString()
                => concat($"{value}", unit != null ? $"{unit}" : string.Empty);


        }

    }
}