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