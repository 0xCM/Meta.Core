//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using static metacore;
    using static NfsFolderNames;

    using N = SystemNode;
    using FN = Core.NavigationFolders;

    public class PlatformNav : FileSystemNavigator<PlatformNav>
    {
        public PlatformNav(IApplicationContext C, N Host)
            : base(C, Host)
        {
            var uncRoot = Host.NodeFolder(RuntimeNav.OpsRootVar.ResolveValue().Require() + FolderName.Parse(FN.PdrUnc.FolderName));
            this.NavRoot = Host.NodeFolder(uncRoot + HostFolderName + PlatformFolderName);
            this.ReleaseFolder = NavRoot + files.folderName(FN.PlatformDistributions.FolderName);
        }

        public override NodeFolderPath NavRoot { get; }

        public NodeFolderPath ReleaseFolder { get; }

        public NodeFolderPath BackupFolder
            => NavRoot + files.folderName(FN.PublishedBackups.FolderName);

        public NodeFolderPath BackupArchiveFolder
            => NavRoot + files.folderName(FN.BackupArchives.FolderName);

        public IEnumerable<NodeFilePath> BackupArchives
            => BackupArchiveFolder.Files("*.zip");


        public IEnumerable<NodeFilePath> PublishedBackups
            => BackupFolder.Files();


    }


}