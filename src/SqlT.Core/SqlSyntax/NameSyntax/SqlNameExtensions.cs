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

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;

    using sxc = Syntax.contracts;

    public static class name_extensions
    {
        public static bool IsEmpty(this ICompositeSqlName name)
            => name.NameComponents.All(c => string.IsNullOrWhiteSpace(c));

        public static SqlTypeName AsTypeName(this ICompositeSqlName name)
            => new SqlTypeName(name);

        public static SqlTableTypeName AsTableTypeName(this ICompositeSqlName name)
            => new SqlTableTypeName(name);

        public static SqlDataTypeName AsDataTypeName(this ICompositeSqlName name)
            => new SqlDataTypeName(name);

        public static SqlTableName AsTableName(this ICompositeSqlName name)
            => new SqlTableName(name);

        public static SqlViewName AsViewName(this ICompositeSqlName name)
            => new SqlViewName(name);

        public static SqlSynonymName AsSynonymName(this ICompositeSqlName name)
            => new SqlSynonymName(name);

        public static SqlProcedureName AsProcedureName(this ICompositeSqlName name)
            => new SqlProcedureName(name);

        public static SqlSequenceName AsSequenceName(this ICompositeSqlName name)
            => new SqlSequenceName(name);

        public static SqlFunctionName AsFunctionName(this ICompositeSqlName name)
            => new SqlFunctionName(name);

        public static SqlParameterName AsParameterName(this ICompositeSqlName name)
            => new SqlParameterName(name);

        public static SqlPrimaryKeyName AsPrimaryKeyName(this ICompositeSqlName name)
            => new SqlPrimaryKeyName(name);

        public static string Format(this ICompositeSqlName name, bool QuoteIdentifiers)
        {
            if (name.IsEmpty())
                return string.Empty;

            var result = string.Empty;
            for (var i = 0; i < name.NameComponents.Count; i++)
            {
                var c = name.NameComponents[i];
                if (!isBlank(c))
                {
                    if (QuoteIdentifiers)
                        result += $"[{c}]";
                    else
                        result += c;

                    if (i != name.NameComponents.Count - 1)
                        result += ".";
                }
            }
            return result;
        }

        /// <summary>
        /// Writes a collection of names to a file in a standardized format
        /// </summary>
        /// <param name="names"></param>
        public static void WriteToFile(this IEnumerable<ICompositeSqlName> names, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var name in names)
                    writer.WriteLine($"{name.GetType().Name}:{name.Format(true)}");

                writer.Flush();
            }
        }

        public static bool IsServerQualified(this sxc.ISqlObjectName n)
            => !string.IsNullOrWhiteSpace(n.ServerNamePart);

        public static bool IsDatabaseQualified(this sxc.ISqlObjectName n)
            => !string.IsNullOrWhiteSpace(n.DatabaseNamePart);

        public static bool IsSchemaQualified(this sxc.ISqlObjectName n)
            => !string.IsNullOrWhiteSpace(n.SchemaNamePart);


        public static SystemUri GetObjectUri(this sxc.ISqlObjectName name)
        {
            var scheme = new SystemUri.SchemeSegment($"db.{name.GetType()}");
            var host = name.IsServerQualified() ? name.ServerNamePart : string.Empty;
            var path = name.IsDatabaseQualified()
                ? $"{bracket(name.DatabaseNamePart)}/{bracket(name.SchemaNamePart)}/{bracket(name.UnqualifiedName)}"
                : $"{bracket(name.SchemaNamePart)}/{bracket(name.UnqualifiedName)}";
            var uri = new SystemUri(scheme, host, path);
            return uri;
        }

        public static N OnDatabase<N>(this N n, SqlDatabaseName db)
            where N : SqlObjectName<N>, new()
             => SqlObjectName<N>.Construct(n.ServerNamePart, db.UnqualifiedName, n.ServerNamePart, n.UnqualifiedName);

        public static N TrimCatalog<N>(this N n)
            where N : SqlObjectName<N>, new()
             => SqlObjectName<N>.Construct(n.SchemaNamePart, n.UnqualifiedName);

        public static N TrimServer<N>(this N n)
            where N : SqlObjectName<N>, new()
             => SqlObjectName<N>.Construct(n.DatabaseNamePart, n.SchemaNamePart, n.UnqualifiedName);

        public static N TrimSchema<N>(this N n)
            where N : SqlObjectName<N>, new()
             => SqlObjectName<N>.Construct(n.UnqualifiedName);

        public static SqlConnectionString LocalConnection(this SqlDatabaseName name)
            => SqlConnectionString.Build().LocalConnection(name);

        public static SqlDatabaseName GetDatabaseName(this sxc.ISqlObjectName n)
            => n.IsServerQualified() ?
            new SqlDatabaseName(n.ServerNamePart, n.DatabaseNamePart)
            : (n.IsDatabaseQualified()
                ? new SqlDatabaseName(n.DatabaseNamePart)
                : SqlDatabaseName.Empty
              );

    }
}
