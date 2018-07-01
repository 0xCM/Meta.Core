//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;

    using Meta.Core.Messaging;

    using c = commands_spec.choco;
    using r = commands_spec.choco_response;
    using m = ProcessMessage;

    partial class commands_exec
    {
        public static c choco(this IProcess broker)
            => broker.Submit<c>(new c("-?"));

    }

    partial class commands_spec
    {
        public sealed class choco : ProcessCommand<c, r>
        {

            public sealed class list : ProcessSubCommand<list, c, r.list>
            {
                public list()
                {

                }


                internal list(c controller, m content)
                    : base(controller, content)
                { }


                public override r.list error(m content)
                    => new r.list(this, content);

                public override r.list ok(m content)
                    => new r.list(this, content);

            }

            public choco()
            {

            }

            public choco(params string[] args)
                : base(new m(typeof(c).Name, string.Join(" ", args), ProcessMessageType.Command))
            {

            }


            internal choco(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);


        }

        public class choco_response : ProcessComandResponse<r, c>
        {

            public sealed class list : ProcessComandResponse<list, c.list>
            {
                internal list(c.list command, m content)
                    : base(command, content)
                    { }

            }

            internal choco_response(c command, m content)
                : base(command, content)
            { }
        }


    }

}