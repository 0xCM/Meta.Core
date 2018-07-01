//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;
    

    /// <summary>
    /// Defines contract for synchronous message exchange between parties that
    /// can respectively receive/emit both typed and untyped messages
    /// </summary>
    public interface IMessageChannel
    {
        /// <summary>
        /// Synchronously accepts an untyped message and replies with an untyped message
        /// </summary>
        /// <param name="message">The input message</param>
        IMessage Exchange(IMessage message);

        /// <summary>
        /// Synchronously accepts an untyped message sequence and replies with a typed message sequence
        /// </summary>
        /// <param name="messages">The input messages</param>
        IEnumerable<IMessage> Exchange(IEnumerable<IMessage> messages);

        /// <summary>
        /// Synchronously accepts an typed message and replies with an typed message
        /// </summary>
        /// <typeparam name="I">The incoming message type</typeparam>
        /// <typeparam name="O">The outgoing message type</typeparam>
        /// <param name="message">The input message</param>
        /// <returns></returns>
        O Exchange<I, O>(I message)
            where I : IMessage
            where O : IMessage
            ;

        /// <summary>
        /// Synchronously receives a typed message sequence and emits a 
        /// typed message sequence in response
        /// </summary>
        /// <typeparam name="I">The input message type</typeparam>
        /// <typeparam name="O">The output message type</typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        IEnumerable<O> Exchange<I, O>(IEnumerable<I> message)
            where I : IMessage
            where O : IMessage
            ;

    }

    /// <summary>
    /// Defines contract for synchronous message exchange between parties that
    /// accept/yield messages of the same type
    /// </summary>
    /// <typeparam name="M">The exchanged message type</typeparam>
    public interface IMessageChannel<M> : IMessageInputPipe<M>, IMessageOutputPipe<M>
        where M : IMessage
    {
        /// <summary>
        /// Synchronously exchanges a typed message
        /// </summary>
        /// <param name="message">The exchanged message type</param>
        M Exchange(M message);

        /// <summary>
        /// Synchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The exchanged message type</param>
        IEnumerable<M> Exchange(IEnumerable<M> messages);
    }

    /// <summary>
    /// Defines contract for synchronous message exchange between parties that
    /// accept/yield homogenously-typed messages
    /// </summary>
    /// <typeparam name="I">The input message type</typeparam>
    /// <typeparam name="O">The output message type</typeparam>
    public interface IMessageChannel<in I, out O> : IMessageInputPipe<I>, IMessageOutputPipe<O>
        where I : IMessage
        where O : IMessage
    {
        /// <summary>
        /// Synchronously exchanges a typed message
        /// </summary>
        /// <param name="message">The input message</param>
        /// <returns></returns>
        O Exchange(I message);

        /// <summary>
        /// Synchronously exchanges a typed message sequence
        /// </summary>
        /// <param name="messages">The input messages</param>
        /// <returns></returns>
        IEnumerable<O> Exchange(IEnumerable<I> messages);

    }


}