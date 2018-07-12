//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using static metacore;


/// <summary>
/// Ultimate base class for services that execute CPS commands
/// </summary>
/// <typeparam name="I"></typeparam>
/// <typeparam name="TSpec"></typeparam>
/// <typeparam name="TPayload"></typeparam>
public abstract class CommandExecutionService<I, TSpec, TPayload> 
    : ApplicationService<I, ICommandExecutionService<TSpec, TPayload>>, ICommandExecutionService<TSpec, TPayload>
        where I : CommandExecutionService<I, TSpec, TPayload>
        where TSpec : CommandSpec<TSpec, TPayload>, new()
{

    static CommandSpecDescriptor CommandDescriptor { get; }
        = CommandSpecDescriptor.FromSpecType<TSpec>();


    ICommandQueue<TSpec> Queue { get; }

    ICommandExecutor<TSpec,TPayload> Executor { get; }


    protected CommandExecutionService(IApplicationContext C)
        : base(C)
    {
        this.Queue = new CommandQueue<TSpec>(C);
        this.Executor = new CommandExecutor<TSpec,TPayload>(C, this);
    }

    protected static Option<TPayload> CommandError<C>
        (TSpec spec, 
        string template, 
        C content,
        [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null)
            => none<TPayload>(AppMessage.Error(template, content, callerFile, callerName));

    protected static Option<TPayload> CommandError(IAppMessage message)
        => none<TPayload>(message);

    protected abstract Option<TPayload> TryExecute(TSpec command);

    protected virtual Option<TPayload> TryExecute(TSpec command, CommandExecutionContext ec)
        => TryExecute(command);


    protected virtual Option<TPayload> TryExecute(CommandDispatch<TSpec> submission)
        => TryExecute(submission.Spec);

    IOption ICommandExecutionService.TryExecute(ICommandSpec spec)
        => TryExecute((TSpec)spec);

    IOption ICommandExecutionService.TryExecute(ICommandSpec spec, CommandExecutionContext ec)
        => TryExecute((TSpec)spec,ec);

    Option<object> ICommandExecutionService<TSpec>.TryExecute(TSpec spec)
        => TryExecute(spec);

    Option<object> ICommandExecutionService<TSpec>.TryExecute(TSpec spec, CommandExecutionContext ec)
        => TryExecute(spec, ec);

    Option<TPayload> ICommandExecutionService<TSpec,TPayload>.TryExecute(TSpec spec)
        => TryExecute(spec);

    Option<TPayload> ICommandExecutionService<TSpec, TPayload>.TryExecute(TSpec spec, CommandExecutionContext ec)
        => TryExecute(spec, ec);

    Option<TPayload> ICommandExecutionService<TSpec, TPayload>.TryExecute(CommandDispatch<TSpec> spec)
        => TryExecute(spec);

    Option<object> ICommandExecutionService<TSpec>.TryExecute(CommandDispatch<TSpec> spec)
        => TryExecute(spec);

    CommandName ICommandExecutionService.CommandName
        => CommandDescriptor.CommandName;

    ICommandQueue<TSpec> ICommandExecutionService<TSpec>.Queue
        => Queue;

    CommandFactory<TSpec> ICommandExecutionService<TSpec>.Factory
    {
        get
        {
            var factories = Context.TryGetService<ICommandFactoryProvider>();
            if (factories)
            {
                var factory = factories.Require().Factory<TSpec, TPayload>();

                if (factory)
                {
                    return ctx => factory.Require()(ctx);
                }
            }
            return ctx => new TSpec[] { };
        }
    }


    ICommandQueue ICommandExecutionService.Queue
        => Queue;


    ICommandExecutor ICommandExecutionService.Executor
        => Executor;

    ICommandExecutor<TSpec> ICommandExecutionService<TSpec>.Executor
        => Executor;

    ICommandExecutor<TSpec, TPayload> ICommandExecutionService<TSpec, TPayload>.Executor
        => Executor;

    public Type SpecType
        => typeof(TSpec);

    public Type PayloadType
        => typeof(TPayload);

    public CommandName CommandName
        => CommandDescriptor.CommandName;


}


