//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    

    using static metacore;
    using N = SystemNode;
    using F = FolderName;
    using R = NodeUncRoot;
    using L = NodeDriveLetter;
    using P = FilePath;
    using D = NodeUncDrive;
    using FP = FolderPath;
    
    public class NodeFileSystemLocator : ApplicationComponent, INodeFileSystemLocator
    {

        public static INodeFileSystemLocator Create(IApplicationContext C, IEnumerable<NodeUncInfo> srcNodes)
            => new NodeFileSystemLocator(C, srcNodes);

        IReadOnlyList<L> NodeDriveLetters { get; }
        IReadOnlyList<R> UncRoots { get; }
        IReadOnlyList<NodeUncInfo> Nodes { get; }
        DriveLetter _UncDriveLetter(N n)
            => Nodes.Single(d => d.Node.Equals(n)).DriveLetter;

        UncRoot _GetUncRoot(N n)
            => Nodes.Where(d => d.Node.Equals(n)).Single().UncRoot;

        D _UncShare(N n, RelativePath path)
            => new D(new D(n, _GetUncRoot(n), _UncDriveLetter(n)), path);

        IReadOnlyList<INodeCatalogSubject> CatalogSubjects { get; }

        IResourceCatalog Catalog { get; }

        NodeFileSystemLocator(IApplicationContext C, IEnumerable<NodeUncInfo> srcNodes)
            : base(C)
        {

            NodeDriveLetters = srcNodes.Select(x => x.DriveLetter).ToList();
            UncRoots = srcNodes.Select(x => x.UncRoot).ToList();
            Nodes = srcNodes.ToList();
            Catalog = C.SubjectCatalog();
            CatalogSubjects = new List<INodeCatalogSubject>();
        }



        DriveLetter GetNodeDriveLetter(N n)
            => NodeDriveLetters.Single(d => d.Node.Equals(n)).DriveLetter;

        UncRoot GetUncRoot(N n)
            => UncRoots.Single(r => r.Node.Equals(n));

        public D TopUncShare(N n, F Folder)
            => UncShare(n, Folder);

        public D Subfolder<S>(D d)
            where S : CatalogSubject<S>
            => _UncShare(d.Node, d.Share + RelativePath.Parse(Catalog.Subject<S>().Urn.EverythingButScheme));

        public D UncShare(N n)
            => new D(n, GetUncRoot(n), GetNodeDriveLetter(n));

        public D UncShare(N n, CatalogSubject subject)
            => new D(new D(n, GetUncRoot(n), GetNodeDriveLetter(n)), subject.RelativeLocation);

        public D UncFolder<S>(N node)
            where S : CatalogSubject<S>
                => _UncShare(node, RelativePath.Parse(Catalog.Subject<S>().Urn.EverythingButScheme));

        public P UncFilePath<S>(N node, FileName filename)
            where S : CatalogSubject<S>
                => _UncShare(node, RelativePath.Parse(Catalog.Subject<S>().Urn.EverythingButScheme)) + filename;

        public D UncShare(N n, RelativePath path)
                    => new D(new D(n, GetUncRoot(n), GetNodeDriveLetter(n)), path);

        public Option<P> UncFilePath(N n, SystemResourceUrn urn)
           => from parentUrn in urn.ParentName
              from subject in  Catalog.TryFindSubject(parentUrn)
              let filename = FileName.Parse(urn.NonSchemeComponents.Last())
              select UncShare(n, subject).Share.SharePath + filename;

        public FP Folder<S>()
            where S : CatalogSubject<S>
            => FP.Parse(Catalog.Subject<S>().RelativeLocation);

        public FP Folder<S>(FP folder)
            where S : CatalogSubject<S>
            => Folder<S>() + folder;

        public P File<S>(FileName filename)
            where S : CatalogSubject<S>
            => Folder<S>() + filename;

        public FP AbsoluteLocation(N node, RelativePath relative)
                    => UncShare(node, relative).Share.SharePath;

    }
}