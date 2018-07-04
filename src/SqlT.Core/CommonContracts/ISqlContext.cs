//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Defines a SqlT-specific <see cref="INodeContext"/>
    /// </summary>
    public interface ISqlContext : INodeContext
    {
               
        /// <summary>
        /// Specifies the connection string used to establish a communications path
        /// </summary>
        SqlConnectionString SqlConnector { get; }

        /// <summary>
        /// The negotiating broker
        /// </summary>
        ISqlClientBroker Broker { get; }

        /// <summary>
        /// The name of the context's default database
        /// </summary>
        SqlDatabaseName DatabaseName { get; }
    }

    /// <summary>
    /// Defines a typed context for use with a generated proxy assembly
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public interface ISqlContext<A> : ISqlContext
        where A : class, ISqlProxyAssembly
    {
        /// <summary>
        /// The negotiating broker
        /// </summary>
        new ISqlProxyBroker Broker { get; }
    }
}
