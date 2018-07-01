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
    public interface IMessageInputPipeAsync<in I>
        where I : IMessage
    {
        /// <summary>
        /// Receives a single message
        /// </summary>
        /// <param name="message">The input message</param>
        Task<MessageReceiptToken> Send(I message);

        /// <summary>
        /// Receives a single message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <param name="observer">Action invoked when the message has been processed</param>
        void Send(I message, Action<MessageReceiptToken> observer);

        /// <summary>
        /// Receives a sequence of messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when a message from the sequence has been processed</param>
        void Send(IEnumerable<I> messages, Action<MessageReceiptToken> observer);

        /// <summary>
        /// Receives a sequence of messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when all messages from the sequence have been processed</param>
        void Send(IEnumerable<I> messages, Action<IReadOnlyList<MessageReceiptToken>> observer);

        /// <summary>
        /// Receives a sequence of messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        Task<IReadOnlyList<MessageReceiptToken>> Send(IEnumerable<I> messages);

    }

    /// <summary>
    /// Defines operations that accept both typed and untyped messages and message sequences
    /// </summary>
    public interface IMessageInputPipeAsync
    {
        /// <summary>
        /// Accepts a single untyped message
        /// </summary>
        /// <param name="message">The input message</param>
        Task<MessageReceiptToken> Send(IMessage message);

        /// <summary>
        /// Accepts a single untyped message
        /// </summary>
        /// <param name="message">The input message</param>
        void Send(IMessage message, Action<MessageReceiptToken> observer);

        /// <summary>
        /// Accepts a sequence of untyped messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when a message from the input sequence has been processed</param>
        void Send(IEnumerable<IMessage> messages, Action<MessageReceiptToken> observer);

        /// <summary>
        /// Accepts a sequence of untyped messages
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when all messages from the input sequence have been processed</param>
        void Send(IEnumerable<IMessage> messages, Action<IReadOnlyList<MessageReceiptToken>> observer);

        /// <summary>
        /// Accepts a single typed message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <typeparam name="I">The input message type</typeparam>
        Task<MessageReceiptToken> Send<I>(I message)
            where I : IMessage;

        /// <summary>
        /// Accepts a single typed message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <typeparam name="I">The input message type</typeparam>
        void Send<I>(I message, Action<MessageReceiptToken> observer)
                where I : IMessage;

        /// <summary>
        /// Accepts an homogenously-typed message sequence
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when a message from the input sequence has been processed</param>
        /// <typeparam name="I">The input message type</typeparam>
        void Send<I>(IEnumerable<I> messages, Action<MessageReceiptToken> observer)
            where I : IMessage;

        /// <summary>
        /// Accepts an homogenously-typed message sequence
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <param name="observer">Action invoked when all messages from the input sequence have been processed</param>
        /// <typeparam name="I">The input message type</typeparam>
        void Send<I>(IEnumerable<I> messages, Action<IReadOnlyList<MessageReceiptToken>> observer)
            where I : IMessage;

    }


}