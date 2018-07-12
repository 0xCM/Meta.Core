//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;

    using SqlT.Core;

    static partial class SqlStatusMessages
    {

        public static IAppMessage CollectingServerMetadata(SqlServerName ServerName)
            => AppMessage.Inform("Collection metadata for @ServerName",
                new
                {
                    ServerName
                });

        public static IAppMessage CollectingDatabaseMetadata(SqlDatabaseName DatabaseName)
            => AppMessage.Inform("Collecting metadata for [@ServerName].[@DatabaseName]",
                new
                {
                    DatabaseName.ServerName,
                    DatabaseName = DatabaseName.UnqualifiedName
                });

        public static IAppMessage SelectingInstanceInformation(SqlServerName ServerName)
            => AppMessage.Inform("Selecting SQL Server instance description for @ServerName",
                new
                {
                    ServerName,
                });


        public static IAppMessage MetadataCollectionError(Exception error, SqlDatabaseName DatabaseName)
            => AppMessage.Error("An error occurred while collecting metadata for [@ServerName].[@DatabaseName] - @Message: @Detail",
                new
                {
                    ServerName = DatabaseName.ServerName,
                    DatabaseName = DatabaseName.UnqualifiedName,
                    error.Message,
                    Detail = error.ToString()
                });
    }
}