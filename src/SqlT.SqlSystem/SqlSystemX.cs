//-------------------------------------------------------------------------------------------
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

    }

}
