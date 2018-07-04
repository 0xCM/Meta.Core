//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Mediates access to a physical SQL Server database or representation thereof
    /// </summary>
    public sealed class SqlDatabaseHandle : SqlElementHandle, ISqlDatabaseHandle
    {
        public static SqlDatabaseHandle Create(ISqlClientBroker Broker, SqlDatabaseName DatabaseName)
            => new SqlDatabaseHandle(Broker, DatabaseName);

        public SqlDatabaseHandle(ISqlClientBroker Broker, SqlDatabaseName DatabaseName)
            : base(Broker, DatabaseName)
        {
            this.DatabaseName = DatabaseName;
        }

        public SqlDatabaseName DatabaseName { get; }
    }
}
