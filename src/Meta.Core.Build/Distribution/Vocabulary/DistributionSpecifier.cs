//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public partial class Distribution
    {
        public sealed class DistributionSpecifier : IDistribution
        {
            public DistributionSpecifier(DistributionIdentifier DistId, NodeFolderPath Location, IEnumerable<FolderName> SegmentFolders)
            {
                this.DistId = DistId;
                this.Location = Location;
                this.Segments = map(SegmentFolders, CreateSegment);               
            }

            public DistributionIdentifier DistId { get; }

            public NodeFolderPath Location { get; }

            public IReadOnlyList<IDistributionSegment> Segments { get; }

            bool IsAssemblyFolder(FolderName SegmentFolder)
                => equals(SegmentFolder.Value, CommonFileExtensions.Dll)
                || equals(SegmentFolder.Value, CommonFileExtensions.Exe);

            SegmentFactory GetSegmentFactory(FolderName SegmentFolder)
                => IsAssemblyFolder(SegmentFolder)
                ? new SegmentFactory(AssemblySegment.Define)
                : new SegmentFactory(DistributionSegment.Define);

            public IDistributionSegment CreateSegment(FolderName SegmentFolder)
                => GetSegmentFactory(SegmentFolder)(this, SegmentFolder, (Location + SegmentFolder).Files(recursive: true));

            public override string ToString()
                => Location.ToString();
        }

    }   

}