//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using static metacore;
    using N = SystemNode;
    
    public class NfsFolderNames : TypedItemList<NfsFolderNames, FolderName>
    {
     
        public static readonly FolderName DataFileFolderName = FolderName.Parse("DataFiles");

        public static readonly FolderName DatasetsFolderName = FolderName.Parse("Datasets");

        public static readonly FolderName PlatformFolderName = FolderName.Parse("Platform");

        public static readonly FolderName IncomingFolderName = "incoming";

        public static readonly FolderName OutgoingFolderName = FolderName.Parse("outgoing");

        public static readonly FolderName ExportFolderName = FolderName.Parse("exported");

        public static readonly FolderName UnclassifiedFolderName = FolderName.Parse("Unclassified");

        public static readonly FolderName AppLogFolderName = FolderName.Parse("logs");
            
    }

}