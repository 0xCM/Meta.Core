//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Meta.Core;
    using static metacore;

    using N = SystemNodeIdentifier;

    using static StatusMessages;

    using DistId = DistributionIdentifier;

    class PlatformDistributor : PlatformService<PlatformDistributor, IPlatformDistributor>, IPlatformDistributor
    {
        public PlatformDistributor(INodeContext C)
            : base(C)
        {

        }

        protected T Step<T>(Func<T> F, IAppMessage Before)
        {
            Notify(Before);
            return F();
        }

        protected MetaFlowAssetNav SourceNav
            => NFS.AssetNav(C.Host);


        protected PlatformNav SourcePlatform
            => NFS.PlatformNav(C.Host);

        protected PlatformNav TargetPlatform(SystemNode TargetNode)
            => NFS.PlatformNav(TargetNode);
        

        FileName DistributionArchiveName(DistId DistId)
            => FileName.Parse(DistId).AddExtension("zip");

        FileName DistributionArchiveName(DistId DistId, Version Version)
            => FileName.Parse($"{DistId}.{Version.Major}.{Version.Minor}.{Version.Build}.{Version.Revision}").AddExtension("zip");


        public Option<NodeFilePath> CompressTo(DistId DistId, SystemNode DstNode)
            => from srcFolder in some(SourceNav.DistFolder(DistId))
               let exePath = srcFolder + FileName.Parse("pf.exe")
               from version in ReadAssemblyVersion(exePath)
               let targetFileName = DistributionArchiveName(DistId, version)
               let targetNav = NFS.OpsNav(DstNode)
               let targetFolder = targetNav.AssetNav.DistArchiveFolder
               let targetPath = targetFolder + targetFileName
               from archive in Step(() => ArchiveManager.CreateArchive(srcFolder, targetPath), CreatingArchive(DistId, targetPath))
               select archive.Target;

        public Option<NodeFilePath> ReleaseTo(DistId DistId, SystemNode DstNode)
            => from dist in Latest(DistId)
               from dstPath in ReleaseTo(DistId, dist, DstNode)
               select dstPath;
             
        public Option<NodeFilePath> ReleaseTo(DistId DistId, NodeFilePath SrcPath, SystemNode DstNode)
            => from dist in some(SrcPath)
               let targetNav = NFS.OpsNav(DstNode)
               let targetFolder = targetNav.AssetNav.DistArchiveFolder
               let targetPath = targetFolder + dist.FileName
               from copy in Step(() => dist.CopyTo(targetPath), ReleasingDistribution(DistId, targetPath))
               select copy.Target;

        Option<Version> ReadAssemblyVersion(FilePath AssemblyPath)
        {
            try
            {              
                return AssemblyName.GetAssemblyName(AssemblyPath).Version;
            }
            catch(Exception e)
            {
                return none<Version>(e);
            }
        }

        public Option<NodeFilePath> CreateDistribution(DistId DistId)
            => from srcFolder in some(SourceNav.DistFolder(DistId))
               let exePath = srcFolder + FileName.Parse("pf.exe")
               from version in ReadAssemblyVersion(exePath)
               let archivePath = SourceNav.DistArchiveFolder + DistributionArchiveName(DistId, version)
               from archive in Step(() => ArchiveManager.CreateArchive(srcFolder, archivePath), CreatingArchive(DistId, archivePath))
               select archive.Target;

        Option<NodeFilePath> Latest(DistId DistId)
            => from srcArchive in ArchivedDistributions(DistId).TryGetFirst()
               select srcArchive;

        public IEnumerable<NodeFilePath> ArchivedDistributions(DistId DistId)
            => NFS.AssetNav(Host).DistArchives(DistId);
    }
}