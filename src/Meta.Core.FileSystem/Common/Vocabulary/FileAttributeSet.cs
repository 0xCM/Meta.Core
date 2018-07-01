//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using static metacore;

/// <summary>
/// Defines file attribute convenience accessors
/// </summary>
public class FileAttributeSet
{
    FileAttributes Attributes { get; }

    public FileAttributeSet(FileAttributes Attributes)
        => this.Attributes = Attributes;

    public bool Hidden
        => (Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;

    public bool ReadOnly
        => (Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;

    public bool Encrypted
        => (Attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted;

    public bool System
        => (Attributes & FileAttributes.System) == FileAttributes.System;

    public bool Device
        => (Attributes & FileAttributes.Device) == FileAttributes.Device;

    public bool Archive
        => (Attributes & FileAttributes.Archive) == FileAttributes.Archive;

    public bool Compressed
        => (Attributes & FileAttributes.Compressed) == FileAttributes.Compressed;

    public bool Directory
        => (Attributes & FileAttributes.Directory) == FileAttributes.Directory;

    public bool IntegrityStream
        => (Attributes & FileAttributes.IntegrityStream) == FileAttributes.IntegrityStream;

    public bool NoScrubData
        => (Attributes & FileAttributes.NoScrubData) == FileAttributes.NoScrubData;

    public bool NotContentIndexed
        => (Attributes & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed;

    public bool Offline
        => (Attributes & FileAttributes.Offline) == FileAttributes.Offline;

    public bool ReparsePoint
        => (Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint;

    public bool SparseFile
        => (Attributes & FileAttributes.SparseFile) == FileAttributes.SparseFile;

    public bool Temporary
            => (Attributes & FileAttributes.Temporary) == FileAttributes.Temporary;

}

