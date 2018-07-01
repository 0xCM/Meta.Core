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

    using static metacore;
    using N = SystemNode;



    public class FileRepository : NodeComponent, IFileRepository
    {
        public FileRepository
            (
                INodeContext C, 
                NodeFolderPath RootLocation, 
                IEnumerable<FileExtension> SupportedExtensions, 
                IEnumerable<FolderName> TopFolderNames
            )
            : base(C)
        {
            this.RootLocation = RootLocation;
            this.SupportedExtensions = rolist(SupportedExtensions);            
            SegmentProvider = 
                TopFolderNames.Any() 
                ?  new Func<IEnumerable<FolderName>>(() => TopFolderNames) 
                : () => RootLocation.Folders().Select(x => x.FolderName);

            this.Navigator = new FileRepositoryNavigator(C, this);           
        }

        Func<IEnumerable<FolderName>> SegmentProvider { get; }

        public FileRepositoryNavigator Navigator { get; }

        public NodeFolderPath RootLocation { get; }

        public IEnumerable<RepositoryFile> DepositedFiles
            => Navigator.Files.Select(f => new RepositoryFile(this, f.RelativeTo(RootLocation)));

        public IEnumerable<FileExtension> SupportedExtensions { get; }

        public IEnumerable<FolderName> TopFolderNames
            => SegmentProvider();

        public Option<RepositoryFile> Deposit(FilePath SrcFile)
            => new RepositoryFile(this, SrcFile.RelativeTo(RootLocation));

        public Option<NodeFilePath> Resolve(RepositoryFile DepositedFile)
            => new NodeFilePath(Host, RootLocation.AbsolutePath.GetCombinedFilePath(DepositedFile.Location));
        
    }


}