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
/// Describes the result of a file write operation
/// </summary>
public sealed class FileWriteResult : FileOperationResult<FileWriteResult, FilePath>
{
    public static FileWriteResult Success(FilePath DstPath, IApplicationMessage Message = null)
        => new FileWriteResult(DstPath, Message ?? inform($"The {DstPath} file was successfully written"));

    public static FileWriteResult Failure(FilePath DstPath, Exception error)
        => new FileWriteResult(DstPath, ApplicationMessage.Error(error));

    public static FileWriteResult Failure(FilePath DstPath, IApplicationMessage Message)
        => new FileWriteResult(DstPath, Message);

    public FileWriteResult(FilePath DstPath, IApplicationMessage Message)
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
