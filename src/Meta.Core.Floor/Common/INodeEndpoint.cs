//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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