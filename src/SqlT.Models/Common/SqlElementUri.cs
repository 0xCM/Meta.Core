//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    using static metacore;

    public static class SqlElementUri
    {
        static SystemUri GetDatabaseUri(this SqlDatabaseName name)
        {
            var scheme = new SystemUri.SchemeSegment($"db");
            var host = name.IsServerQualified ? name.ServerNamePart : string.Empty;
            var path = bracket(name.UnqualifiedName);
            return new SystemUri(scheme, host, path);
        }

        static SystemUri GetServerUri(this SqlServerName name)
        {
            var scheme = new SystemUri.SchemeSegment($"server");
            var host = name.UnqualifiedName;
            var path = string.Empty;
            return new SystemUri(scheme, host, path);
        }

        static SystemUri GetSchemaUri(this SqlSchemaName name)
        {
            var scheme = new SystemUri.SchemeSegment($"db.{SqlElementTypeNames.Schema.ToLowerInvariant()}");
            var host = name.IsServerQualified ? name.ServerNamePart : string.Empty;
            var path = name.IsDatabaseQualified
                ? $"{bracket(name.DatabaseNamePart)}/{bracket(name.UnqualifiedName)}"
                : $"{bracket(name.UnqualifiedName)}";
            var uri = new SystemUri(scheme, host, path);
            return uri;
        }

        public static SystemUri GetUri(this SqlTableQuery q)
        {
            var tableUri = q.SourceName.GetUri();
            if (q.IsFiltered)
                return q.SourceName.GetUri().WithNewQuery(q.Filter.Value);
            else
                return tableUri;
        }

        public static SystemUri GetUri(this IName name)
        {
            switch(name)
            {
                case sxc.ISqlObjectName n:
                    return n.GetObjectUri();
                case SqlDatabaseName n:
                    return GetDatabaseUri(n as SqlDatabaseName);
                case SqlServerName n:
                    return GetServerUri(n as SqlServerName);
                case SqlSchemaName n:
                    return GetSchemaUri(n as SqlSchemaName);
            }
            return SystemUri.Empty;
        }

    }
}
