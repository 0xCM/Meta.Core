//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using SqlT.Core;

    public static partial class SqlHandleX3
    {
        public static Option<SqlElementExists> Exists(this SqlLinkedServerHandle h)
            => h.Broker.ExecuteScalarScript<int>($"select count(*) from sys.servers where name = '{h.ServerName.UnqualifiedName}'")
                       .TryMapValue(x => x == 1 ? SqlElementExists.Yes : SqlElementExists.No);                        

        public static (string, object) sqlparam(string name, object value)
            => (name.StartsWith("@") ? name : "@" + name, value);

        public static Option<int> Drop(this SqlLinkedServerHandle h)
        => h.Broker.ExecuteProcedure(new SqlProcedureName("dbo", "sp_dropserver"),
            sqlparam("server", h.ServerName.UnqualifiedName),
            sqlparam("droplogins", "droplogins"));

        public static SqlDatabaseHandle Database(this SqlLinkedServerHandle h, SqlDatabaseName DatabaseName)
            => new SqlDatabaseHandle(h.Broker, DatabaseName.HostedBy(h.ServerName));        
    }
}
