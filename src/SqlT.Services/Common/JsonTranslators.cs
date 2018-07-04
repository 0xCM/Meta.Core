//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Core;
    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;
    
    using static metacore;    
       
    public static class JsonTranslators
    {
        static readonly IReadOnlyDictionary<string, Func<string, IName>> Parsers
            = new Dictionary<string, Func<string, IName>>
            {
                [SqlDatabaseName.UriPartIdentifier] = SqlDatabaseName.Parse,
                [SqlServerName.UriPartIdentifier] = SqlServerName.Parse,
                [SqlTableName.UriPartIdentifier] = SqlTableName.Parse,
                [SqlSchemaName.UriPartIdentifier] = SqlSchemaName.Parse,
                [SqlTableTypeName.UriPartIdentifier] = SqlTableTypeName.Parse,
                [SqlProcedureName.UriPartIdentifier] = SqlProcedureName.Parse,
                [SqlFunctionName.UriPartIdentifier] = SqlFunctionName.Parse,
                [SqlMessageTypeName.UriPartIdentifier] = SqlMessageTypeName.Parse,
                [SqlParameterName.UriPartIdentifier] = SqlParameterName.Parse
            };

        static string FormatComposite(string component, ICompositeSqlName name)
            => $"{component}/{string.Join("/", name.NameComponents)}";

        static string FormatSimple(string component, ISqlIdentifier name)
            => $"{component}/{string.Join("/", name.IdentifierText)}";

        static readonly IReadOnlyDictionary<Type, Func<ISqlIdentifier, string>> Formatters
            = new Dictionary<Type, Func<ISqlIdentifier, string>>
            {
                [typeof(SqlServerName)] = n => FormatSimple(SqlServerName.UriPartIdentifier, n),
                [typeof(SqlDatabaseName)] = n => FormatComposite(SqlDatabaseName.UriPartIdentifier, (ICompositeSqlName)n),
                [typeof(SqlSchemaName)] = n => FormatSimple(SqlSchemaName.UriPartIdentifier, n),
                [typeof(SqlParameterName)] = n => FormatSimple(SqlParameterName.UriPartIdentifier, n),
                [typeof(SqlMessageTypeName)] = n => FormatSimple(SqlMessageTypeName.UriPartIdentifier, n),
                [typeof(SqlTableName)] = n => FormatComposite(SqlTableName.UriPartIdentifier, cast<ICompositeSqlName>(n)),
                [typeof(SqlTableTypeName)] = n => FormatComposite(SqlTableTypeName.UriPartIdentifier, cast<ICompositeSqlName>(n)),
                [typeof(SqlProcedureName)] = n => FormatComposite(SqlProcedureName.UriPartIdentifier, cast<ICompositeSqlName>(n)),
                [typeof(SqlFunctionName)] = n => FormatComposite(SqlFunctionName.UriPartIdentifier, cast<ICompositeSqlName>(n)),

            };

        static IName parse_name(this Json j)
        {
            var components = j.Text.Split('/');
            if (components.Length == 0 || components.Length == 1)
                return SqlName.Empty;

            var text = components[1];
            var segment = components[0];
            return Parsers.TryFind(segment).Map(p => p(text), () => new SqlName(text));
        }

        static string Format(this ISqlIdentifier name)
            => Formatters.TryFind(
                    name.GetType()).Map(f => f(name), 
                                        () => name?.ToString() ?? string.Empty);

        static IJsonConverter CreateNameConverter(this IJsonSerializer serializer)
        {
            return new JsonTranslator(
                type => Formatters.ContainsKey(type),
                name => (name as ISqlIdentifier).Format(), 
                json => json.parse_name());
        }

        static IJsonConverter CreateConnectorConverter(this IJsonSerializer serializer)
            => new JsonTranslator(
                type => type.Equals(typeof(SqlConnectionString)),
                value => (value as SqlConnectionString).ToString(),
                json => new SqlConnectionString(json)
                );

        public static void RegisterSqlConverters(this IJsonSerializer serializer)
        {
            serializer.RegisterConverter(serializer.CreateNameConverter());
            serializer.RegisterConverter(serializer.CreateConnectorConverter());
        }

        public static void RegisterSqlJsonConveters(this IApplicationContext C)
            => RegisterSqlConverters(C.JsonSerializer());
    }
}
