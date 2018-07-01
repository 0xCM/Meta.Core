//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;

    using Messaging;

    public class VapidProcess : IProcess
    {
        public static readonly VapidProcess TheOne = new VapidProcess();

        VapidProcess(){}

        public int Id 
            => TheOne.Id;

        public int ExitCode 
            => TheOne.ExitCode;

        public int WaitForExit()
            => 0;

        public CorrelationToken Transmit(IMessage command)
        {
            //Living up to its name
            ((ProcessCommand)command).SubmittingProcess = this;

            return CorrelationToken.Empty;
        }
    }
}
