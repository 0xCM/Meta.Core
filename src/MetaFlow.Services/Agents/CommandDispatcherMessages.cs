//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.Commands
{
    using static AppMessage;

    using N = SystemNode;

    static class CommandDispatcherMessages
    {
        public static IAppMessage DispatchingCommand(N Host, ICommandDispatch dispatch)
            => Inform("Dispatching @SpecName", new
            {
                Host,
                dispatch.Spec.CommandName,
                dispatch.Spec.SpecName,
            });

        public static IAppMessage CompletedCommand(N Host, ICommandCompletion completion)
            => completion.Succeeded ? Inform($"{Host}: {completion.Spec.SpecName} Succeeded")
                                    : Error($"{Host}: {completion.Spec.SpecName} Failed");

        public static IAppMessage ReceivedNewSubmissions(N Host, int SubmissionCount)
            => Inform("Received @SubmissionCount Submissions", new
            {
                Host,
                SubmissionCount

            });

        public static IAppMessage ListeningForNewSubmissions(N Host, int CycleCount)
            => Babble("Tick/Tock(@CycleCount)", new
            {
                Host,
                CycleCount
            });


    }

}