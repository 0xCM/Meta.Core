//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Represents a linked server
    /// </summary>
    public sealed class SqlLinkedServerHandle : SqlElementHandle, ISqlServerHandle
    {
        public SqlLinkedServerHandle(ISqlClientBroker Broker, SqlServerName LinkedServerName)
            : base(Broker, LinkedServerName)
        { }

        public SqlServerName ServerName
            => (SqlServerName)base.ElementName;

        public bool IsLinkedServer
            => true;
    }
}
