//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    /// <summary>
    /// Defines operations that accept messages and message sequences of 
    /// a specific message type
    /// </summary>
    public interface IMessageInputPipe<in I>
        where I : IMessage
    {
        /// <summary>
        /// Receives a single message
        /// </summary>
        /// <param name="message">The input message</param>
        MessageReceiptToken Send(I message);

        /// <summary>
        /// Receives a sequence of messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        IEnumerable<MessageReceiptToken> Send(IEnumerable<I> messages);
    }

    /// <summary>
    /// Defines operations that acept both typed and untyped message sequences
    /// </summary>
    public interface IMessageInputPipe
    {
        /// <summary>
        /// Accepts a single untyped message
        /// </summary>
        /// <param name="message">The input message</param>
        MessageReceiptToken Send(IMessage message);

        /// <summary>
        /// Accepts a sequence of untyped messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        IEnumerable<MessageReceiptToken> Send(IEnumerable<IMessage> messages);

        /// <summary>
        /// Accepts a single typed message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <typeparam name="I">The input message type</typeparam>
        MessageReceiptToken Send<I>(I message)
            where I : IMessage;

        /// <summary>
        /// Accepts a sequence of typed messages
        /// </summary>
        /// <typeparam name="I">The input message type</typeparam>
        /// <param name="messages">The input messages</param>
        IEnumerable<MessageReceiptToken> Send<I>(IEnumerable<I> messages)
            where I : IMessage;

    }


}