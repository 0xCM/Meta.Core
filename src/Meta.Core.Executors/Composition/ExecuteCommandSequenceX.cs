//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;


    [CommandPattern]
    class ExecuteCommandSequenceX : CommandExecutionService<ExecuteCommandSequenceX, ExecuteCommandSequence, int>
    {
        ICommandStore SpecStore
            => Service<ICommandStore>();

        IImmediateCommandExecutor Executor
            => Service<IImmediateCommandExecutor>();

        public ExecuteCommandSequenceX(IApplicationContext context)
            : base(context)
        { }

        protected override Option<int> TryExecute(ExecuteCommandSequence spec)
        {
            var results = new List<ICommandResult>();
            foreach (var name in spec.SpecNames)
            {
                var found = SpecStore.FindSpec(name);
                found.OnSome(x => results.Add(Executor.Execute(x)))
                     .OnNone(m => Notify(m));
            }
            return 0;
        }
    }

}