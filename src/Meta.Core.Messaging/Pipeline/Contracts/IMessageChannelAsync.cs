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
    /// Defines contract for asynchronous message exchange between parties that
    /// can respectively receive/emit both typed and untyped messages
    /// </summary>
    public interface IMessageChannelAsync
    {
        /// <summary>
        /// Receives an untyped message and asynchronously replies
        /// with an untyped response
        /// </summary>
        /// <param name="message">The input message</param>
        Task<IMessage> Exchange(IMessage message);

        /// <summary>
        /// Receives an untyped message and asynchronously invokes 
        /// the receiver with an untyped message in response
        /// </summary>
        /// <param name="message">The input message</param>
        /// <param name="receive">The action invoked with the response</param>
        void Exchange(IMessage message, Action<IMessage> receive);

        /// <summary>
        /// Receives an untyped message sequence and asynchronously invokes 
        /// the receiver with an untyped message for each response        
        /// </summary>
        /// <param name="messages">The input messages</param>
        void Exchange(IEnumerable<IMessage> messages, Action<IMessage> receive);

        /// <summary>
        /// Receives an typed message and asynchronously replies
        /// with a typed response
        /// </summary>
        /// <typeparam name="I">The input message type</typeparam>
        /// <typeparam name="O">The output message type</typeparam>
        /// <param name="message">The input message</param>
        /// <returns></returns>
        Task<O> Exchange<I, O>(I message)
            where I : IMessage
            where O : IMessage
            ;

        /// <summary>
        /// Receives an homogenously-typed message sequence and asynchronously invokes
        /// the receiver with a typed message for each response        
        /// </summary>
        /// <param name="messages">The input message sequence</param>
        void Exchange<I, O>(IEnumerable<I> messages, Action<O> receive)
            where I : IMessage
            where O : IMessage
            ;


        /// <summary>
        /// Receives an homogenously-typed message sequence and asynchronously replies 
        /// with an untyped message list when when all messages have been processed
        /// </summary>
        /// <param name="messages">The input message sequence</param>
        Task<IReadOnlyList<O>> Exchange<I, O>(IEnumerable<I> messages)
            where I : IMessage
            where O : IMessage
            ;


        /// <summary>
        /// Receives an untyped message and asynchronously invokes 
        /// the receiver with an untyped message in response
        /// </summary>
        /// <param name="message">The input message</param>
        /// <param name="receiver">The action invoked with the response</param>
        void Exchange<I, O>(I message, Task<O> receiver)
            where I : IMessage
            where O : IMessage;

        /// <summary>
        /// Receives an homogenously-typed message sequence and asynchronously invokes
        /// the receiver with an typed message list when all messages in the 
        /// incoming sequence have been processed
        /// </summary>
        /// <param name="messages">The input message sequence</param>
        void Exchange<I, O>(IEnumerable<I> messages, Action<IReadOnlyList<O>> receiver)
            where I : IMessage
            where O : IMessage
            ;


    }


    /// <summary>
    /// Defines contract for synchronous message exchange between parties that
    /// accept/yield messages of the same type
    /// </summary>
    /// <typeparam name="M">The exchanged message type</typeparam>
    public interface IMessageChannelAsync<M> : IMessageInputPipe<M>, IMessageOutputPipe<M>
        where M : IMessage
    {
        /// <summary>
        /// Aynchronously exchanges a typed message
        /// </summary>
        /// <param name="message">The exchanged message type</param>
        Task<M> Exchange(M message);

        /// <summary>
        /// Aynchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The exchanged message type</param>
        Task<IReadOnlyList<M>> Exchange(IEnumerable<M> messages);


        /// <summary>
        /// Aynchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The exchanged message type</param>
        void Exchange(IEnumerable<M> messages, Action<M> receiver);

        /// <summary>
        /// Aynchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The exchanged message type</param>
        void Exchange(IEnumerable<M> messages, Action<IReadOnlyList<M>> receiver);

    }

    /// <summary>
    /// Defines contract for synchronous message exchange between parties that
    /// accept/yield homogenously-typed messages
    /// </summary>
    /// <typeparam name="I">The input message type</typeparam>
    /// <typeparam name="O">The output message type</typeparam>
    public interface IMessageChannelAsync<in I, out O> : IMessageInputPipe<I>, IMessageOutputPipe<O>
        where I : IMessage
        where O : IMessage
    {
        /// <summary>
        /// Synchronously exchanges a typed message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <returns></returns>
        void Exchange(I message, Action<O> receiver);

        /// <summary>
        /// Synchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <returns></returns>
        void Exchange(IEnumerable<I> messages, Action<O> receiver);

        /// <summary>
        /// Synchronously exchanges typed message sequence sets
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <returns></returns>
        void Exchange(IEnumerable<I> messages, Action<IReadOnlyList<O>> receiver);

        
    }

}