//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    /// <summary>
    /// Implementation formats messages of a specific type
    /// </summary>
    /// <typeparam name="M">The supported message type</typeparam>
    public interface IMessageFormatter<in M>
        where M : IMessage
    {
        string Format(M message);
    }


    public interface IMessageFormatter
    {
        IMessage Format(string canonical);

        string Format<M>(M message)
            where M : IMessage;
    }


    partial class MessageDelegates
    {

        delegate string Format(IMessage message);

        delegate string Format<in M>(M message);
    }
}
