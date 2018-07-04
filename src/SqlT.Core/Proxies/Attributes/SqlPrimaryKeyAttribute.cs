//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public class SqlPrimaryKeyAttribute : SqlObjectAttribute
    {
        public SqlPrimaryKeyAttribute()
        {
        }

        public SqlPrimaryKeyAttribute(string SchemaName, string PrimaryKeyName, string TableName)
            : base(SchemaName, PrimaryKeyName)
        {
            this.TableName = TableName;

        }
        public override SqlProxyKind ProxyKind
            => SqlProxyKind.PrimaryKey;

        public string TableName
        {
            get { return GetFacetValue<string>(nameof(TableName)); }
            set { SetFacetValue(nameof(TableName), value); }
        }

        public SqlTableName TableObjectName
            => new SqlTableName(SchemaName, TableName);
    }
}