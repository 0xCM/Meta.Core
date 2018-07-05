//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Defines a broker for a specific table
    /// </summary>
    /// <typeparam name="T">The table's proxy type</typeparam>
    public class SqlTableBroker<T> : SqlTabularBroker<T>, ISqlTableBroker<T>
       where T : class, ISqlTableProxy, new()
    {

        public SqlTableBroker(ISqlProxyBroker InnerBroker)
            : base(InnerBroker)
        {

            this.BrokeredTableName = Metadata.Table<T>().ObjectName;
        }

        /// <summary>
        /// The name of the table
        /// </summary>
        public SqlTableName BrokeredTableName { get; }

        /// <summary>
        /// The table description
        /// </summary>
        public SqlTableProxyInfo TableInfo
            => Metadata.Table<T>();


    }
}