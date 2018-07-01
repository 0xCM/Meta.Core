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
    using Meta.Core;

    using Meta.Core.Project;

    using static metacore;



    using DistId = DistributionIdentifier;
    using N = SystemNode;

    public class AssetNavigator : FileSystemNavigator<AssetNavigator>
    {
           
        public AssetNavigator(INodeContext C)
            : base(C)
        {

            this.NavRoot = Host.NodeFolder(CommonFolders.DevAssets);
        }

        public AssetNavigator(INodeContext C, FolderPath HostRoot)
            : base(C)
        {
            this.NavRoot = Host.NodeFolder(HostRoot);
        }


        public AssetNavigator(IApplicationContext C, N Host)
            : this(C.NodeContext(Host))
        {

        }

        public AssetNavigator(IApplicationContext C, N Host, FolderPath HostRoot)
            : this(C.NodeContext(Host), HostRoot)
        {

        }

        public override NodeFolderPath NavRoot { get; }

        public NodeFolderPath AssetRoot(FolderName AssetFolder)
            => NavRoot + AssetFolder;

        public NodeFolderPath DistRoot
            => AssetRoot("dist");

        public NodeFolderPath DistArchiveRoot
            => AssetRoot("dist.a");

        public NodeFolderPath DocRoot
            => AssetRoot("docs");

        public NodeFolderPath XsdRoot
            => AssetRoot("xsd");

        public IEnumerable<NodeFilePath> DistArchives(DistId distId)
            => DistArchiveRoot.Files($"{distId}*.zip").Reverse();
  
        public IEnumerable<NodeFilePath> Documents(params FileExtension[] ext)
            => ext.Length == 0
            ? DocRoot.Files(recursive: true)
            : from x in ext
              from file in DocRoot.Files(x, true)
              select file;

        public IEnumerable<NodeFilePath> XsdSchemas()
            => XsdRoot.Files(CommonFileExtensions.Xsd, true);

        public NodeFolderPath DistFolder(DistId distId)
            => DistRoot + FolderName.Parse(distId);

        public NodeFolderPath ExeDistDir(DistId distId)
            => DistFolder(distId) + FolderName.Parse("exe");

        public NodeFolderPath SqlDistDir(DistId distId)
            => DistFolder(distId) + FolderName.Parse("sql");

        public NodeFolderPath SqlDacDistDir(DistId distId)
            => SqlDistDir(distId) + FolderName.Parse("dacpac");

        public NodeFilePath SqlDacPacPath(DistId distId, FileName PackageFileName)
            => SqlDacDistDir(distId) + PackageFileName;

        public FileName DacFileName(string PackageName)
            => FileName.Parse($"{PackageName}").AddExtension(CommonFileExtensions.Dacpac, true);

        public NodeFilePath DacProfilePath(DistId distId, string PackageName, N DstNode)
            => SqlDacDistDir(distId) 
            + DacFileName(PackageName).ChangeExtension($"{DstNode}.{CommonFileExtensions.DacProfile}");


    }
}