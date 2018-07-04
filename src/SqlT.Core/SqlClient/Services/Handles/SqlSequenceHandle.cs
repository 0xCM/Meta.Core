//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Represents a database sequence
    /// </summary>
    public class SqlSequenceHandle : SqlObjectHandle, ISqlSequenceHandle
    {
        public SqlSequenceHandle(ISqlClientBroker Broker, SqlSequenceName SequenceName)
            : base(Broker, SequenceName)
        {
            this.ElementName = SequenceName;
        }

        public new SqlSequenceName ElementName { get; }        
    }

    /// <summary>
    /// Represents a database sequence compatible with the provided type parameter
    /// </summary>
    public class SqlSequenceHandle<T> : SqlSequenceHandle
    {
        public SqlSequenceHandle(ISqlClientBroker Broker, SqlSequenceName SequenceName)
            : base(Broker, SequenceName)
        { }

    }
}
