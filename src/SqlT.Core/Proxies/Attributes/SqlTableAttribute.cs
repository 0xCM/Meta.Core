//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlTableAttribute : SqlObjectAttribute
    {


        public SqlTableAttribute()
        {

        }

        public SqlTableAttribute(string TableName)
            : base(string.Empty, TableName)
        { }

        public SqlTableAttribute(string SchemaName, string Name)
            : base(SchemaName, Name)
        {
        }

        public override SqlProxyKind ProxyKind 
            => SqlProxyKind.Table;


        public SqlTableName GetTableName()
            => new SqlTableName(SchemaName, ObjectName);

        public override string ToString()
            => GetTableName();
    }
}