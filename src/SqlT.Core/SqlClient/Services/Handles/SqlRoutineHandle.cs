//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Represents a database routine
    /// </summary>
    public abstract class SqlRoutineHandle : SqlObjectHandle, ISqlRoutineHandle
    {
        protected SqlRoutineHandle(ISqlClientBroker Broker, sxc.ISqlObjectName ElementName)
            : base(Broker, ElementName)
        {

        }
    }
}
