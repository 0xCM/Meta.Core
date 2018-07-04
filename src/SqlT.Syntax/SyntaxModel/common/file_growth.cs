//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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