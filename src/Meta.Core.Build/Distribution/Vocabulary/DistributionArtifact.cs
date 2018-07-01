//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;

    partial class Distribution
    {
        public abstract class DistributionArtifact<A>   : IDistributionArtifact
            where A : DistributionArtifact<A>
        {
            public IDistributionSegment Segment { get; }

            public NodeFilePath ArtifactPath { get; }

            public DistributionArtifact(IDistributionSegment Segment, NodeFilePath ArtifactPath)
            {
                this.Segment = Segment;
                this.ArtifactPath = ArtifactPath;
            }

            public override string ToString()
                => ArtifactPath.ToString();
        }


        public sealed class DistributionArtifact : DistributionArtifact<DistributionArtifact>
        {

            public DistributionArtifact(IDistributionSegment Segment, NodeFilePath ArtifactPath)
                : base(Segment, ArtifactPath)
            {

            }



        }

    }
}
