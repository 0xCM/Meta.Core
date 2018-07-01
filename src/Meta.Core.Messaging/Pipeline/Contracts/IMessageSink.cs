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
    public interface IMessageSink<in M>
        where M : new()
    {
        /// <summary>
        /// Receives messages of type <typeparamref name="M"/>
        /// </summary>
        /// <param name="messages">The incoming messages</param>
        void Send(IEnumerable<M> messages);

    }



}