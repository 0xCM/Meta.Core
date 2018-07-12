//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using Meta.Core;

    using SqlT.Core;

    using static metacore;
    using static NfsFolderNames;

    using N = SystemNode;       

    public partial class NodeFileSystem : ApplicationService<NodeFileSystem, INodeFileSystem>, INodeFileSystem
    {
        protected static readonly FolderPathVariable OpsRootVar = new FolderPathVariable("MetaFlowRoot");
        protected static readonly FolderName UncRootFolderName = Core.NavigationFolders.PdrUnc.FolderName;

        static FolderPath OpsUncRootPath(N Host, FolderPath OpsRoot)
            => OpsRoot + UncRootFolderName + (FolderName.Parse(Host.NodeIdentifier.IdentifierText + ".MFR"));

        public NodeFileSystem(IApplicationContext C)
            : base(C)
        {
           
        }

        public T Nav<T>(N Host)
            where T : class, IFileSystemNavigator
            => cast<T>(Activator.CreateInstance(typeof(T), array<object>(C, Host)));

        public NodeFolderPath OpsRoot(N Host)
           =>  Host.NodeFolder(OpsRootVar.ResolveValue().ValueOrDefault("Z:\\"));

        public FolderPath OpsUncRoot(N Host)
            => OpsRootVar.ResolveValue().Map(
                root => OpsUncRootPath(Host, root),
                () => OpsUncRootPath(Host, "Z:\\")
                );

        public NodeFolderPath SqlDacRoot(N Host)
            => Host.NodeFolder(CommonFolders.DistRootDir + FolderName.Parse("metaflow-sql"));

        N sqlnode(SystemNodeIdentifier id)
            => (from s in C.SqlNode(id) from n in s.ToSystemNode() select n).Require();

        public DevNav DevNavigator(N Host)
            => new DevNav(C, Host);

        public DataSetNav DSNav(N Host)
            => new DataSetNav(C, new NodeFolderPath(Host, FolderPath.Empty));

        public RuntimeNav OpsNav(N Host)
            => new RuntimeNav(C, Host);

        public MetaFlowAssetNav AssetNav(N Host)
            => new MetaFlowAssetNav(C, Host);

        public SqlDacNav SqlDacNav(N Host)
            => new SqlDacNav(C, Host, SqlDacRoot(Host));

        public MetaFlowAssetNav DistNav(SystemNodeIdentifier id)
            => new MetaFlowAssetNav(C,  sqlnode(id));

        public PlatformNav PlatformNav(N Host)
            => new PlatformNav(C, Host);

        public SqlXEventLogNav XEventLogs(N Host)
            => new SqlXEventLogNav(C, Host);

        public static FolderName NodeFolderName(N Host)
            => FolderName.Parse(Host.NodeIdentifier.IdentifierText.ToLower());

        public FileName WindowedFileName<T>(DateRange Period, FileExtension Extension)
        {
            var window = $"{Period.Min.ToIsoString()}-{Period.Max.ToIsoString()}";
            var fileType = typeof(T).Name;
            return FileName.Parse(concat(window, fileType)) + Extension;
        }

        public FolderPath LogCollectionFolder(N SrcNode, N DstNode)
            => (OpsRoot(DstNode) + AppLogFolderName) + NodeFolderName(SrcNode);

        public NodeFolderPath ShellFolder(N n)
            => new NodeFolderPath(n, OpsRoot(n).AbsolutePath + FolderName.Parse("shells"));

    }
}
