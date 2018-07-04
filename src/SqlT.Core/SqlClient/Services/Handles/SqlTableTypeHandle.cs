//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    public class SqlTableTypeHandle : SqlObjectHandle, ISqlTableTypeHandle
    {
        public SqlTableTypeHandle(ISqlClientBroker Broker, SqlTableTypeName TypeName)
            : base(Broker, TypeName)
        {
            ElementName = TypeName;
        }

        public new SqlTableTypeName ElementName { get; }

        sxc.tabular_name ISqlTabularHandle.ElementName
            => ElementName;
    }

    public class SqlTableTypeHandle<P> : SqlObjectHandle<P>, ISqlTableTypeHandle<P>
        where P : class, ISqlTableTypeProxy, new()
    {
        public SqlTableTypeHandle(ISqlProxyBroker Broker)
            : base(Broker, PXM.TableTypeName<P>())
        {
            ElementName = Broker.Metadata.TableType<P>().ObjectName;

        }

        public new SqlTableTypeName ElementName { get; }

        sxc.tabular_name ISqlTabularHandle.ElementName
            => ElementName;
    }
}
