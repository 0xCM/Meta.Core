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
/// Specifies a <see cref="DataFile"/> classification
/// </summary>
public struct DataFileType : IEquatable<DataFileType>
{
    public static implicit operator DataFileType(string x)
        => new DataFileType(x);

    public static implicit operator FolderName(DataFileType x)
        => new FolderName(x.Value);


    public DataFileType(string Value)
    {
        this.Value = ifBlank(Value, string.Empty);
    }

    public string Value { get; }

    public override string ToString()
        => Value;

    public override int GetHashCode()
        => Value.ToLower().GetHashCode();

    public override bool Equals(object obj)
       => obj is DataFileType ? Equals((DataFileType)obj) : false;

    public bool Equals(DataFileType other)
        => Value.ToLower().Equals(other.Value.ToLower());
}
