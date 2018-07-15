//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using C = WorkflowCommandSpec;
    using X = WorkflowCommandExec;
    using R = WorkflowCommandResult;

    [CommandPattern]
    public class WorkflowCommandExec : CommandExecutionService<X, C, R>
    {
        ICommandStore SpecStore
            => Service<ICommandStore>();

        IImmediateCommandExecutor Executor
            => Service<IImmediateCommandExecutor>();

        public WorkflowCommandExec(IApplicationContext context)
            : base(context)
        { }

        protected override Option<R> TryExecute(C command)
        {
            foreach (var step in command.Steps)
            {
                var result = from spec in SpecStore.FindSpec(step.SpecName)
                             from exec in some(Executor.Execute(spec))
                             select exec;
                if (!result)
                    return result.ToNone<R>();
                else
                {
                    var cmdResult = result.ValueOrDefault();
                    if (!cmdResult.Succeeded)
                        return none<R>(cmdResult.Message);
                }
            }
            return new R();
        }


    }

}