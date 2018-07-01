//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System;
    using System.Collections.Generic;
    
    using D = NodeUncDrive;
    using N = SystemNode;
    using P = FilePath;
    using FN = FileName;
    using FP = FolderPath;
    using F = FolderName;
    using RP = RelativePath;

    public interface INodeFileSystemLocator
    {

        D UncShare(N Host);

        D UncShare(N n, RP path);

        D UncShare(N n, CatalogSubject subject);

        D UncFolder<S>(N node)
            where S : CatalogSubject<S>;

        P UncFilePath<S>(N node, FN filename)
            where S : CatalogSubject<S>;

        D Subfolder<S>(D d)
             where S : CatalogSubject<S>;

        FP Folder<S>()
            where S : CatalogSubject<S>;

        Option<P> UncFilePath(N n, SystemResourceUrn urn);


        FP Folder<S>(FP folder)
            where S : CatalogSubject<S>;

        P File<S>(FN filename)
                    where S : CatalogSubject<S>;

        D TopUncShare(N n, F Folder);

        FP AbsoluteLocation(N node, RP relative);
    }


}
 