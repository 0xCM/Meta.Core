//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;


public abstract class CommandBuilder : ApplicationComponent, ICommandBuilder
{
    protected CommandBuilder(IApplicationContext C, CommandSpecDescriptor descriptor)
        : base(C)
    {
        TargetCommandName = descriptor.CommandName;
    }

    public CommandName TargetCommandName { get; }
}

public abstract class CommandBuilder<TSpec> : CommandBuilder, ITargetedCommandEmitter
    where TSpec : CommandSpec<TSpec>, new()
{
    protected CommandBuilder(IApplicationContext C)
        : base(C, CommandSpec<TSpec>.Descriptor)
    {

    }

    public abstract IEnumerable<ConstructedCommand<TSpec>> BuildCommands(
        RelativePath OutputLocation,
        params (string ParamName, object ParamValue)[] parms);

    IEnumerable<IEmittedCommand> ITargetedCommandEmitter.BuildCommands(
        RelativePath OutputLocation, params (string ParamName, object ParamValue)[] parms)
        => BuildCommands(OutputLocation, parms);
}

public abstract class CommandBuilder<TSpec, TPayload> : CommandBuilder<TSpec>, ICommandBuilder<TSpec, TPayload>
    where TSpec : CommandSpec<TSpec, TPayload>, new()
{

    protected CommandBuilder(IApplicationContext C)
        : base(C)
    {

    }
}
