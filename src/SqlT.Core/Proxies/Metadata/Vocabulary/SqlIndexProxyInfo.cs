//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlIndexProxyInfo : SqlProxyInfo
    {

        public SqlIndexProxyInfo
            (Type ClrElement, 
            SqlTableName TableName,  
            SqlIndexName IndexName, 
            IEnumerable<SqlIndexColumnProxyInfo> IndexColumns,
            SqlIndexDocumentation Documentation = null
            ) : base(SqlProxyKind.Index, ClrElement, Documentation)
        {
            this.IndexName = IndexName;
            this.IndexColumns = IndexColumns.ToList();
            this.IncludeColumns = new List<SqlIndexIncludeColumnProxyInfo>();
            this.TableName = TableName;          
        }

        public SqlIndexName IndexName { get; }

        public SqlTableName TableName { get; }

        public IReadOnlyList<SqlIndexColumnProxyInfo> IndexColumns { get; }
        public IReadOnlyList<SqlIndexIncludeColumnProxyInfo> IncludeColumns { get; }
        

        public override Type RuntimeType
            => ClrElement as Type;

        public override string ToString()
            => $"{IndexName} on {TableName}(" + string.Join(",", IndexColumns);
    }



}
