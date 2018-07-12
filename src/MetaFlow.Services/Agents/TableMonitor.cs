//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    using MetaFlow.Core;
    using MetaFlow.Core.Storage;

    using static metacore;

    [ServiceAgent(nameof(TableMonitor)), ApplicationService(nameof(TableMonitor))]
    class TableMonitor : SystemAgent<TableMonitor, TableMonitorSettings>, IServiceAgent
    {

        public TableMonitor(INodeContext C)
            : base(C)
        {

        }


        IEnumerable<(SqlTableName, TableMonitorLogEntry)> LogEntries
            => PlatformBroker.Get(new TableMonitorLogEntries())
                    .OnNone(Notify)
                    .Items()
                    .Select(x => (new SqlTableName(x.HostId, x.DatabaseName, x.SchemaName, x.TableName), x));

        IEnumerable<(SqlTableName, MonitoredTable)> Tables
            => PlatformBroker.Get(new MonitoredTables())
                    .OnNone(Notify)
                    .Items()
                    .Select(x => (new SqlTableName(x.HostId, x.DatabaseName, x.SchemaName, x.TableName),x));
        

        Option<int> CheckTable(MonitoredTable Table, Option<TableMonitorLogEntry> LastObservation)
        {


            return 0;
        }


        protected override Option<int> DoWork()
        {
            var entries = dict(LogEntries);
            var tables = dict(Tables);
            map(tables, t => CheckTable(t.Value, entries.TryFind(t.Key)));

            return 0;
        }
    }

}