//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;

    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public class table_compression_type : du<kwt.NONE, kwt.ROW, kwt.PAGE>
        {
            public static implicit operator table_compression_type(kwt.NONE NONE)
                => new table_compression_type(NONE);

            public static implicit operator table_compression_type(kwt.ROW ROW)
                => new table_compression_type(ROW);

            public static implicit operator table_compression_type(kwt.PAGE PAGE)
                => new table_compression_type(PAGE);

            public table_compression_type(kwt.NONE NONE)
                : base(NONE)
            { }

            public table_compression_type(kwt.ROW ROW)
                : base(ROW)
            { }

            public table_compression_type(kwt.PAGE PAGE)
                : base(PAGE)
            { }

        }
    }

}