//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlRecordAttribute : SqlObjectAttribute
    {
        public SqlRecordAttribute()
        {

        }

        public SqlRecordAttribute(string SchemaName, string Name)
            : base(SchemaName, Name)
        {

        }

        public override SqlProxyKind ProxyKind                 
            => SqlProxyKind.TableType;

        public SqlTableTypeName TableTypeName
            => new SqlTableTypeName(SchemaName, base.ObjectName);

    }
}