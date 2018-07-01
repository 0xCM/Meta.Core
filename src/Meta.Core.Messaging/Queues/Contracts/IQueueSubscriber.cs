//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using Meta.Core.Messaging;


    public interface IQueueSubscriber : IDisposable
    {
        void OnMessage(object Message);
    }


    public interface IQueueSubscriber<in M> : IQueueSubscriber
        where M : new()
    {
        void OnMessage(M Message);

    }

   


}