//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;
    using SqlT.Core;

    
    using static CommonFileExtensions;
    using static metacore;

    using DistId = DistributionIdentifier;
    
    using N = SystemNode;
    using static MetaFlow.MF.PlatformDistributions;

    public class MetaFlowAssetNav : FileSystemNavigator<MetaFlowAssetNav>
    {

        protected static readonly FolderPathVariable DistRootVar = new FolderPathVariable("DistRootDir");

        public MetaFlowAssetNav(INodeContext C)
            : base(C)
        {
            this.NavRoot = Host.NodeFolder(DistRootVar).ParentFolder.Require();
        }

        public MetaFlowAssetNav(INodeContext C, FolderPath HostRoot)
            : base(C)
        {
            this.NavRoot = Host.NodeFolder(HostRoot);
        }


        public MetaFlowAssetNav(IApplicationContext C, N Host)
            : this(C.NodeContext(Host))
        {
            
        }

        public MetaFlowAssetNav(IApplicationContext C, N Host, FolderPath HostRoot)
            : this(C.NodeContext(Host), HostRoot)
        {
            
        }


        public override NodeFolderPath NavRoot { get; }


        public NodeFolderPath DistRoot
            => NavRoot + files.folderName(Core.NavigationFolders.PdrDist.FolderName);

        public NodeFolderPath DistArchiveFolder
            => NavRoot + files.folderName(Core.NavigationFolders.PdrDistArchive.FolderName);

        public IEnumerable<NodeFilePath> DistArchives(DistId distId)
            => DistArchiveFolder.Files($"{distId}*.zip").Reverse();

        public NodeFolderPath DistFolder(DistId distId)
            => DistRoot + FolderName.Parse(distId);

        public NodeFolderPath ExeDistDir
            => DistRoot + FolderName.Parse(MetaFlowExe);

        public NodeFolderPath SqlDistDir
            => DistRoot + FolderName.Parse(MetaFlowSql);

        public NodeFolderPath SqlDacDistDir
            => SqlDistDir + FolderName.Parse("dacpac");

        public NodeFilePath SqlDacPacPath(FileName PackageFileName)
            => SqlDacDistDir + FileName.Parse(PackageFileName);

        public FileName DacFileName(SqlPackageName PackageName)
            => FileName.Parse($"{PackageName}").AddExtension(Dacpac, true);

        public NodeFilePath DacFilePath(SqlPackageName PackageName)
            => SqlDacDistDir + DacFileName(PackageName);

        public NodeFilePath DacProfilePath(SqlPackageName PackageName, N DstNode)
            => SqlDacDistDir + DacFileName(PackageName).ChangeExtension($"{DstNode}.{DacProfile}");

    }
} 