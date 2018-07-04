//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    public class SqlTableProxyInfo : SqlTabularProxyInfo
    {

        public SqlTableProxyInfo
        (
            Type RuntimeType, 
            SqlTableName TableName,  
            IReadOnlyList<SqlColumnProxyInfo> Columns, 
            IReadOnlyList<SqlIndexProxyInfo> Indexes, 
            SqlPrimaryKeyProxyInfo PrimaryKey,
            SqlTableDocumentation Documentation = null
        ) : base(SqlProxyKind.Table, RuntimeType, TableName, Columns, Documentation ?? SqlTableDocumentation.Empty)
        {
            this.Indexes = Indexes;
            this.PrimaryKey = PrimaryKey;
            this.ObjectName = TableName;
        }

        public SqlPrimaryKeyProxyInfo PrimaryKey { get; }

        public IReadOnlyList<SqlIndexProxyInfo> Indexes { get; }

        public new SqlTableName ObjectName { get; }

        public new SqlTableDocumentation Documentation
            => base.Documentation as SqlTableDocumentation;
    }
}