//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using SqlT.SqlSystem;

    using systems = SqlT.SqlSystem.systems;

    using static metacore;

    /// <summary>
    /// Encapsulates the metadata for a single SQL Server
    /// </summary>
    public class SqlServerMetadataSet 
    {        
        static TDst project<TSrc, TDst>(TSrc src, TDst dst)
        {
            var srcProps = props(src).ToDictionary(x => x.Name);
            var dstProps = props(dst).ToDictionary(x => x.Name);
            foreach (var srcPropName in srcProps.Keys)
            {
                dstProps.TryFind(srcPropName).OnSome(dstProp =>
                    dstProp.SetValue(dst, srcProps[srcPropName].GetValue(src)));
            }
            return dst;
        }

        IDictionary<string, SqlDatabaseMetadataSet> databases;

        IDictionary<SqlName, systems.v_host_servers> host_servers;

        IDictionary<SqlName, systems.v_servers> servers;

        string host_server_name { get; set; }

        public SqlServerMetadataSet(string host_server_name)
        {
            this.databases = new Dictionary<string, SqlDatabaseMetadataSet>();

            this.host_server_name = host_server_name;
            this.host_servers =
                array(new systems.v_host_servers
                {
                    systems_server_name = host_server_name
                }).ToDictionary(x => new SqlName(x.systems_server_name));
            this.servers = new Dictionary<SqlName, systems.v_servers>();
        }

        public void Absorb(SqlDatabaseMetadataSet dbMetadata)
        {
            this.databases.Add(dbMetadata.DatabaseName, dbMetadata);
        }

        public void Absorb(IEnumerable<IServer> src) =>
            servers.AddRange(map(src, x => project(x, new systems.v_servers()
            {
                systems_server_name = host_server_name
            })).ToDictionary(x => new SqlName(x.name)));

        public IEnumerable<systems.v_host_servers> HostServers
            => host_servers.Values;

        public IEnumerable<systems.v_servers> Servers
            => servers.Values;

        public IEnumerable<systems.v_databases> Databases
            => databases.Select(x => x.Value.Database);

        public IEnumerable<systems.v_schemas> Schemas
            => databases.SelectMany(x => x.Value.Schemas);

        public IEnumerable<systems.v_tables> Tables
            => databases.SelectMany(x => x.Value.Tables);

        public IEnumerable<systems.v_types> Types
            => databases.SelectMany(x => x.Value.Types);

        public IEnumerable<systems.v_views> Views
            => databases.SelectMany(x => x.Value.Views);

        public IEnumerable<systems.v_extended_properties> ExtendedProperties
            => databases.SelectMany(x => x.Value.ExtendedProperties);

    }
}
