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

    using c = commands_spec.call;
    using r = commands_spec.call_response;
    using m = ProcessMessage;

    partial class commands_exec
    {
        public static c call(this IProcess broker, c command)
            => broker.Submit(command);

        public static c call(this IProcess broker, params string[] args)
            => broker.Submit<c>(args);

        public static c call(this IProcessBroker broker, FilePath batch_file)
            => broker.Submit<c>(batch_file);

        public static c help(this c command)
            => command.SubmittingProcess.call("/?");
    }

    partial class commands_spec
    {

        [Description(prototype)]
        public sealed class call : ProcessCommand<c, r>
        {
            public const string prototype = "call <batch_file> [batch_args]";

            public static readonly PromptInputSyntax syntax
                = DefineSyntax()
                 .with_positional_parameters("batch_file", "batch_args");

            public call()
            { }

            internal call(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);            

            [InputArg(0)]
            public FilePath batch_file { get; set; }

            [InputArg(1)]
            public string batch_args { get; set; }
        }

        public class call_response : ProcessComandResponse<r, c>
        {
            internal call_response(c command, m content)
                : base(command, content)
            { }
        }
    }
}