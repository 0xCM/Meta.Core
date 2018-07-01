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

    using static metacore;

    using DistId = DistributionIdentifier;
 
    public class DistributionLibrary : ApplicationComponent, IDistributionLibrary
    {
        public DistributionLibrary(IApplicationContext C, FolderPath DistRoot, FolderPath DistArchive)
            : base(C)
        {
            this.DistRoot = DistRoot;
            this.DistArchive = DistArchive;
        }

        public FolderPath DistRoot { get; }

        public FolderPath DistArchive { get; }

        public IEnumerable<DistId> Distributions
            => from f in DistRoot.Subfolders()
               select DistId.Parse(f.FolderName.Value);

        public FolderPath Location(DistId DistId)
            => DistRoot + DistId;

        public Option<Link<DistId, FilePath>> Archive(DistId DistId)
             => from path in some(link(Location(DistId), DistArchive + FileName.Parse(DistId.IdentifierText + ".zip")))
                from archive in C.FileArchiveManager().CreateArchive(path)
                select link(DistId, archive.Target);
    }
}