//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    /// <summary>
    /// Characterizes a system node communication port
    /// </summary>
    public interface INodeEndpoint
    {
        /// <summary>
        /// The hosting node
        /// </summary>
        SystemNodeIdentifier Node { get; }

        /// <summary>
        /// The hosting system
        /// </summary>
        SystemUri Identifier { get; }

        /// <summary>
        /// Covariance/contravariance
        /// </summary>
        EndpointRole Role { get; }

    }

    public interface INodeEndpoint<X> : INodeEndpoint
    {

    }


}