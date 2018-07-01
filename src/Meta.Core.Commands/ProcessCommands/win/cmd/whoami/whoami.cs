//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using Messaging;

    using c = commands_spec.whoami;
    using r = commands_spec.whoami_response;
    using m = ProcessMessage;

    partial class commands_exec
    {
        public static c whoami(this IProcess broker)
            => broker.Submit<c>();


    }

    partial class commands_spec
    {
        public sealed class whoami : ProcessCommand<c, r>
        {
            public whoami()
            { }

            internal whoami(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);

        }

        public class whoami_response : ProcessComandResponse<r, c>
        {
            internal whoami_response(c command, m content)
                : base(command, content)
            { }
        }

    }
}