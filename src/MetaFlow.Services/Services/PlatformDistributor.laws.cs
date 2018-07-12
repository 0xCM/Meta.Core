//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;
    using static metacore;

    using N = SystemNode;
    using DistId = DistributionIdentifier;

    public interface IPlatformDistributor : INodeService
    {        

        Option<NodeFilePath> CompressTo(DistId DistId, N DstNode);

        Option<NodeFilePath> ReleaseTo(DistId DistId, N DstNode);
        
        Option<NodeFilePath> ReleaseTo(DistId DistId, NodeFilePath SrcPath, N DstNode);


        /// <summary>
        /// Creates a distribution based on the lastest versions existing artifacts
        /// </summary>
        /// <param name="DistId">Identifies the type of distribution to create</param>
        /// <returns></returns>
        Option<NodeFilePath> CreateDistribution(DistId DistId);


        IEnumerable<NodeFilePath> ArchivedDistributions(DistId DistId);
    }




}