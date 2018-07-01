//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System.Collections.Generic;


    public sealed class LibraryArea : WorkspaceArea<LibraryArea>
    {
        public const string DefaultName = "lib";
        public static implicit operator WorkspaceArea(LibraryArea area)
            => new WorkspaceArea(area);

        public LibraryArea(string AreaName, IEnumerable<DistributedArtifact> Distributions)
            : base(AreaName)
        {
            Distributions = Distributions.ToReadOnlyList();
        }

        public LibraryArea(IEnumerable<DistributedArtifact> Distributions)
            : this(DefaultName, Distributions)
        {
            
        }

        public IReadOnlyList<DistributedArtifact> Distributions { get; }
    }
}
