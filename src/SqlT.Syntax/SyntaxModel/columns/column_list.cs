//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;
    using SqlT.Core;


    partial class SqlSyntax
    {
        public sealed class column_list : SyntaxList<SqlColumnName>
        {            

            public static new readonly column_list 
                empty = new column_list(new string[] { });

            public static implicit operator column_list(string[] names)
                => new column_list(names);

            public static implicit operator column_list(SqlColumnName[] names)
                => new column_list(names);

            public column_list(params string[] names)
                : base(names.ToArray(src => new SqlColumnName(src)))
            { }

            public column_list(params SqlColumnName[] names)
                : base(names)
            { }

        }
    }
}