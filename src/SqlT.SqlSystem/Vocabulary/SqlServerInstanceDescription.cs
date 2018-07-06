//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.SqlSystem;

    using systems = SqlT.SqlSystem.systems;

    public class SqlServerInstanceDescription
    {
        readonly systems.v_host_servers host;
        readonly IReadOnlyList<systems.v_servers> servers;
        readonly IReadOnlyList<systems.v_databases> databases;

        public SqlServerInstanceDescription(
            string hostname,
            IEnumerable<systems.v_servers> servers,
            IEnumerable<systems.v_databases> databases
            )
        {
            this.host = new systems.v_host_servers(hostname);
            this.databases = databases.ToList();
            this.servers = servers.ToList();
        }

        public systems.v_host_servers Host 
            => host;

        public IReadOnlyList<systems.v_servers> Servers 
            => servers;
        public IReadOnlyList<systems.v_databases> Databases 
            => databases;
    }

}
