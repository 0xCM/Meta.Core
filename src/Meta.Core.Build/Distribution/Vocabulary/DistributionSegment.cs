//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using Meta.Core.Project;

    using static metacore;

    partial class Distribution
    {
      
        public abstract class DistributionSegment<S> : IDistributionSegment
            where S : DistributionSegment<S>
        {
            public DistributionSegment(IDistribution Distribution, FolderName SegmentName, IEnumerable<NodeFilePath> ArtifactLocations)
            {
                this.Distribution = Distribution;
                this.Artifacts = map(ArtifactLocations, DefineArtifact);
                this.SegmentName = SegmentName;
            }

            public IDistribution Distribution { get; }

            public FolderName SegmentName { get; }

            public IReadOnlyList<IDistributionArtifact> Artifacts { get; }

            public override string ToString()
                => SegmentName;

            protected virtual IDistributionArtifact DefineArtifact(NodeFilePath ArtifactPath)
                => new DistributionArtifact(this, ArtifactPath);

        }

        public sealed class DistributionSegment : DistributionSegment<DistributionSegment>
        {
            public static IDistributionSegment Define(IDistribution Distribution, FolderName SegmentName, IEnumerable<NodeFilePath> ArtifactLocations)
                    => new DistributionSegment(Distribution, SegmentName, ArtifactLocations);

            public DistributionSegment(IDistribution Distribution, FolderName SegmentName, IEnumerable<NodeFilePath> ArtifactLocations)
                : base(Distribution, SegmentName, ArtifactLocations)
            {
            }


        }


    }

}