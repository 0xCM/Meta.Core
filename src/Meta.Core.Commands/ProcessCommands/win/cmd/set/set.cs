//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.ComponentModel;
    using Meta.Core.Messaging;
    using static metacore;

    using c = commands_spec.set;
    using r = commands_spec.set_response;
    using m = ProcessMessage;

    partial class commands_exec
    {
        public static c set(this IProcess broker, c command)
            => broker.Submit(command);

        public static c set(this IProcess broker, params string[] args)
            => broker.Submit<c>(args);

        public static c set(this IProcessBroker broker, FilePath batch_file)
            => broker.Submit<c>(batch_file);

        public static c help(this c command)
            => command.SubmittingProcess.set("/?");
    }


    partial class commands_spec
    {

        [Description(prototype)]
        public sealed class set : ProcessCommand<c, r>
        {
            public const string prototype = "set <var_name> <var_value>";

            public static readonly PromptInputSyntax syntax
                = DefineSyntax()
                 .with_positional_parameters("var_name", "var_value");


            public set()
            { }


            internal set(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);
            

            [InputArg(0)]
            public string var_name { get; set; }

            [InputArg(1)]
            public string var_value { get; set; }


        }

        public class set_response : ProcessComandResponse<r, c>
        {
            internal set_response(c command, m content)
                : base(command, content)
            { }
        }


    }

}