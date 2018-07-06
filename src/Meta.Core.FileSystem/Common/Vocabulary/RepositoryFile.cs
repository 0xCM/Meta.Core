//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using N = SystemNode;
   
    /// <summary>
    /// Describes a file at rest in a <see cref="IFileRepository"/>
    /// </summary>
    public class RepositoryFile : IFilePath
    {
        public RepositoryFile(IFileRepository Repository, RelativePath Location)
        {
            this.Repository = Repository;
            this.Location = Location;
        }

        /// <summary>
        /// Specifies the relative location of the file
        /// </summary>
        public RelativePath Location { get; }

        /// <summary>
        /// Specifies the full/absolute path to the file
        /// </summary>
        public FilePath AbsolutePath
            => Repository.Resolve(this).MapRequired(x => x.AbsolutePath);

        /// <summary>
        /// Specifies the repository that owns the file
        /// </summary>
        IFileRepository Repository { get; }

        /// <summary>
        /// Specififies the filename, based on the last relative component
        /// </summary>
        public FileName FileName
            => Location.Components.Count != 0 
            ? FileName.Parse(Location.Components.Last()) 
            : FileName.Empty;

        IFolderPath IFilePath.Folder
            => Repository.Resolve(this).MapValueOrDefault(x => x.Folder.AbsolutePath);

        public RelativePath ObjectName
            => Location;

        string IFileSystemObject.FileSystemPath
            => AbsolutePath.ToString();

        public bool Exists()
            => Repository.Resolve(this).Exists;


        public override string ToString()
            => Location;
    }
}