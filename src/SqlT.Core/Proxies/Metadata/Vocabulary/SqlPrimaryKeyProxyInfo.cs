//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    public class SqlPrimaryKeyProxyInfo : SqlObjectProxyInfo
    {
        private readonly IReadOnlyList<SqlColumnProxyInfo> _KeyColumns;

        public SqlPrimaryKeyProxyInfo
            (
                Type RuntimeType,
                SqlTableName TableName,
                SqlPrimaryKeyName PrimaryKeyName,
                IReadOnlyList<SqlColumnProxyInfo> KeyColumns
            )
            : base(SqlProxyKind.PrimaryKey, RuntimeType, PrimaryKeyName)
        {
            this._KeyColumns = KeyColumns;
            this.TableName = TableName;
        }

        public override Type RuntimeType
            => ClrElement as Type;

        public SqlTableName TableName { get; }

        public IReadOnlyList<SqlColumnProxyInfo> KeyColumns
            => _KeyColumns;

    }
}