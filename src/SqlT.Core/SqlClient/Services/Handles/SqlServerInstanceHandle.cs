//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Linq;

    /// <summary>
    /// Mediates access to a physical SQL Server instance or representation thereof
    /// </summary>
    public sealed class SqlServerInstanceHandle : SqlElementHandle, ISqlServerHandle
    {
        public SqlServerInstanceHandle(ISqlClientBroker Broker, SqlServerName Server)
            : base(Broker, Server)

        {

        }

        public SqlServerName ServerName
            => (SqlServerName)base.ElementName;

        public bool IsLinkedServer
            => false;

    }
}
