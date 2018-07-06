//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
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
