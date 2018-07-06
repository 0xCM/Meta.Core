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

    static partial class SqlStatusMessages
    {

        public static IApplicationMessage CollectingServerMetadata(SqlServerName ServerName)
            => ApplicationMessage.Inform("Collection metadata for @ServerName",
                new
                {
                    ServerName
                });

        public static IApplicationMessage CollectingDatabaseMetadata(SqlDatabaseName DatabaseName)
            => ApplicationMessage.Inform("Collecting metadata for [@ServerName].[@DatabaseName]",
                new
                {
                    DatabaseName.ServerName,
                    DatabaseName = DatabaseName.UnqualifiedName
                });

        public static IApplicationMessage SelectingInstanceInformation(SqlServerName ServerName)
            => ApplicationMessage.Inform("Selecting SQL Server instance description for @ServerName",
                new
                {
                    ServerName,
                });


        public static IApplicationMessage MetadataCollectionError(Exception error, SqlDatabaseName DatabaseName)
            => ApplicationMessage.Error("An error occurred while collecting metadata for [@ServerName].[@DatabaseName] - @Message: @Detail",
                new
                {
                    ServerName = DatabaseName.ServerName,
                    DatabaseName = DatabaseName.UnqualifiedName,
                    error.Message,
                    Detail = error.ToString()
                });
    }
}