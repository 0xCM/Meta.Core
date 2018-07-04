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

        public sealed class index_or_statistics_name : name<SqlIndexName, SqlStatisticsName>
        {
            public static implicit operator index_or_statistics_name(SqlIndexName x)
                => new index_or_statistics_name(x);

            public static implicit operator index_or_statistics_name(SqlStatisticsName x)
                => new index_or_statistics_name(x);

            public index_or_statistics_name(SqlIndexName table)
                : base(table)
            {

            }

            public index_or_statistics_name(SqlStatisticsName view)
                : base(view)
            {

            }

        }
    }


}