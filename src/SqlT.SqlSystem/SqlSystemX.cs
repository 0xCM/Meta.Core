﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using PN = SqlT.Core.SqlPropertyNames;

    public static class SqlSystemX
    {
        public static IEnumerable<(vTable Subject, SqlEnumProviderProperty Property)> SqlEnumProviders(this IEnumerable<vTable> tables)
            => from t in tables
               let p = t.SqlEnumProvider()
               where p.IsSome()
               select (t, p.ValueOrDefault());

        public static Option<SqlReceiverProperty> Receiver(this vTable provider)
            => provider.TryFindProperty(PN.ReceiverName)
                       .Map(x => new SqlReceiverProperty(x.value?.ToString()));

        public static Option<SqlColumnRoleKind> Role(this vColumn column)
            => column.TryFindProperty(PN.ColumnRole)
                       .Map(x => new SqlColumnRoleProperty(x.value?.ToString()).PropertyValue);

        public static Option<SqlDocumentationProperty> Documentation(this vSystemElement element)
            => element.TryFindProperty(PN.Documentation)
                       .Map(x => new SqlDocumentationProperty(x.value?.ToString()));

        public static Option<SqlTableRoleType> Role(this vTable table)
            => table.TryFindProperty(PN.TableRole)
               .Map(x => new SqlTableRoleProperty(x.value?.ToString()).PropertyValue);

        public static bool IsTypeTable(this vTable table)
            => table.Role().Map(r => r == SqlTableRoleType.TypeTable, () => false);

        static ScalarResult<T> ExecuteScalarScript<T>(this ISqlDatabaseHandle h,
            string sql, params (string, object)[] args)
                => h.Broker.ExecuteScalarScript<T>(sql, args);

        public static Option<SqlVersion> GetCompatibilityVersion(this ISqlDatabaseHandle h)
        {
            var sql = h.DatabaseName.SQL_COMPATIBILITY_LEVEL();
            return h.ExecuteScalarScript<byte>(sql).TryMapValue(x => ((SqlVersionIndicator)x).GetVersion());
        }

        public static K DatabaseType<K>(this vDatabase db)
            where K : Enum
           => db.Properties.TryFind(PN.DbType)
                       .MapValueOrDefault(xp
                               => parseEnum<K>(toString(xp.value)));


        public static Version DatabaseVersion(this vDatabase db)
            => db.Properties.TryFind(PN.DbVersion)
                        .MapValueOrDefault(xp
                                => Version.Parse(toString(xp.value)),
                                        Version.Parse("1.0.0.0"));

    }

}
