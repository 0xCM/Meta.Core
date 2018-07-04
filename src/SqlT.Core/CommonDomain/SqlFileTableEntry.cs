//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;


    /// <summary>
    /// Represents an entry in a SQL Server file table
    /// </summary>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/sql/relational-databases/blob/filetable-schema
    /// </remarks>
    public class SqlFileTableEntry
    {
        //SqlHierarchyId
        public object PathLocator { get; set; }

        //SqlHierarchyId
        public object ParentPathLocator { get; set; }

        public Guid StreamId { get; set; }

        public byte[] FileData { get; set; }

        public string FileType { get; set; }

        public string FileName { get; set; }
        public long CachedFileSize { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastWriteTime { get; set; }

        public DateTime LastAccessTime { get; set; }

        public bool IsDirectory { get; set; }

        public bool IsOffline { get; set; }

        public bool IsHidden { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsArchive { get; set; }

        public bool IsSystem { get; set; }

        public bool IsTemporary { get; set; }

    }
}
