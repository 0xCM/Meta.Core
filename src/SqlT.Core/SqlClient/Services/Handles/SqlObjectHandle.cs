//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    /// <summary>
    /// Mediates access to a schema-scoped database object or representation thereof
    /// </summary>
    public abstract class SqlObjectHandle : SqlElementHandle, ISqlObjectHandle
    {

        protected SqlObjectHandle(ISqlClientBroker Broker, sxc.ISqlObjectName ElementName)
            : base(Broker, ElementName)
        {

        }

        public new sxc.ISqlObjectName ElementName
            => base.ElementName as sxc.ISqlObjectName;

    }

    public abstract class SqlObjectHandle<P> : SqlElementHandle<P>, ISqlObjectHandle<P>
        where P : ISqlObjectProxy
    {
        public SqlObjectHandle(ISqlProxyBroker Broker, sxc.ISqlObjectName ObjectName)
            : base(Broker, ObjectName)
        {

        }

        public new sxc.ISqlObjectName ElementName
            => base.ElementName as sxc.ISqlObjectName;
    }
}
