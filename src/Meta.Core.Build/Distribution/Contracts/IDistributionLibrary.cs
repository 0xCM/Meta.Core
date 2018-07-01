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

    using Meta.Core.Project;

    using static metacore;

    public interface IDistributionLibrary
    {
        FolderPath DistRoot { get; }

        FolderPath DistArchive { get; }

        IEnumerable<DistributionIdentifier> Distributions { get; }

        FolderPath Location(DistributionIdentifier DistId);


        Option<Link<DistributionIdentifier, FilePath>> Archive(DistributionIdentifier DistId);
    }

}