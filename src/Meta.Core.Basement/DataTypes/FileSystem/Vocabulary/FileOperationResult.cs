//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static minicore;

/// <summary>
/// Together with concrete subtypes, describes the outcome of a file system operation
/// </summary>
/// <typeparam name="R">The derived subtype</typeparam>
/// <typeparam name="F">The object type</typeparam>
public abstract class FileOperationResult<R,F> 
    where R : FileOperationResult<R,F>
    where F : IFileSystemObject
{
    public static bool operator true(FileOperationResult<R,F> result)
        => result.Succeeded;

    public static bool operator false(FileOperationResult<R,F> result)
        => not(result.Succeeded);

    protected FileOperationResult(IAppMessage Message, F FileSystemObject = default(F))
    {
        this.Message = Message ?? AppMessage.Empty;
        this.FileSystemObject = FileSystemObject;
    }

    public IAppMessage Message { get; }

    public bool Succeeded
        => not(Message.IsError());

    public override string ToString()
        => Message.Format();

    public F FileSystemObject { get; }

    public Option<R> ToOption()
        => Succeeded? some((R)this, Message) : none<R>(Message);

    public Option<F> ToFileOption()
        => Succeeded ? some(FileSystemObject).WithMessage(Message) 
                : none<F>(Message);

}


