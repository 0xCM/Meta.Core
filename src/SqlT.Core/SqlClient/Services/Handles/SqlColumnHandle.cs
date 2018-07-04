//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Represents a database table
    /// </summary>
    public class SqlColumnHandle : SqlElementHandle, ISqlColumnHandle
    {
        public SqlColumnHandle(ISqlClientBroker Broker, SqlTableName TableName, SqlColumnName ColumnName)
            : base(Broker, ColumnName)
        {
            this.ElementName = ColumnName;
            this.TableName = TableName;
        }

        public new SqlColumnName ElementName { get; }

        public SqlTableName TableName { get; }
    }

    public class SqlColumnHandle<T,C> : SqlColumnHandle, ISqlColumnHandle<T,C>
        where T : ISqlTabularProxy, new()
    {
        public SqlColumnHandle(ISqlProxyBroker Broker, SqlColumnName ColumnName)
            : base
            (
                Broker, 
                (SqlTableName)Broker.Metadata.Tabular<T>().ObjectName,  
                Broker.Metadata.Column<T>(ColumnName).ColumnName
            )
        {

        }

        public new ISqlProxyBroker Broker
            => base.Broker as ISqlProxyBroker;
       
    }


    
}
