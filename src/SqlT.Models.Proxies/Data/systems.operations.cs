//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;

    [SqlProxyOperationProvider(typeof(IsystemsOperations))]
    class systemsOperations : SqlProxyOperationProvider<IsystemsOperations>, IsystemsOperations
    {
		public systemsOperations(ISqlProxyBroker broker)
			: base(broker)
        { }

        public SqlOutcome<int> p_databases_delete(string systems_server_name, string database_name)
            => Broker.Call(new p_databases_delete(systems_server_name, database_name));

        public SqlOutcome<int> p_databases_merge(IEnumerable<databases_record> Records)
            => Broker.Call(new p_databases_merge(Records));

        public SqlOutcome<int> p_host_servers_merge(IEnumerable<host_servers_record> Records)
            => Broker.Call(new p_host_servers_merge(Records));

        public SqlOutcome<int> p_host_server_delete(string systems_server_name)
            => Broker.Call(new p_host_server_delete(systems_server_name));

        public SqlOutcome<int> p_host_server_save(string systems_server_name)
            => Broker.Call(new p_host_server_save(systems_server_name));

        public SqlOutcome<int> p_servers_merge(IEnumerable<servers_record> Records)
            => Broker.Call(new p_servers_merge(Records));
    }
}
