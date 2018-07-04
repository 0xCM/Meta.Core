//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public abstract class SqlServerNode<N> : SystemNode<N>, ISqlServerNode
        where N : SqlServerNode<N>
    {

        public SqlServerNode(SystemNode Host, string InstanceName = null, int? Port = null,  bool IsLocal = false, SystemNodeIdentifier NodeIdentifier = null)
            : base
            (
                  NodeName: Host.NodeName, 
                  NodeIdentifier: NodeIdentifier ?? Host.NodeIdentifier, 
                  NodeServer : Host.NodeServer,
                  ExternalIP: Host.ExternalIP,
                  Port: Port,
                  IsLocal : IsLocal,
                  NetworkName:Host.NetworkName
            )
        {
            this.Host = Host;
            this.InstanceName = InstanceName ?? Host.NodeName;
            
        }


        /// <summary>
        /// The computational device that provides execution context for SQL Server
        /// </summary>
        public SystemNode Host { get; }

        public string InstanceName { get; }

        public override string ToString()
            => NodeName;

    }



}
