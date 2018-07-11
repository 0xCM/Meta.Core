//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines contract for registering and finding defined <see cref="SystemNode"/> representations
    /// </summary>
    public interface ISystemNodeRegistry
    {
        /// <summary>
        /// Includes each supplied node in the registry if it does not already exist
        /// </summary>
        /// <param name="nodes">The nodes to register</param>
        void RegisterNodes(params SystemNode[] nodes);

        /// <summary>
        /// Searches for a system node by identifier
        /// </summary>
        /// <param name="identifier">The identifier to match</param>
        /// <returns></returns>
        Option<SystemNode> LookupNode(SystemNodeIdentifier identifier);

        /// <summary>
        /// Searches for a system node by name
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns></returns>
        Option<SystemNode> LookupNode(string name);
    }



}