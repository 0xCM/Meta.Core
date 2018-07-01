//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Meta.Core;

using static metacore;

public sealed class FilePath : FilePath<FilePath>
{     
    public static readonly FilePath None = Empty;
     
    public static implicit operator string(FilePath x)
        => x.FileSystemPath;

    public static FilePath operator +(FilePath x, FileExtension y)
        => $"{x}.{y.Value}";

    public static implicit operator FilePath(string x)
        => Parse(x);

    public static implicit operator Uri(FilePath x)
        => new Uri($"file:///{x.ToString().Replace('\\', '/')}");

    public FilePath()
    { }

    public FilePath(string Value)
        : base(Normalize(Value))
    {

    }

    protected override Func<string, FilePath> Reconstructor
        => text => new FilePath(text);
    
    public FilePath AddExtension(FileExtension ext, bool onlyIfMissing = false)
        => Folder + FileName.AddExtension(ext, onlyIfMissing);

    public FilePath RemoveExtension()
        => Path.GetFileNameWithoutExtension(this);

    public Uri AsUri()
        => this;

    /// <summary>
    /// Tests whether a file has a specific extension
    /// </summary>
    /// <param name="x">The extension to match</param>
    /// <returns></returns>
    public bool HasExtension(FileExtension x)
        => Extension == x;

    public override string ToString()
        => FileSystemPath;  
}



