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
    class SetEnvX : CommandExecutionService<SetEnvX, SetEnvironmentVariables, int>
    {


        public SetEnvX(IApplicationContext context)
            : base(context)
        {

        }

        static IApplicationMessage VariableSpecified(NamedValue value)
            => ApplicationMessage.Inform("The environment variable @Name was given the value @Value",
                new
                {
                    value.Name,
                    value.Value
                });

        protected override Option<int> TryExecute(SetEnvironmentVariables spec)
        {
            foreach (var variable in spec.Variables)
            {
                Environment.SetEnvironmentVariable(variable.Name, toString(variable.Value), EnvironmentVariableTarget.User);
                Context.PostMessage(VariableSpecified(variable));
            }
            return 0;
        }
    }
}
