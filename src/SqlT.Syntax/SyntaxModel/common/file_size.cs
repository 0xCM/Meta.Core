//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;
    using System;

    using static metacore;    

    partial class SqlSyntax
    {
        public class file_size : Model<file_size>
        {
            public file_size(integer_literal value, file_size_unit? unit = null)
            {
                this.value = value;
                this.unit = unit;
            }

            public integer_literal value { get; }

            public file_size_unit? unit { get; }

            public override string ToString()
                => concat($"{value}", unit != null ? $"{unit}" : string.Empty);
        }
    }
}