//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using c = commands_spec.exec;
    using r = commands_spec.exec_response;
    using m = ProcessMessage;

    partial class commands_exec
    {

        public static c exec(this IProcess broker, string commandText)
            => broker.Submit<c>(commandText);

        public static c help(this c command)
            => command.SubmittingProcess.exec("echo Executes a literal command");           
    }

    partial class commands_spec
    {        
        
        public sealed class exec : ProcessCommand<c, r>
        {         
            public exec()
            { }

            internal exec(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);
        }

        public class exec_response : ProcessComandResponse<r, c>
        {
            internal exec_response(c command, m content)
                : base(command, content)
            { }
        }

    }
}