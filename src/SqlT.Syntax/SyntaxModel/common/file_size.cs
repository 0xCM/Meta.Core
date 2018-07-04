//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    using Meta.Models;
    using SqlT.Core;
    using System;
    using static metacore;

    using kwt = SqlKeywordTypes;

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