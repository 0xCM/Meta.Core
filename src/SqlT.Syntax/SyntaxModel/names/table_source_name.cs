//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class table_source_name : name<SqlTableName, SqlViewName>
        {
            public static implicit operator table_source_name(SqlTableName x)
                => new table_source_name(x);

            public static implicit operator table_source_name(SqlViewName x)
                => new table_source_name(x);

            public table_source_name(SqlTableName table)
                : base(table)
            {

            }

            public table_source_name(SqlViewName view)
                : base(view)
            {

            }
        }
    }
}