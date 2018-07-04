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

    using sxc = SqlT.Syntax.contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public class index_compression_type : 
            du
            <
                kwt.NONE, 
                kwt.ROW, 
                kwt.PAGE, 
                kwt.COLUMNSTORE, 
                kwt.COLUMNSTORE_ARCHIVE
            >
        {
            public static implicit operator index_compression_type(kwt.NONE NONE)
                => new index_compression_type(NONE);

            public static implicit operator index_compression_type(kwt.ROW ROW)
                => new index_compression_type(ROW);

            public static implicit operator index_compression_type(kwt.PAGE PAGE)
                => new index_compression_type(PAGE);

            public static implicit operator index_compression_type(kwt.COLUMNSTORE COLUMNSTORE)
                => new index_compression_type(COLUMNSTORE);

            public static implicit operator index_compression_type(kwt.COLUMNSTORE_ARCHIVE COLUMNSTORE_ARCHIVE)
                => new index_compression_type(COLUMNSTORE_ARCHIVE);

            public index_compression_type(kwt.NONE NONE)
                : base(NONE)
            { }

            public index_compression_type(kwt.ROW ROW)
                : base(ROW)
            { }

            public index_compression_type(kwt.PAGE PAGE)
                : base(PAGE)
            { }

            public index_compression_type(kwt.COLUMNSTORE COLUMNSTORE)
                : base(COLUMNSTORE)
            { }

            public index_compression_type(kwt.COLUMNSTORE_ARCHIVE COLUMNSTORE_ARCHIVE)
                : base(COLUMNSTORE_ARCHIVE)
            { }

        }
    }

}