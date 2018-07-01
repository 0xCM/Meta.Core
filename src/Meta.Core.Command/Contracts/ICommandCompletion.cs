//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface ICommandCompletion : ICommandDispatch
{
    DateTime CompleteTime { get; }

    bool Succeeded { get; }

    string CompleteMessage { get; }

    ICommandResult Result { get; }

}

public interface ICommandCompletion<TSpec> : ICommandDispatch<TSpec>, ICommandCompletion
    where TSpec : CommandSpec<TSpec>, new()
{
    new ICommandResult<TSpec> Result { get; }
}


public interface ICommandCompletion<TSpec, TPayload> : ICommandCompletion<TSpec>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{
    new ICommandResult<TSpec, TPayload> Result { get; }
}
