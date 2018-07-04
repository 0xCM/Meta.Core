//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    [SystemViewContract(SystemViewNames.messages)]
    public interface ISystemMessage : ISystemElement
    {
        int message_id { get; }

        short language_id { get; }

        byte? severity { get; }

        bool is_event_logged { get; }

        string text { get; }

    }
}
