//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;
    using MetaFlow.Core;

    using static metacore;

    using N = SystemNode;

    using FN = MetaFlow.Core.NavigationFolders;

    public sealed class RuntimeNav : FileSystemNavigator<RuntimeNav>
    {
        internal static readonly FolderPathVariable OpsRootVar = new FolderPathVariable("MFR");

        public RuntimeNav(IApplicationContext C, N Other)
            : base(C, Other)
        {
                      
            this.NavRoot = TopUncRoot + files.folderName($"{Other.NodeIdentifier}.PDR"); 
        }

        public override NodeFolderPath NavRoot { get; }

        public override IEnumerable<NodeFolderPath> Folders
            => new FN().Select(f => NavRoot + files.folderName(f.FolderName));

        public NodeFolderPath AdminFolder
            => NavRoot + files.folderName(FN.PdrAdmin.FolderName);

        public NodeFolderPath AssetFolder
            => NavRoot + files.folderName(FN.PdrAssets.FolderName);
       
        public IEnumerable<NodeFilePath> DistributionArchives
            => (AssetFolder + files.folderName("dist.a")).Files("*.zip");

        public NodeFolderPath LogFolder
            => NavRoot + files.folderName(FN.PdrLogs.FolderName);

        public NodeFolderPath ToolFolder
            => NavRoot + files.folderName(FN.PdrTools.FolderName);

        public NodeFolderPath ShellFolder
            => NavRoot + files.folderName(FN.PdrShells.FolderName);

        public NodeFolderPath UncFolder
            => NavRoot + files.folderName(FN.PdrUnc.FolderName);

        public NodeFolderPath NodeFolder
            => NavRoot + files.folderName("nodes");

        public MetaFlowAssetNav AssetNav
            => new MetaFlowAssetNav(C, Host, AssetFolder);

    }


}