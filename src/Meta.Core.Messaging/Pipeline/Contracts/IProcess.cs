//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Threading.Tasks;

using Meta.Core.Messaging;


public interface IProcess 
{
    int Id { get; }

    int ExitCode { get; }

    CorrelationToken Transmit(IMessage message);


    int WaitForExit();
}




