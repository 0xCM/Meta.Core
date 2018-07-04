//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;
    using SqlT.Core;

    public sealed class SqlDatabaseServer : SqlServerNode<SqlDatabaseServer>
    {
        public SqlDatabaseServer(SystemNode Host,
            string InstanceName = null,
            int? Port = null,
            bool IsLocal = false,
            SqlUserCredentials DefaultCredentials = null,
            NodeUncShare FileStreamRoot = null,
            SystemNodeIdentifier SqlNodeId = null,
            SqlServerAlias Alias = null                        
            )
            : base(Host, InstanceName, Port, IsLocal, SqlNodeId)
        {
            this.DefaultCredentials = DefaultCredentials;
            this.SqlServerName = Host.NodeServer;
            this.FileStreamRoot = FileStreamRoot ??  new NodeUncShare(Host, new UncRoot(InstanceName ?? "MSSQLSERVER"));
            this.Alias = Alias;
        }

        public Option<SqlUserCredentials> DefaultCredentials { get; }

        public SqlServerName SqlServerName { get; }

        public NodeUncShare FileStreamRoot { get; }

        public Option<SqlServerAlias> Alias { get; }

        public override string ToString()
            => Alias.MapValueOrDefault(a => a.AliasName, 
                    SqlServerName.UnquotedLocalName.text);

        public Option<SystemNode> ToSystemNode()
            => Alias.Map(a => new SystemNode(a.AliasName, base.NodeIdentifier, a.AliasName, null, base.IsLocal));
        
    }


}