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
    using System.Linq.Expressions;

    using Meta.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    public static class SqlTabularBrokerX
    {
        /// <summary>
        /// Creates a tabular broker predicated on a supplied type
        /// </summary>
        /// <typeparam name="T">The tabular type</typeparam>
        /// <param name="broker">The broker serving as a factory</param>
        /// <returns></returns>
        public static ISqlTabularBroker<T> TabularBroker<T>(this ISqlProxyBroker broker)
            where T : class, ISqlTabularProxy, new()
               => new SqlTabularBroker<T>(broker);

        public static SqlDatabaseName DatabaseName(this ISqlTabularBroker broker)
            => new SqlDatabaseName(
                broker.ConnectionString.ServerName,
                broker.ConnectionString.DatabaseName);

        public static SqlTableHandle<T> Table<T>(this ISqlTabularBroker broker)
            where T : class, ISqlTableProxy, new()
                => new SqlTableHandle<T>(broker);

        public static SqlTableHandle<T> Table<T>(this ISqlTabularBroker<T> broker)
            where T : class, ISqlTableProxy, new()
                => new SqlTableHandle<T>(broker);

        public static sxc.ISqlObjectName QualifiedName<T>(this ISqlTabularBroker broker)
            where T : class, ISqlTabularProxy, new()
        {
            var tabular = broker.TabularInfo;
            return tabular.ProxyKind.GetDbScopedName(tabular.ObjectName, broker.DatabaseName());
        }

        public static sxc.ISqlObjectName QualifiedName<T>(this ISqlTabularBroker<T> broker)
            where T : class, ISqlTabularProxy, new()
        {
            var tabular = broker.TabularInfo;
            return tabular.ProxyKind.GetDbScopedName(tabular.ObjectName, broker.DatabaseName());
        }

        public static SqlColumnProxyInfo ColumnDescription<T, C>(this ISqlTabularBroker<T> broker, Expression<Func<T, C>> selector)
                where T : class, ISqlTabularProxy, new()
        {
            var tabular = broker.TabularInfo;
            var member = selector.GetMember();
            var column = tabular.FindColumnByRuntimeName(member.Name);
            return column;
        }

        public static ScalarResult<T> ExecuteScalarScript<T>(this ISqlTabularBroker broker, SqlScript sql)
            => broker.InnerBroker.ExecuteScalarScript<T>(sql);

        public static IEnumerable<T> SelectColumn<T>(this ISqlTabularBroker broker, SqlScript sql, int position = 0, bool eatnull = true)
        {
            using (var reader = SqlColumnReader.Create<T>(broker.ConnectionString, sql, position))
            {
                foreach (var value in reader)
                        yield return value.x1;
            }
        }

        /// <summary>
        /// Intantiates a table-specific broker
        /// </summary>
        /// <typeparam name="T">The table's proxy type</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <returns></returns>
        public static ISqlTableBroker<T> TableBroker<T>(this ISqlProxyBroker broker)
            where T : class, ISqlTableProxy, new()
                => new SqlTableBroker<T>(broker);
    }

}