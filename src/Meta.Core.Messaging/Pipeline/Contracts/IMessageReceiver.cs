//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System.Collections.Generic;


    /// <summary>
    /// Implementor recieves messages of a specific type
    /// </summary>
    /// <typeparam name="M">The supported message type</typeparam>
    public interface IMessageReceiver<in M>
        where M : new()
    {
        /// <summary>
        /// Receives messages of type <typeparamref name="M"/>
        /// </summary>
        /// <param name="message">The incoming messages</param>
        void Receive(M message);

    }

    /// <summary>
    /// Implementor recieves untyped messages
    /// </summary>
    public interface IMessageReceiver
    {
        /// <summary>
        /// Receives untyped messages
        /// </summary>
        /// <param name="message">The incoming message</param>
        void Receive(object message);
          
    }

    partial class MessageDelegates
    {

        public delegate void Receiver(IEnumerable<IMessage> message);
        public delegate void Receiver<in M>(IEnumerable<M> messages)
            where M : IMessage;

    }

}