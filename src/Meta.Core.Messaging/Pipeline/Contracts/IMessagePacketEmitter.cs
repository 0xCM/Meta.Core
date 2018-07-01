//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;


    public interface IMessagePacketEmitter<out P>
        where P: IMessagePacket
    {
        IEnumerable<P> Emit();
    }

    public interface IMessagePacketEmitter
    {
        IEnumerable<IMessagePacket> Emit();

        IEnumerable<P> Emit<P>()
             where P : IMessagePacket;


    }

    public static partial class MessagePacketDelegates
    {
        public delegate IEnumerable<IMessagePacket> Emitter();

        public delegate IEnumerable<IMessagePacket<P>> Emitter<out P>();
            
    }

}
