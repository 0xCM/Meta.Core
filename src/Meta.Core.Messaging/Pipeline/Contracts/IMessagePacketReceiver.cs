//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;


    public interface IMessagePacketReceiver<in P>
        where P: IMessagePacket, new()
    {
        void Receive(IEnumerable<P> packets);

    }

    public interface IMessagePacketReceiver
    {
        void Receive(IEnumerable<IMessagePacket> packets);

        void Receive<P>(IEnumerable<P> packets)
            where P : IMessagePacket, new();
    }

    public static partial class MessagePacketDelegates
    {
        public delegate void Receiver(IEnumerable<IMessagePacket> packets);

        public delegate void Receiver<in P>(IEnumerable<P> packets)
            where P : IMessagePacket, new();
            
            
    }

}
