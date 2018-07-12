//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Services;

    using MetaFlow.Core;

    using Sql = SqlT.Store;
    using N = SystemNode;

    public sealed class SqlFileOps : SysOpComponent<SqlFileOps>
    {
        public SqlFileOps(ILinkedSqlContext C)
            : base(new LinkedContext(C.SourceContext, C.TargetContext))
        {
          
        }
       
        SqlConnectionString PlatformConnector(N Host)
            => C.SqlConnector(Host, PlatformDatabaseKind.MetaFlow).Require();

        ISqlProxyBroker PlatformBroker(N Host)
            => MetaFlowCoreStorage.Broker(PlatformConnector(Host));

        ISqlProxyBroker SourceBroker
            => PlatformBroker(SourceNode);

        ISqlProxyBroker TargetBroker
            => PlatformBroker(TargetNode);

        public IEnumerable<FolderPath> SourceDrives
            => Drives(SourceNode);

        public IEnumerable<FolderPath> TargetDrives
            => Drives(TargetNode);

        public IEnumerable<FolderPath> Drives(N Host)
            => from item in PlatformBroker(Host).Get(new Sql.Drives()).OnNone(m => C.Notify(m)).Items()
               select FolderPath.Parse(item.DrivePath);

        public Option<int> CopySourceFile(FilePath SrcPath, FilePath DstPath)
            => SourceBroker.Call(new Sql.CopyFile(SrcPath, DstPath));

        public IEnumerable<FilePath> HostFiles(N Host, FolderPath Path)
            => from item in PlatformBroker(Host).Get(new Sql.Dir(Path, null)).OnNone(m => C.Notify(m)).Items()
               where item.IsDirectory == false
               select FilePath.Parse(item.FilePath);

        public IEnumerable<FilePath> SourceFiles(FolderPath Path)
            => HostFiles(SourceNode, Path);

        public IEnumerable<FilePath> TargetFiles(FolderPath Path)
            => from item in TargetBroker.Get( new Sql.Dir(Path, null)).OnNone(m => C.Notify(m)).Items()
               where item.IsDirectory == false
               select FilePath.Parse(item.FilePath);

        public IReadOnlyList<Sql.DirResult> Dir(N Host, FolderPath Path, string match = null)
            => PlatformBroker(Host).Get(new Sql.Dir(Path, match)).OnNone(m => C.Notify(m)).Items();

        public IReadOnlyList<Sql.DirResult> LocalSourceDir(FolderPath Path)
            => Dir(SourceNode, Path);

        public IReadOnlyList<Sql.DirResult> LocalTargetDir(FolderPath Path)
            => Dir(TargetNode, Path);

        public Option<int> CopyFile(FilePath SrcFile, FilePath DstPath)
            => SourceBroker.Call(new Sql.CopyFile(SrcFile, DstPath));

        public Option<int> CopyFolder(FolderPath SrcPath, FolderPath DstPath)
            => SourceBroker.Call(new Sql.CopyFolder(SrcPath, DstPath));
    }
}