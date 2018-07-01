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

    using N = SystemNode;

    public sealed class FileRepositoryNavigator   : FileSystemNavigator<FileRepositoryNavigator>
    {
        public FileRepositoryNavigator(INodeContext C, IFileRepository Repository)
            : base(C)
        {
            this.Repository = Repository;
        }

        public IFileRepository Repository { get; }

        public override NodeFolderPath NavRoot
            => Repository.RootLocation;

        public override IEnumerable<FileExtension> SupportedExtensions
            => Repository.SupportedExtensions;

        public override IEnumerable<FolderName> SegmentNames
            => Repository.TopFolderNames;

        public override bool Recursive
            => true;
        
    }


}