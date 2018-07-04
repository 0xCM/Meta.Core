//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Templates
{
    using SqlT.Syntax;
    using SqlT.Models;
    using System.Collections.Generic;
    using SqlT.Core;
   
    using static metacore;

    public class SqlColumnProxyList : SqlQueryAction<SqlColumnProxyList>
    {

        public SqlColumnProxyList(IEnumerable<SqlColumnProxySelection> Columns)
            : base(new SqlParameterName(nameof(SqlColumnProxyList)))
        {
            this.Columns = Columns.ToReadOnlyList();
        }

        [SqlTemplateParameter]
        public IReadOnlyList<SqlColumnProxySelection> Columns { get; }

    }
}
