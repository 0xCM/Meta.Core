//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a folder int the context of a <see cref="IFileRepository"/>
    /// </summary>   
    public class RepositoryFolder : IFolderPath
    {
        public RepositoryFolder(IFileRepository Repository, RelativePath Location)
        {
            this.Repository = Repository;
            this.Location = Location;
        }

        /// <summary>
        /// The relative location of the folder
        /// </summary>
        public RelativePath Location { get; }

        /// <summary>
        /// The repository to which the folder belongs
        /// </summary>
        public IFileRepository Repository { get; }

        string IFileSystemObject.FileSystemPath
            => Repository.RootLocation.AbsolutePath.FileSystemPath;

        public bool Exists()
            => Repository.RootLocation.AbsolutePath.GetCombinedFolderPath(Location).Exists();


    }

}