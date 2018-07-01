//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static metacore;

public class FileDescription : IEquatable<FileDescription>
{
    public FileDescription(FilePath Path)
    {
        this.Path = Path;
        this.FileSize = Path.FileSize ?? 0;
        this.ModifiedTime = Path.ModifiedTime ?? now();
    }

    public FileDescription(FilePath Path, DateTime ModifiedTime, long FileSize)
    {
        this.Path = Path;
        this.ModifiedTime = ModifiedTime;
        this.FileSize = FileSize;
    }

    public FilePath Path { get; }

    public DateTime ModifiedTime { get; private set; }

    public long FileSize { get; private set; }

    public bool Equals(FileDescription other)
        => Path == other.Path
        && ModifiedTime == other.ModifiedTime
        && FileSize == other.FileSize;

    public bool Exists()
        => Path.Exists();

    public bool? HasChanged()
    {
        var newSize = Path.FileSize;
        if (newSize == null)
            return null;

        var newTS = Path.ModifiedTime;
        if (newTS == null)
            return null;

        if (newSize != FileSize || newTS != Path.ModifiedTime)
        {
            FileSize = newSize.Value;
            ModifiedTime = newTS.Value;
            return true;
        }

        return false;
    }

    public override string ToString()
        => $"{Path} {ModifiedTime.ToLexicalString()} {FileSize}";

    public override int GetHashCode()
        => Path.GetHashCode();
}

