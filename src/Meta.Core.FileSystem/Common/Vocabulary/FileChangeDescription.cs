//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using Meta.Core;

using static metacore;

/// <summary>
/// Describes a change to a file
/// </summary>
public class FileChangeDescription
{
    public FileChangeDescription(FilePath File, CorrelationToken Correlation, FileChangeKind ChangeType)
    {
        this.File = File;
        this.Correlation = Correlation;
        this.ChangeType = ChangeType;        
    }

    /// <summary>
    /// The file that has changed
    /// </summary>
    public FilePath File { get; }

    /// <summary>
    /// An assoicated correlation token
    /// </summary>
    public CorrelationToken Correlation { get; }
     
    /// <summary>
    /// The type of change that occurred
    /// </summary>
    public FileChangeKind ChangeType { get; }

    /// <summary>
    /// The type of change represented symbolically
    /// </summary>
    public string ChangeSymbol
        => ChangeType.ToSymbol();

    /// <summary>
    /// Indicates whether the file was created
    /// </summary>
    public bool Added
        => ChangeType == FileChangeKind.Added;

    /// <summary>
    /// Indicates whether the file was deleted
    /// </summary>
    public bool Removed
        => ChangeType == FileChangeKind.Removed;

    /// <summary>
    /// Indicates whether the file was updated
    /// </summary>
    public bool Modified
        => ChangeType == FileChangeKind.Modifed;

    public override string ToString()
        => concat(ChangeSymbol, space(), File.FileName);
}
