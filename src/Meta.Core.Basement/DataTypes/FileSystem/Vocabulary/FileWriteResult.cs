//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

/// <summary>
/// Describes the result of a file write operation
/// </summary>
public sealed class FileWriteResult : FileOperationResult<FileWriteResult, FilePath>
{
    public static FileWriteResult Success(FilePath DstPath, IAppMessage Message = null)
        => new FileWriteResult(DstPath, Message ?? AppMessage.Inform($"The {DstPath} file was successfully written"));

    public static FileWriteResult Failure(FilePath DstPath, Exception error)
        => new FileWriteResult(DstPath, AppMessage.Error(error));

    public static FileWriteResult Failure(FilePath DstPath, IAppMessage Message)
        => new FileWriteResult(DstPath, Message);

    public FileWriteResult(FilePath DstPath, IAppMessage Message)
        : base(Message, DstPath)
    {
        this.DstPath = DstPath;
    }

    public FilePath DstPath { get; }

    public void Require()
    {
        if (not(Succeeded))
            throw new Exception(Message.Format());
    }
}
