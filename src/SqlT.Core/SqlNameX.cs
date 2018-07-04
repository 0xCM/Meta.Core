//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using sx = SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;


    public static class SqlNameX
    {
        
        public static sx.object_name object_name(this sxc.ISqlObjectName src)
        {
            switch(src.NameComponents.Count)
            {
                case 4:
                    return new sx.server_qualified_name(src.SchemaNamePart, src.DatabaseNamePart, src.SchemaNamePart, src.UnqualifiedName);
                case 3:
                    return new sx.database_qualified_name(src.DatabaseNamePart, src.SchemaNamePart, src.UnqualifiedName);
                case 2:
                    return new sx.schema_qualified_name(src.SchemaNamePart, src.UnqualifiedName);
                default:
                    return new sx.simple_object_name(src.UnqualifiedName);
                
            }
        }

        public static string ToUriPart(this SqlServerName ServerName)
            => ServerName.UnqualifiedName.ToLower();

        public static string ToUriPart(this SqlDatabaseName DatabaseName)
            => DatabaseName.UnqualifiedName.ToLower().Replace("app.", String.Empty);

        public static string ToUriPart(this SqlSchemaName SchemaName)
            => SchemaName.UnqualifiedName.ToLower();

        public static SystemUri ToUri(this SqlTableName table, string query = null)
        {
            var builder = new UriBuilder();
            builder.Scheme = "table";
            builder.Host = table.ServerName.ToUriPart();
            builder.Path = $"{table.DatabaseName.ToUriPart()}/{table.SchemaName.ToUriPart()}/{table.UnqualifiedName}";
            if (!string.IsNullOrEmpty(query))
                builder.Query = query;
            var uri = builder.Uri;
            return new SystemUri(uri);
        }


    }

}