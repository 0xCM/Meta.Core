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
    /// Fire and forget transmitter for messages of a specific type
    /// </summary>
    public interface IMessageNotificationPipe<M>
        where M : IMessage
    {
        void Post(M message);

        void Post(IEnumerable<M> messages);

    }

    /// <summary>
    /// Fire and forget transmitter for typed and untyped messages
    /// </summary>
    public interface IMessageNotificationPipe
    {
        void Post(IMessage message);

        void Post(IEnumerable<IMessage> messages);

        void Post<M>(IEnumerable<M> messages)
            where M : IMessage;
    }





}