//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

using static metacore;

/// <summary>
/// Describes the outcome of a file copy operation
/// </summary>
public sealed class FileCopyResult : FileOperationResult<FileCopyResult, FilePath>
{
    public FileCopyResult(FilePath SrcPath, FilePath DstPath, bool Replaced)
        : base(inform($"The file located at @SrcPath was copied to @DstPath ", 
            new {
            SrcPath,
            DstPath
        }))
    {
        this.SrcPath = SrcPath;
        this.DstPath = DstPath;
        this.Replaced = Replaced;
    }

    public FileCopyResult(FilePath SrcPath, FilePath DstPath, string ErrorMessage)
        : base(AppMessage.Error(ErrorMessage))
    {
        this.SrcPath = SrcPath;
        this.DstPath = DstPath;
        this.Replaced = false;
    }

    /// <summary>
    /// Specifies the path to the source file
    /// </summary>
    public FilePath SrcPath { get; }

    /// <summary>
    /// Specifies the path to the target file
    /// </summary>
    public FilePath DstPath { get; }

    /// <summary>
    /// Indicates whether an existing file was replaced by the copy operation
    /// </summary>
    public bool Replaced { get; }
}