//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

/// <summary>
/// Identifies a file system entity
/// </summary>
public struct FileSystemIdentifier : IEquatable<FileSystemIdentifier>
{
    public static implicit operator FileSystemIdentifier(string x)
        => new FileSystemIdentifier(x);

    public FileSystemIdentifier(string Value)
    {
        this.Value = ifBlank(Value, string.Empty);
    }

    public string Value { get; }

    public override string ToString()
        => Value;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

    public override bool Equals(object obj)
       => obj is FileSystemIdentifier ? Equals((FileSystemIdentifier)obj) : false;

    public bool Equals(FileSystemIdentifier other)
        => Value.ToLower().Equals(other.Value.ToLower());
}
