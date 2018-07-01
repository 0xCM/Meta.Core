//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    

    using c = commands_spec.cd;
    using r = commands_spec.cd_response;
    using m = ProcessMessage;
    


    partial class commands_exec
    {
        public static c cd(this IProcess broker)
            => broker.Submit<c>();
    }


    partial class commands_spec
    {
        /// <summary>
        /// Defines a cd command representation
        /// </summary>
        /// <remarks>
        /// See https://technet.microsoft.com/en-us/library/bb490875.aspx
        /// </remarks>
        public sealed class cd : ProcessCommand<c, r>
        {
            public cd()
            { }

            internal cd(m content)
                : base(content)
            { }

            public override r ok(m content)
                => new r(this, content);

            public override r error(m content)
                => new r(this, content);


        }

        public class cd_response : ProcessComandResponse<r, c>
        {
            internal cd_response(c command, m content)
                : base(command, content)
            { }
        }

    }
}