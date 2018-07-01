//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Linq;
    using Meta.Core.Messaging;

    public partial class commands
    {


    }

    public static partial class commands_spec
    {


    }

    public static partial class commands_usage
    {


    }

    public static partial class commands_exec
    {

        internal static c Submit<c>(this IProcess broker, c command = null)
            where c : ProcessCommand<c>, new()
        {
            var k = command ?? new c();             
            broker.Transmit(k);
            return k;
        }




        internal static c Submit<c>(this IProcess broker, params string[] args)
            where c : ProcessCommand<c>, new()
        {
            var command = ProcessCommand<c>.Init(broker, args);            
            broker.Transmit(command);
            return command;
        }


        internal static Func<string, c> get_input_parser<c>()
            where c : ProcessCommand<c>, new()
                => input => (new PromptInputParser<c>()).Parse(input);

    }


}
