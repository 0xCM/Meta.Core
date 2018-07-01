//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System.Collections.Generic;


    public interface IMessageInspector
    {
        IEnumerable<IMessage> Inspect(IEnumerable<IMessage> messages);

        IEnumerable<M> Inspect<M>(IEnumerable<M> messages)
            where M : IMessage;
    }

    public interface IMessageInspector<M>
        where M : IMessage
    {
        IEnumerable<M> Inspect(IEnumerable<M> messages);
    }

    partial class MessageDelegates
    {
        public delegate IEnumerable<IMessage> Inspector(IEnumerable<IMessage> messages);

        public delegate IEnumerable<M> Inspector<M>(IEnumerable<M> messages)
            where M : IMessage;

    }

}