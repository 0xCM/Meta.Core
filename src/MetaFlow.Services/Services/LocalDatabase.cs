//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.Shells
{

    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    public class LocalDatabase : ApplicationComponent
    {
        LocalDatabaseSettings DbSettings { get; }


        SqlConnectionString Connector { get; }

        ISqlClientBroker Broker { get; }

        LocalDatabase(IApplicationContext C, SqlConnectionString Connector)
            : base(C)
        {
            DbSettings = new LocalDatabaseSettings();
            this.Connector = Connector;
            Broker = new SqlClientBroker(Connector, OnBrokerNotification);
            Runtime = C.SqlRuntimeProvider().Database((new SqlDatabaseHandle(Broker, Connector.DatabaseName)));
        }

        public static Option<LocalDatabase> Connect(IApplicationContext C)
        {
            try
            {
                var settings = new LocalDatabaseSettings();
                var connector = SqlConnectionString.Build()
                                    .ConnectToFile(settings.FullServerName, settings.DatabaseLocation + settings.DatabaseFileName)
                                    .Database(settings.DatabaseFileName.ToString())
                                    .Finish();

                var dbname = new SqlDatabaseName(connector.ServerName, connector.DatabaseName);
                var verified = connector.Verify().ToOption();

                if (!verified)
                {
                    var message = AppMessage.Error($"Could not connect to the workspace database '{settings.FullDatabaseName}': {verified.Message}");
                    return verified.ToNone<LocalDatabase>().WithMessage(message);
                }
                else
                    C.NotifyStatus($"Sucessfully connected to [{connector.ServerName}].[{connector.DatabaseName}]");

                return new LocalDatabase(C, connector);

            }
            catch (Exception e)
            {
                return none<LocalDatabase>(e);

            }
        }

        void OnBrokerNotification(SqlNotification notification)
        {

        }

        public ISqlDatabaseRuntime Runtime { get; }


        public override string ToString()
            => $"{Broker.ConnectionString.DatabaseName}";
    }
}
