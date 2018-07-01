//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;


    public interface IMessagePacket
    {
        Guid CorrelationToken { get; }

        object Payload { get; }

        string Label { get; }
    }

    public interface IMessagePacket<out P> : IMessagePacket
    {
        new P Payload { get; }

    }


}