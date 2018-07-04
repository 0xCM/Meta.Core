//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using SqlT.Core;

    using static metacore;

    public class SystemViewsSettings
    {


        public SystemViewsSettings(SqlConnectionString Connector, SystemViewFilter Filter = null, SqlDatabaseName Source = null)
        {
            this.Connector = Connector;
            this.Filter = Filter ?? new SystemViewFilter();
            this.Source = isNull(Source) 
                ? new SqlDatabaseName(Connector.ServerName, Connector.DatabaseName)
                : Source;
        }

        public SqlConnectionString Connector { get; }

        public SqlDatabaseName Source { get; }

        public SystemViewFilter Filter { get;  }


    }
}
