//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.ComponentModel;    

    using c = commands_spec.mklink;
    using r = commands_spec.mklink_response;
    using m = ProcessMessage;

    partial class commands_exec
    {
        public static c mklink(this IProcess broker, c parameters = default(c))
            => broker.Submit<c>(parameters);

    }

    partial class commands_spec
    {

        /// <summary>
        /// Creates a symbolic link
        /// </summary>
        /// <remarks>
        /// See https://technet.microsoft.com/en-us/library/cc753194(v=ws.11).aspx
        /// </remarks>
        [Description(prototype)]
        public sealed class mklink : ProcessCommand<c, r>
        {
            public const string prototype = "mklink [[/d] | [/h] | [/j]] <Link> <Target>";

            public static readonly PromptInputSyntax syntax
                = DefineSyntax().with_flags("d", "h", "J")
                 .with_positional_parameters("Link", "Target");


            public mklink()
            { }


            internal mklink(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);
            
            [InputFlag]
            public bool d { get; set; }

            [InputFlag]
            public bool h { get; set; }

            [InputFlag]
            public bool j { get; set; }

            [InputArg(0)]
            public string Link { get; set; }

            [InputArg(1)]
            public string Target { get; set; }


        }

        public class mklink_response : ProcessComandResponse<r, c>
        {
            internal mklink_response(c command, m content)
                : base(command, content)
            { }
        }


    }

}