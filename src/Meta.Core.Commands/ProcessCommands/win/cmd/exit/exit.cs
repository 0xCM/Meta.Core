//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;

    using c = commands_spec.exit;
    using r = commands_spec.exit_response;
    using m = ProcessMessage;

    using Messaging;

    partial class commands_exec
    {
        public static c exit(this IProcess broker)
            => broker.Submit<c>();
    }

    partial class commands_spec
    {
        public sealed class exit : ProcessCommand<c, r>
        {
            public exit()
            {

            }

            internal exit(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);

        }

        public class exit_response : ProcessComandResponse<r, c>
        {
            internal exit_response(c command, m content)
                : base(command, content)
            { }
        }

    }
}