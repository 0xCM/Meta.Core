//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public interface ISqlServerNode : ISystemNode
    {
        /// <summary>
        /// The computational device that provides execution context for SQL Server
        /// </summary>
        SystemNode Host { get; }

        /// <summary>
        /// Identifies a SQL Server installation within the collection of SQL Server installations on a server
        /// </summary>
        string InstanceName { get; }

    }



}